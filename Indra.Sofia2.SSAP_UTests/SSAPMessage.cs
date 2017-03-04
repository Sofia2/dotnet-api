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
using System.Collections.Generic;

namespace Indra.Sofia2.SSAP_UTests
{
    //[TestClass]
    //public class SSAPMessage<SSAPBodyMessage>
    //{
    //    private SSAP.SSAP.SSAPMessage<SSAPBodyMessage> CreateSSAPMessage<SSAPBodyMessage>(string sufix)
    //    {
    //        var message = new SSAP.SSAP.SSAPMessage<SSAPBodyMessage>()
    //        {
    //            Body = "Test Body" + sufix,
    //            Direction = SSAP.SSAP.SSAPMessage<SSAPBodyMessage>DirectionEnum.REQUEST,
    //            MessageId = "_message_id" + sufix,
    //            MessageType = SSAP.SSAP.SSAPMessage<SSAPBodyMessage>TypesEnum.CREATE,
    //            Ontology = "ontology" + sufix,
    //            SessionKey = "SESSION" + sufix
    //        };
    //        return message;
    //    }

    //    private string CreateJson(string sufix)
    //    {
    //        return "{\"MessageId\":\"_message_id{0}\",\"SessionKey\":\"SESSION{0}\",\"Ontology\":\"ontology{0}\",\"Direction\":0,\"MessageType\":11,\"Body\":\"Test Body{0}\"}".Replace("{0}", sufix);
    //    }

    //    [TestMethod]
    //    public void ToJson()
    //    {
    //        Assert.AreEqual(CreateSSAPMessage<SSAPBodyMessage>("1").ToJson(), CreateJson("1"));
    //    }

    //    [TestMethod]
    //    public void FromJson()
    //    {
    //        var messageFromJson = SSAP.SSAP.SSAPMessage<SSAPBodyMessage>.FromJson(CreateJson("1"));
    //        var message = CreateSSAPMessage<SSAPBodyMessage>("1");

    //        Assert.AreEqual(message.Body, messageFromJson.Body);
    //        Assert.AreEqual(message.Direction, messageFromJson.Direction);
    //        Assert.AreEqual(message.MessageId, messageFromJson.MessageId);
    //        Assert.AreEqual(message.MessageType, messageFromJson.MessageType);
    //        Assert.AreEqual(message.Ontology, messageFromJson.Ontology);
    //        Assert.AreEqual(message.SessionKey, messageFromJson.SessionKey);
    //    }

    //    [TestMethod]
    //    public void CollectionToJson()
    //    {
    //        List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>> messageList = new List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>>();
    //        string json = "[";
    //        for (int i=0; i<3; i++)
    //        {
    //            messageList.Add(CreateSSAPMessage<SSAPBodyMessage>(i.ToString()));
    //            json += CreateJson(i.ToString()) + ",";
    //        }
    //        json = json.Substring(0, json.Length - 1) + "]";
    //        Assert.AreEqual(SSAP.SSAP.SSAPMessage<SSAPBodyMessage>.ToJson(messageList), json);
    //    }

    //    [TestMethod]
    //    public void JsonFromCollection()
    //    {
    //        List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>> messageList = new List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>>();
    //        string json = "[";
    //        for (int i = 0; i < 3; i++)
    //        {
    //            messageList.Add(CreateSSAPMessage<SSAPBodyMessage>(i.ToString()));
    //            json += CreateJson(i.ToString()) + ",";
    //        }
    //        json = json.Substring(0, json.Length - 1) + "]";
    //        List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>> meesages = (List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>>)SSAP.SSAP.SSAPMessage<SSAPBodyMessage>.FromJsonArray(json);
    //        Assert.IsTrue(meesages != null && meesages.Count == 3);
    //    }

    //    [TestMethod]
    //    public void ToJsonWithFields()
    //    {
    //        var message = CreateSSAPMessage<SSAPBodyMessage>("0");
    //        var fields = new List<string>() { "Direction", "MessageId", "MessageType" };
    //        string json = message.ToJson(fields);
    //        var message_aux = SSAP.SSAP.SSAPMessage<SSAPBodyMessage>.FromJson(json);
    //        Assert.AreEqual(message.Direction, message_aux.Direction, "Direction obtenido: " + message_aux.Direction);
    //        Assert.AreEqual(message.MessageId, message_aux.MessageId, "MessageId obtenido: " + message_aux.MessageId);
    //        Assert.AreEqual(message.MessageType, message_aux.MessageType, "MessageType obtenido: " + message_aux.MessageType);
    //        Assert.IsNull(message_aux.Body, "Body obtenido: " + message_aux.Body);
    //        Assert.IsNull(message_aux.Ontology, "Ontology obtenido: " + message_aux.Ontology);
    //        Assert.IsNull(message_aux.SessionKey, "SessionKey obtenido: " + message_aux.SessionKey);
    //    }

    //    [TestMethod]
    //    public void CollectionToJsonWithFields()
    //    {
    //        List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>> messageList = new List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>>();
    //        var fields = new List<string>() { "Direction", "MessageId", "MessageType" };

    //        for (int i = 0; i < 3; i++)
    //        {
    //            messageList.Add(CreateSSAPMessage<SSAPBodyMessage>(i.ToString()));
    //        }
    //        var strMessages = SSAP.SSAP.SSAPMessage<SSAPBodyMessage>.ToJson(messageList, fields);
    //        var messageList_aux = (List<SSAP.SSAP.SSAPMessage<SSAPBodyMessage>>)SSAP.SSAP.SSAPMessage<SSAPBodyMessage>.FromJsonArray(strMessages);
    //        for (int i = 0; i < 3; i++)
    //        {
    //            Assert.AreEqual(messageList[i].Direction, messageList_aux[i].Direction, "Direction obtenido: " + messageList_aux[i].Direction);
    //            Assert.AreEqual(messageList[i].MessageId, messageList_aux[i].MessageId, "MessageId obtenido: " + messageList_aux[i].MessageId);
    //            Assert.AreEqual(messageList[i].MessageType, messageList_aux[i].MessageType, "MessageType obtenido: " + messageList_aux[i].MessageType);
    //            Assert.IsNull(messageList_aux[i].Body, "Body obtenido: " + messageList_aux[i].Body);
    //            Assert.IsNull(messageList_aux[i].Ontology, "Ontology obtenido: " + messageList_aux[i].Ontology);
    //            Assert.IsNull(messageList_aux[i].SessionKey, "SessionKey obtenido: " + messageList_aux[i].SessionKey);
    //        }
    //    }

    //}
}
