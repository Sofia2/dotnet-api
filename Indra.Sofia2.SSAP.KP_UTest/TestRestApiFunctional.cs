/*******************************************************************************
* Copyright 2013-15 Indra Sistemas S.A.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License. 
 ******************************************************************************/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Indra.Sofia2.SSAP.KP.Implementations.Rest;
using Indra.Sofia2.SSAP.KP.Implementations.Rest.Resource;
using System.Diagnostics;
using System.Collections.Generic;
using Indra.Sofia2.SSAP.Common.Serialization;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

using Indra.Sofia2.SSAP.KP.Implementations.WebSocket;
using System.Threading;
using Indra.Sofia2.SSAP.SSAP;
using Indra.Sofia2.SSAP.SSAP.Body;

namespace Indra.Sofia2.SSAP.KP_UTest
{
    [TestClass]
    public class TestRestApiFunctional
    {
        #region Constantes


        // Sofia2
        private static String SERVICE_URL = "http://sofia2.com/sib/services/api_ssap/";
        private static String TOKEN = "49622ff059364fcea6ce78e8b0fa8b4b";
        private static String KP = "KP_APITesting";
        private static String KP_INSTANCE = "KP_APITesting:KPTestTemperatura01";


        // localhost
        //private static String SERVICE_URL = "http://localhost:8080/sib/services/api_ssap/";
        //private static String TOKEN = "9f7e526e5423436bb9e4ea87afb1573c";
        //private static String KP = "TestKP";
        //private static String KP_INSTANCE = "TestKP:KPTestTemperatura01";

        //private static String SERVICE_URL = "http://sofia2.com/sib/services/api_ssap/";
        //private static String SERVICE_URL = "http://localhost:8080/sib/services/api_ssap/";
        //private static String TOKEN = "9f7e526e5423436bb9e4ea87afb1573c";
        //private static String KP = "TestKP";
        //private static String KP_INSTANCE = "TestKP:KPTestTemperatura01";

        private static String ONTOLOGY_NAME = "TestSensorTemperatura";
        private static String ONTOLOGY_INSTANCE = "{\"Sensor\":{\"geometry\":{\"coordinates\":[40.512967,-3.67495],\"type\":\"Point\"},    \"assetId\": \"S_Temperatura_00067\",\"measure\":25,\"timestamp\":{\"$date\":\"2014-04-29T08:24:54.005Z\"}}}";
        private static String ONTOLOGY_BULK_INSTANCE = "{{\"ONTOLOGIA_TEST\":{\"Atributo1\":\"camion\",\"Atributo2\":false}},{\"ONTOLOGIA_TEST\":{\"Atributo1\":\"furgoneta\",\"Atributo2\":false}}, {\"ONTOLOGIA_TEST\":{\"Atributo1\":\"barco\",\"Atributo2\":false}}, {\"ONTOLOGIA_TEST\":{\"Atributo1\":\"avion\",\"Atributo2\":false}}, {\"ONTOLOGIA_TEST\":{\"Atributo1\":\"helicoptero\",\"Atributo2\":false}}}";
        //private static String ONTOLOGY_UPDATE = "{\"_id\":{\"$oid\":\"{oid}\"}, \"ONTOLOGIA_TEST\":{\"Atributo1\":\"COSA1\",\"Atributo2\":false}}";
        private static String ONTOLOGY_UPDATE = "{\"_id\":{\"$oid\":\"{oid}\"},\"Sensor\":{\"geometry\":{\"coordinates\":[40.512967,-3.67495],\"type\":\"Point\"},\"assetId\":\"S_Temperatura_00067\",\"measure\":20,\"timestamp\":{\"$date\":\"2014-04-29T08:24:54.005Z\"}}}";

