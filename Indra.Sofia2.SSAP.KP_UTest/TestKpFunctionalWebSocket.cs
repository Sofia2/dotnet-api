using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indra.Sofia2.SSAP.KP.Implementations.WebSocket;
using Indra.Sofia2.SSAP.SSAP.Body;
using Indra.Sofia2.SSAP.SSAP;
using Indra.Sofia2.SSAP.KP;
using Newtonsoft.Json.Linq;
using Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message;
using System.Threading;
using System.Collections.Generic;

namespace Indra.Sofia2.SSAP.KP_UTest
{
    [TestClass]
    public class TestKpFunctionalWebSocket
    {
        #region Constantes

        private static String SERVICE_URL = "ws://localhost:8080/sib/api_websocket/";
        private static String TOKEN = "9f7e526e5423436bb9e4ea87afb1573c";
        private static String KP = "TestKP";
        private static String KP_INSTANCE = "TestKP:KPTestTemperatura01";
        private static String ONTOLOGY_NAME = "TestSensorTemperatura";
        private static Int32 CONNECTION_TIMEOUT = 6;
        private static Int32 KEEPALIVE_TIMEOUT = 6;

        private static String ONTOLOGY_INSTANCE = "{\"Sensor\":{\"geometry\":{\"coordinates\":[40.512967,-3.67495],\"type\":\"Point\"},    \"assetId\": \"S_Temperatura_00067\",\"measure\":25,\"timestamp\":{\"$date\":\"2014-04-29T08:24:54.005Z\"}}}";
        private static String ONTOLOGY_UPDATE = "{\"Sensor\":{\"geometry\":{\"coordinates\":[40.512967,-3.67495],\"type\":\"Point\"},\"assetId\":\"S_Temperatura_00067\",\"measure\":20,\"timestamp\":{\"$date\":\"2014-04-29T08:24:54.005Z\"}}}";
        private static String ONTOLOGY_UPDATE_WHERE = "{Sensor.assetId:\"S_Temperatura_00067\"}";
        private static String ONTOLOGY_QUERY_NATIVE = "{Sensor.assetId:\"S_Temperatura_00067\"}";
        private static String ONTOLOGY_INSERT_SQLLIKE = "insert into TestSensorTemperatura(geometry, assetId, measure, timestamp) values (\"{ 'coordinates': [ 40.512967, -3.67495 ], 'type': 'Point' }\", \"S_Temperatura_00067\", 15, \"{ '$date': '2014-04-29T08:24:54.005Z'}\")";
        private static String ONTOLOGY_UPDATE_SQLLIKE = "update TestSensorTemperatura set measure = 15 where Sensor.assetId = \"S_Temperatura_00067\"";
        //private static String ONTOLOGY_UPDATE = "{\"_id\":{\"$oid\":\"NO_ID\"},\"Sensor\":{\"geometry\":{\"coordinates\":[40.512967,-3.67495],\"type\":\"Point\"},\"assetId\":\"S_Temperatura_00067\",\"measure\":20,\"timestamp\":{\"$date\":\"2014-04-29T08:24:54.005Z\"}}}";

        #endregion Constantes

        #region Private Properties
        private KpWebSocketClient client;
        #endregion Private Properties



        [TestInitialize]
        public void Initialize()
        {
            WebSocketConnectionConfig config = new WebSocketConnectionConfig();
            config.EnpointUri = SERVICE_URL;
            config.TimeOutConnectionSIB = CONNECTION_TIMEOUT;
            config.KeepAliveInSeconds = KEEPALIVE_TIMEOUT;
            client = new KpWebSocketClient(config);
            client.Connect();
        }

        [TestCleanup]
        public void Cleanup()
        {
            client.Disconnect();
        }