        //private static String ONTOLOGY_QUERY_NATIVE_CRITERIA = "{\"Atributo1\": \"COSA\"}";
        private static String ONTOLOGY_QUERY_NATIVE_CRITERIA = "{\"Sensor.assetId\":\"S_Temperatura_00067\"}";
        private static String ONTOLOGY_QUERY_NATIVE_STATEMENT = "db.TestSensorTemperatura.find({\"Sensor.assetId\":\"S_Temperatura_00067\"})";
        //private static String ONTOLOGY_QUERY_SQLLIKE = "select * from ONTOLOGIA_TEST where Atributo1 = \"COSA_AUTOMATICA\" limit 3";
        private static String ONTOLOGY_QUERY_SQLLIKE = "select * from TestSensorTemperatura where Sensor.assetId = \"S_Temperatura_00066\"";
        private static String ONTOLOGY_INSERT_SQLLIKE = "insert into ONTOLOGIA_TEST(Atributo1, Atributo2) values (\"COSA_AUTOMATICA\", true)";
        private static String ONTOLOGY_DELETE = "{\"_id\":{\"$oid\":\"<ObjId>\"}}";

        #endregion Constantes

        private SSAPResourceAPI _api;

        [TestInitialize]
        private void SetUpClass()
        {
            _api = new SSAPResourceAPI(SERVICE_URL);
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        private string Join()
        {
            //Genera un recurso SSAP con un JOIN
            SSAPResource ssapJoin = new SSAPResource()
            {
                Join = true,
                InstanceKP = KP_INSTANCE,
                Token = TOKEN
            };

            //Hace un POST del recurso, equivalente a una petición SSAP JOIN
            SetUpClass();
            var respJoin = _api.Insert(ssapJoin);
            respJoin.Wait();
            
            Trace.WriteLine(String.Format("Código HTTP retorno Join: {0}", respJoin.GetAwaiter().GetResult().StatusCode.ToString()));
            string sessionKey = null;
            try
            {
                var respSsap = _api.ResponseAsSSAP(respJoin.Result);
                respJoin.Wait();
                sessionKey = respSsap.Result.SessionKey;
                Trace.WriteLine(String.Format("SessionKey: {0}", sessionKey));

                Assert.AreEqual(respJoin.Result.StatusCode, System.Net.HttpStatusCode.OK);
                return sessionKey;
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
                throw ex;
            }

        }

        private void Leave(string sessionKey)
        {
            if (!String.IsNullOrEmpty(sessionKey))
            {
                SSAPResource ssapLeave = new SSAPResource()
                {
                    Leave = true,
                    SessionKey = sessionKey
                };
                var respLeave = _api.Insert(ssapLeave);
                respLeave.Wait();
                Assert.AreEqual(respLeave.Result.StatusCode, System.Net.HttpStatusCode.OK);
            }
        }

        [TestMethod]
        public void TestQueryBDC()
        {
            var sessionKey = Join();
            var respQuery = _api.Query(sessionKey, null, "select identificacion from asset;", null, "BDC");
            respQuery.Wait();
            Assert.AreEqual(respQuery.Result.StatusCode, System.Net.HttpStatusCode.OK);
            Trace.WriteLine(String.Format("Código HTTP retorno Query: {0}", respQuery.Result.StatusCode.ToString()));
            try
            {
                var respSsap = _api.ResponseAsSSAP(respQuery.Result);
                respSsap.Wait();
                Trace.WriteLine("Respuesta de la Query " + respSsap.Result.Data);
            }
            catch(Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }
            Leave(sessionKey);
        }

        [TestMethod]
        public void TestInsertUpdate()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            //Actualización del objeto que se acaba de insertar con UPDATE
            if (!String.IsNullOrEmpty(objectId))
            {
                string objId = JObject.Parse(objectId.Trim())["_id"]["$oid"].Value<String>();
                string updateData =ONTOLOGY_UPDATE.Replace("{oid}", objId);

                //SSAP con Update
                SSAPResource ssapUpdate = new SSAPResource()
                {
                    SessionKey = sessionKey,
                    Ontology = ONTOLOGY_NAME,
                    Data = updateData                   
                };
                var respUpdate = _api.Update(ssapUpdate);
                respUpdate.Wait();
                Trace.WriteLine("Codigo HTTP retorno UPDATE: " + respUpdate.Result.StatusCode.ToString());
                Assert.AreEqual(respUpdate.Result.StatusCode, System.Net.HttpStatusCode.OK);
            }
            if (!String.IsNullOrEmpty(sessionKey))
            {
                Leave(sessionKey);
            }
        }

        [TestMethod]
        public void TestInsertBulk()
        {
            var sessionKey = Join();

            //SSAP con insert
            var msgBulk = new List<String>();
            msgBulk.Add(ONTOLOGY_INSTANCE);
            msgBulk.Add(ONTOLOGY_INSTANCE);
            msgBulk.Add(ONTOLOGY_INSTANCE);

            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = SerializationHelper<List<String>>.ToJson(msgBulk),
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (!String.IsNullOrEmpty(sessionKey))
            {
                Leave(sessionKey);
            }
        }

        [TestMethod]
        public void TestQueryByObjectId()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                //Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + respSSAP);
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (!String.IsNullOrEmpty(objectId))
            {
                string objId = JObject.Parse(objectId.Trim())["_id"]["$oid"].Value<String>();
                
                var respQuery = this._api.Query(objId, sessionKey, ONTOLOGY_NAME);
                respQuery.Wait();

                Trace.WriteLine("Codigo HTTP retorno Query: " + respQuery.Result.StatusCode.ToString());
                Assert.AreEqual(respQuery.Result.StatusCode, System.Net.HttpStatusCode.OK);
                try
                {
                    var respSSAP = _api.ResponseAsSSAP(respQuery.Result);
                    respSSAP.Wait();
                    Trace.WriteLine("Respuesta de la Query: " + respSSAP.Result.Data);
                }
                catch (Exception ex)
                {
                    Trace.Fail(ex.Message, ex.StackTrace);
                    Assert.Fail(ex.Message);
                }
            }
            Leave(sessionKey);
        }