        public string Join()
        {
            SSAPMessage<SSAPBodyJoinTokenMessage> requestJoin = SSAPMessageGenerator.GetInstance().GenerateJoinByTokenMessage(TOKEN, KP_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> responseJoin = (SSAPMessage<SSAPBodyReturnMessage>)client.Send(requestJoin);
            string sessionKey = responseJoin.SessionKey;

            return sessionKey;
        }

        public void Leave(string sessionKey)
        {
            SSAPMessage<SSAPBodyLeaveMessage> requestLeave = SSAPMessageGenerator.GetInstance().GenerateLeaveMessage(sessionKey);
            SSAPMessage<SSAPBodyReturnMessage> responseLeave = client.Send(requestLeave);
        }


        [TestMethod]
        public void TestBasic()
        {
            SSAPMessage<SSAPBodyJoinTokenMessage> request = SSAPMessageGenerator.GetInstance().GenerateJoinByTokenMessage(TOKEN, KP_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);
            string strResponse = response.ToJson();

            Assert.IsTrue(response.Body.IsOk);
            Assert.AreNotEqual(response.Body, null);
        }

        [TestMethod]
        public void TestJoinAndLeave()
        {
            SSAPMessage<SSAPBodyJoinTokenMessage> requestJoin = SSAPMessageGenerator.GetInstance().GenerateJoinByTokenMessage(TOKEN, KP_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> responseJoin = client.Send(requestJoin);
            string sessionKey = responseJoin.SessionKey;

            Assert.IsTrue(responseJoin.Body.IsOk);

            SSAPMessage<SSAPBodyLeaveMessage> requestLeave = SSAPMessageGenerator.GetInstance().GenerateLeaveMessage(sessionKey);
            SSAPMessage<SSAPBodyReturnMessage> responseLeave = client.Send(requestLeave);

            Assert.IsTrue(responseLeave.Body.IsOk);
        }

        [TestMethod]
        public void TestInsertNative()
        {
            string sessionKey = Join();

            SSAPMessage<SSAPBodyOperationMessage> request = SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);
            JObject data = (JObject)response.Body.Data;
            Assert.IsFalse(String.IsNullOrEmpty(data["_id"]["$oid"].Value<string>()));

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestUpdateNative()
        {
            string sessionKey = Join();

            SSAPMessage<SSAPBodyOperationMessage> requestInsert = SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> responseInsert = client.Send(requestInsert);

            SSAPMessage<SSAPBodyOperationMessage> requestUpdate = SSAPMessageGenerator.GetInstance().GenerateUpdateMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_UPDATE, ONTOLOGY_UPDATE_WHERE, SSAPQueryTypeEnum.NATIVE);
            SSAPMessage<SSAPBodyReturnMessage> responseUpdate = client.Send(requestUpdate);

            Assert.IsTrue(responseUpdate.Body.IsOk);
            JArray dataUpdate = (JArray)responseUpdate.Body.Data;
            Assert.IsFalse(String.IsNullOrEmpty(dataUpdate[0]["_id"]["$oid"].Value<string>()));

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestQueryNative()
        {
            string sessionKey = Join();

            SSAPMessage<SSAPBodyOperationMessage> requestInsert = SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> responseInsert = client.Send(requestInsert);

            SSAPMessage<SSAPBodyOperationMessage> request = SSAPMessageGenerator.GetInstance().GenerateQueryMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_QUERY_NATIVE, SSAPQueryTypeEnum.NATIVE);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);
            JArray data = (JArray)response.Body.Data;
            Assert.IsFalse(String.IsNullOrEmpty(data[0]["_id"]["$oid"].Value<string>()));

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestInsertSqlLike()
        {
            string sessionKey = Join();

            SSAPMessage<SSAPBodyOperationMessage> request = SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSERT_SQLLIKE, SSAPQueryTypeEnum.SQLLIKE);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);
            JObject data = (JObject)response.Body.Data;
            Assert.IsFalse(String.IsNullOrEmpty(data["_id"]["$oid"].Value<string>()));

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestUpdateSqlLike()
        {
            string sessionKey = Join();

            SSAPMessage<SSAPBodyOperationMessage> request = SSAPMessageGenerator.GetInstance().GenerateUpdateMessage(sessionKey, ONTOLOGY_NAME, null, ONTOLOGY_UPDATE_SQLLIKE, SSAPQueryTypeEnum.SQLLIKE);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);
            JArray data = (JArray)response.Body.Data;
            Assert.IsFalse(String.IsNullOrEmpty(data[0]["_id"]["$oid"].Value<string>()));

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestQuerySql()
        {
            string sessionKey = Join();

            SSAPMessage<SSAPBodyOperationMessage> requestInsert = SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> responseInsert = client.Send(requestInsert);

            SSAPMessage<SSAPBodyOperationMessage> request = SSAPMessageGenerator.GetInstance().GenerateQueryMessage(sessionKey, ONTOLOGY_NAME, "select * from " + ONTOLOGY_NAME, SSAPQueryTypeEnum.SQLLIKE);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);
            JArray data = (JArray)response.Body.Data;
            Assert.IsFalse(String.IsNullOrEmpty(data[0]["_id"]["$oid"].Value<string>()));

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestQuerySqlBDC()
        {
            string sessionKey = Join();

            SSAPMessage<SSAPBodyOperationMessage> request = SSAPMessageGenerator.GetInstance().GenerateQueryMessage(sessionKey, null, "select * from Asset where identificacion='tweets_sofia'", SSAPQueryTypeEnum.BDC);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            JArray data = (JArray)response.Body.Data;
            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestBulk()
        {
            string sessionKey = Join();

            SSAPBulkMessage request = SSAPMessageGenerator.GetInstance().GenerateBulkMessage(sessionKey, ONTOLOGY_NAME);
            request.AddMessage(SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSTANCE));
            request.AddMessage(SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSTANCE));
            request.AddMessage(SSAPMessageGenerator.GetInstance().GenerateUpdateMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_UPDATE, ONTOLOGY_UPDATE_WHERE, SSAPQueryTypeEnum.NATIVE));
            request.AddMessage(SSAPMessageGenerator.GetInstance().GenerateUpdateMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_UPDATE, ONTOLOGY_UPDATE_WHERE, SSAPQueryTypeEnum.NATIVE));
            SSAPMessage<SSAPBodyReturnMessage> response = (SSAPMessage<SSAPBodyReturnMessage>)client.Send(request);

            SSAPBodyBulkReturnMessage responseData = SSAPBodyBulkReturnMessage.FromJson(response.Body.Data.ToString());

            Assert.IsTrue(responseData.InsertSummary.ObjectsIds.Count > 0);
            Assert.IsTrue(responseData.UpdateSummary.ObjectsIds.Count > 0);

            Leave(sessionKey);
        }
        
        [TestMethod]
        public void TestIndication()
        {
            string sessionKey = Join();

            client.AddListener4SIBNotifications(new WebSocketListener4SIBIndicationNotifications());

            SSAPMessage<SSAPBodySubscribeMessage> requestSubscribe = SSAPMessageGenerator.GetInstance().GenerateSubscribeMessage(sessionKey, ONTOLOGY_NAME, 0, "", SSAPQueryTypeEnum.SQLLIKE);
            SSAPMessage<SSAPBodyReturnMessage> responseSubscribe = client.Send(requestSubscribe);
            string subscriptionId = responseSubscribe.Body.Data.ToString();

            Assert.IsFalse(String.IsNullOrEmpty(subscriptionId));


            SSAPMessage<SSAPBodyOperationMessage> request = SSAPMessageGenerator.GetInstance().GenerateInsertMessage(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSTANCE);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Thread.Sleep(5000);

            Assert.IsTrue(indicationRecived);

            SSAPMessage<SSAPBodyUnsubscribeMessage> requestUnsubscribe = SSAPMessageGenerator.GetInstance().GenerateUnsubscribeMessage(sessionKey, ONTOLOGY_NAME, subscriptionId);
            SSAPMessage<SSAPBodyReturnMessage> responseUnsubscribe = client.Send(requestUnsubscribe);

            Assert.IsTrue(responseUnsubscribe.Body.IsOk);

            Leave(sessionKey);

        }
        

        [TestMethod]
        public void TestLog()
        {
            string sessionKey = Join();

            DateTime dt = DateTime.Now;
            String timeStamp = String.Format("{0:s}", dt);

            SSAPMessage<SSAPBodyLogMessage> request = SSAPMessageGenerator.GetInstance().GenerateLogMessage(KP, KP_INSTANCE, TOKEN, SSAPLogLevel.ERROR, "code", "message", timeStamp);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestError()
        {
            string sessionKey = Join();

            DateTime dt = DateTime.Now;
            String timeStamp = String.Format("{0:s}", dt);

            SSAPMessage<SSAPBodyErrorMessage> request = SSAPMessageGenerator.GetInstance().GenerateErrorMessage(KP, KP_INSTANCE, TOKEN, SSAPSeverityLevel.CRITICAL, "code", "message", timeStamp);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);
        }

        [TestMethod]
        public void TestStatus()
        {
            string sessionKey = Join();

            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);

            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("atributo1", "valor1");
            status.Add("atributo2", "valor2");

            SSAPMessage<SSAPBodyStatusMessage> request = SSAPMessageGenerator.GetInstance().GenerateStatusMessage(KP, KP_INSTANCE, TOKEN, status, timeStamp);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);

        }

        [TestMethod]
        public void TestStatusEmptyDictionary()
        {
            string sessionKey = Join();

            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);

            Dictionary<string, string> status = new Dictionary<string, string>();

            SSAPMessage<SSAPBodyStatusMessage> request = SSAPMessageGenerator.GetInstance().GenerateStatusMessage(KP, KP_INSTANCE, TOKEN, status, timeStamp);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);

        }

        [TestMethod]
        public void TestStatusNullDictionary()
        {
            string sessionKey = Join();

            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);

            Dictionary<string, string> status = null;

            SSAPMessage<SSAPBodyStatusMessage> request = SSAPMessageGenerator.GetInstance().GenerateStatusMessage(KP, KP_INSTANCE, TOKEN, status, timeStamp);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);

        }

        [TestMethod]
        public void TestLocation()
        {
            string sessionKey = Join();

            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);

            Random rnd = new Random();

            double lat = (int)(rnd.NextDouble() * 50 + 35);
            double lon = (int)(rnd.NextDouble() * 20 + -3);
            double alt = (int)(rnd.NextDouble() * 50 + 35);
            double speed = (int)(rnd.NextDouble() * 100 + 0);

            SSAPMessage<SSAPBodyLocationMessage> request = SSAPMessageGenerator.GetInstance().GenerateLocationMessage(KP, KP_INSTANCE, TOKEN, 1, lat, lon, alt, 1, speed, timeStamp);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);

        }

        [TestMethod]
        public void TestCommand()
        {
            var sessionKey = Join();

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("atributo1", "valor1");
            args.Add("atributo2", "valor2");

            SSAPMessage<SSAPBodyCommandMessage> request = SSAPMessageGenerator.GetInstance().GenerateCommandMessage(sessionKey, KP, KP_INSTANCE, SSAPCommandType.STATUS, args);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);

            Assert.IsTrue(response.Body.IsOk);

            Leave(sessionKey);

        }

        [TestMethod]
        public void TestSubscribeCommand()
        {
            string sessionKey = Join();

            client.AddListener4SIBNotifications(new WebSocketCommandListener4SIBIndicationNotifications());

            SSAPMessage<SSAPBodySubscribeCommandMessage> requestSubscribe = SSAPMessageGenerator.GetInstance().GenerateSubscribeCommandMessage(KP, KP_INSTANCE, TOKEN, SSAPCommandType.STATUS);
            SSAPMessage<SSAPBodyReturnMessage> responseSubscribe = client.Send(requestSubscribe);
            string subscriptionId = responseSubscribe.Body.Data.ToString();

            Assert.IsFalse(String.IsNullOrEmpty(subscriptionId));


            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("atributo1", "valor1");
            args.Add("atributo2", "valor2");

            SSAPMessage<SSAPBodyCommandMessage> request = SSAPMessageGenerator.GetInstance().GenerateCommandMessage(sessionKey, KP, KP_INSTANCE, SSAPCommandType.STATUS, args);
            SSAPMessage<SSAPBodyReturnMessage> response = client.Send(request);
            
            Thread.Sleep(5000);

            Assert.IsTrue(indicationCommandRecived);
            
            Leave(sessionKey);
              
        }

        #region AUX Listener class for subscription tests
        public static Boolean indicationRecived = false;
        public static Boolean indicationCommandRecived = false;
        public class WebSocketListener4SIBIndicationNotifications : IListener4SIBIndicationNotifications
        {
            public void OnIndication(string idNotifition, SSAPMessage<SSAPBodyMessage> message)
            {
                indicationRecived = true;
            }
        }
        public class WebSocketCommandListener4SIBIndicationNotifications : IListener4SIBIndicationNotifications
        {
            public void OnIndication(string idNotifition, SSAPMessage<SSAPBodyMessage> message)
            {
               indicationCommandRecived = true; 
            }
        }
        #endregion Listener class for subscription tests
    }
}