        [TestMethod]
        public void TestQueryNativeCriteria()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (!String.IsNullOrEmpty(objectId))
            {
                var respQuery = this._api.Query(sessionKey, ONTOLOGY_NAME, ONTOLOGY_QUERY_NATIVE_CRITERIA, null, "NATIVE");
                respQuery.Wait();

                Trace.WriteLine("Codigo HTTP retorno Query: " + respQuery.Result.StatusCode.ToString());
                Assert.AreEqual(respQuery.Result.StatusCode, System.Net.HttpStatusCode.OK);
                try
                {
                    var respSSAP = _api.ResponseAsSSAP(respQuery.Result);
                    respSSAP.Wait();
                    Trace.WriteLine("Respuesta de la Query: " + respSSAP.Result.Data);
                }
                catch (Exception ex)
                {
                    Trace.Fail(ex.Message, ex.StackTrace);
                    Assert.Fail(ex.Message);
                }
            }
            Leave(sessionKey);
        }

        [TestMethod]
        public void TestQueryNativeStatement()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (!String.IsNullOrEmpty(objectId))
            {
                var respQuery = this._api.Query(sessionKey, ONTOLOGY_NAME, ONTOLOGY_QUERY_NATIVE_STATEMENT, null, "NATIVE");
                respQuery.Wait();

                Trace.WriteLine("Codigo HTTP retorno Query: " + respQuery.Result.StatusCode.ToString());
                Assert.AreEqual(respQuery.Result.StatusCode, System.Net.HttpStatusCode.OK);
                try
                {
                    var respSSAP = _api.ResponseAsSSAP(respQuery.Result);
                    respSSAP.Wait();
                    Trace.WriteLine("Respuesta de la Query: " + respSSAP.Result.Data);
                }
                catch (Exception ex)
                {
                    Trace.Fail(ex.Message, ex.StackTrace);
                    Assert.Fail(ex.Message);
                }
            }
            Leave(sessionKey);
        }

        [TestMethod]
        public void TestQuerySQLLIKEStatement()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (!String.IsNullOrEmpty(objectId))
            {
                var respQuery = this._api.Query(sessionKey, ONTOLOGY_NAME, ONTOLOGY_QUERY_SQLLIKE, null, "SQLLIKE");
                respQuery.Wait();

                Trace.WriteLine("Codigo HTTP retorno Query: " + respQuery.Result.StatusCode.ToString());
                Assert.AreEqual(respQuery.Result.StatusCode, System.Net.HttpStatusCode.OK);
                try
                {
                    var respSSAP = _api.ResponseAsSSAP(respQuery.Result);
                    respSSAP.Wait();
                    Trace.WriteLine("Respuesta de la Query: " + respSSAP.Result.Data);
                }
                catch (Exception ex)
                {
                    Trace.Fail(ex.Message, ex.StackTrace);
                    Assert.Fail(ex.Message);
                }
            }
            Leave(sessionKey);
        }

        public void TestInsertSQLLIKEStatement()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (String.IsNullOrEmpty(objectId))
            {
                var respQuery = this._api.Query(sessionKey, ONTOLOGY_NAME, ONTOLOGY_INSERT_SQLLIKE, null, "SQLLIKE");
                respQuery.Wait();

                Trace.WriteLine("Codigo HTTP retorno INSERT SQL: " + respQuery.Result.StatusCode.ToString());
                Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);
                try
                {
                    var respSSAP = _api.ResponseAsSSAP(respQuery.Result);
                    respSSAP.Wait();
                    Trace.WriteLine("Respuesta del Insert: " + respSSAP.Result.Data);
                }
                catch (Exception ex)
                {
                    Trace.Fail(ex.Message, ex.StackTrace);
                    Assert.Fail(ex.Message);
                }
            }
            Leave(sessionKey);
        }

        public void TestDeleteByObjectId()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (String.IsNullOrEmpty(objectId))
            {
                string objId = JObject.Parse(objectId.Trim())["_id"]["$oid"].Value<String>();

                var respDelete = this._api.DeleteOid(objId, sessionKey, ONTOLOGY_NAME); 
                respDelete.Wait();

                Trace.WriteLine("Codigo HTTP retorno DELETE: " + respDelete.Result.StatusCode.ToString());
                Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);
            }
            Leave(sessionKey);
        }

        [TestMethod]
        public void TestDelete()
        {
            var sessionKey = Join();

            //SSAP con insert
            SSAPResource ssapInsert = new SSAPResource()
            {
                Data = ONTOLOGY_INSTANCE,
                SessionKey = sessionKey,
                Ontology = ONTOLOGY_NAME
            };
            var respInsert = _api.Insert(ssapInsert);
            respInsert.Wait();
            Trace.WriteLine("Codigo HTTP retorno INSERT: " + respInsert.Result.StatusCode.ToString());
            Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);

            string objectId = null;
            try
            {
                var respSSAP = _api.ResponseAsSSAP(respInsert.Result);
                respSSAP.Wait();
                objectId = respSSAP.Result.Data.ToString();
                Trace.WriteLine("Instancia de la ontologia insertada en BDTR: " + objectId);
            }
            catch (Exception ex)
            {
                Trace.Fail(ex.Message, ex.StackTrace);
                Assert.Fail(ex.Message);
            }

            if (String.IsNullOrEmpty(objectId))
            {
                string objId = JObject.Parse(objectId.Trim())["_id"]["$oid"].Value<String>(); 
                string deleteData = String.Format(ONTOLOGY_DELETE, objId);

                SSAPResource ssapDelete = new SSAPResource()
                {
                    Data = deleteData,
                    SessionKey = sessionKey,
                    Ontology = ONTOLOGY_NAME
                };
                var respDelete = this._api.Delete(ssapDelete);
                respDelete.Wait();

                Trace.WriteLine("Codigo HTTP retorno DELETE: " + respDelete.Result.StatusCode.ToString());
                Assert.AreEqual(respInsert.Result.StatusCode, System.Net.HttpStatusCode.OK);
            }


            Leave(sessionKey);
        }

        [TestMethod]
        public void TestStatus()
        {
            SetUpClass();
            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);
                     
            Dictionary<string, string> status = new Dictionary<string, string>();
            status.Add("atributo1", "valor1");
            status.Add("atributo2", "valor2");
                       
            var response = _api.Status(KP, KP_INSTANCE, TOKEN, "", status, timeStamp);
            response.Wait();
            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);

        }

        [TestMethod]
        public void TestStatusEmptyDictionary()
        {
            SetUpClass();
            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);
            
            Dictionary<string, string> status = new Dictionary<string, string>();

            var response = _api.Status(KP, KP_INSTANCE, TOKEN, "", status, timeStamp);
            response.Wait();
            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);

        }

        [TestMethod]
        public void TestStatusNullDictionary()
        {
            SetUpClass();
            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);

            Dictionary<string, string> status = null;
            
            var response = _api.Status(KP, KP_INSTANCE, TOKEN, "", status, timeStamp);
            response.Wait();
            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);

        }

        [TestMethod]
        public void TestLocation()
        {
            SetUpClass();
            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);

            Random rnd = new Random();
           
            double lat = (int)(rnd.NextDouble() * 50 + 35);
            double lon = (int)(rnd.NextDouble() * 20 + -3);
            double alt = (int)(rnd.NextDouble() * 50 + 35);
            double speed = (int)(rnd.NextDouble() * 100 + 0);

            var response = _api.Location(KP, KP_INSTANCE, TOKEN, "", 1, lat, lon, alt, 1, speed, timeStamp);
            response.Wait();

            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);

        }

        [TestMethod]
        public void TestError()
        {
            SetUpClass();
            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);
            
            var response = _api.Error(KP, KP_INSTANCE, TOKEN, "", SSAP.SSAPSeverityLevel.DEBUG, "code", "message", timeStamp);
            response.Wait();

            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void TestLog()
        {
            SetUpClass();
            DateTime dt = DateTime.Now;//new DateTime();
            String timeStamp = String.Format("{0:s}", dt);

            var response = _api.Log(KP, KP_INSTANCE, TOKEN, "", SSAP.SSAPLogLevel.WARN, "code", "message", timeStamp);
            response.Wait();

            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);

        }

        [TestMethod]
        public void TestCommand()
        {
            var sessionKey = Join();

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("atributo1", "valor1");
            args.Add("atributo2", "valor2");

            var response = _api.Command(sessionKey, KP, KP_INSTANCE, SSAP.SSAPCommandType.STATUS, args);
            response.Wait();
            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void TestSubscribeCommand()
        {
            SetUpClass();
            var response = _api.SubscribeCommand(KP, KP_INSTANCE, TOKEN, SSAP.SSAPCommandType.STATUS, "http://localhost:3333");
            response.Wait();
            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);

            
        }

        [TestMethod]
        [Ignore()]
        public void TestSubscribeCommandAndIndication()
        {
            SetUpClass();
            var response = _api.SubscribeCommand(KP, KP_INSTANCE, TOKEN, SSAP.SSAPCommandType.STATUS, "http://localhost:3333");
            response.Wait();
            Assert.AreEqual(response.Result.StatusCode, System.Net.HttpStatusCode.OK);

            LightHttpListener listener = new LightHttpListener();
            Task<string> t = Task<string>.Run(  () => { return listener.Listen(3333); }  );
            
            var sessionKey = Join();

            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("atributo1", "valor1");
            args.Add("atributo2", "valor2");

            var response1 = _api.Command(sessionKey, KP, KP_INSTANCE, SSAP.SSAPCommandType.STATUS, args);
            response1.Wait();
            t.Wait();

            Trace.WriteLine("Codigo HTTP retorno DELETE: " + t.Result.ToString());
            Assert.AreNotEqual(t.Result.ToString(), null);
            
        }

        


    }
}
