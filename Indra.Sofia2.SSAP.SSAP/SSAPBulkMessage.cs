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
using Indra.Sofia2.SSAP.Common.Exceptions;
using Indra.Sofia2.SSAP.Common.Serialization;
using Indra.Sofia2.SSAP.SSAP.Body;
using Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message;
using System.Collections.Generic;


namespace Indra.Sofia2.SSAP.SSAP
{
    public class SSAPBulkMessage : SSAPMessage<SSAPBodyBulkMessage>
    {
        private const string NOT_SUPPORTED_MESSAGE = "Message type: {0} is not supported by SSAPBulkMessage";
        /// <summary>
        /// Constructor
        /// </summary>
        public SSAPBulkMessage()
        {
            this.Body = new SSAPBodyBulkMessage();
        }

        #region Public Methods

        /// <summary>
        /// Add a message in the body of the object.
        /// </summary>
        /// <param name="ssapMessage">Message to be added</param>
        /// <exception cref="NotSupportedMessageTypeException">Message type is not supported</exception>
        public void AddMessage(SSAPMessage<SSAPBodyOperationMessage> ssapMessage)
        {
            CheckMessageType(ssapMessage.MessageType);
            SSAPBodyBulkItem item = new SSAPBodyBulkItem()
            {
                Ontology = ssapMessage.Ontology,
                MessageType = ssapMessage.MessageType,
                Body = ssapMessage.Body.ToJson()
            
            };

            Body.Items.Add(item);
        }

        /// <summary>
        /// Add a mesasge list in the body of the body
        /// </summary>
        /// <param name="ssapMessages">Message list to be added</param>
        /// <exception cref="NotSupportedMessageTypeException">Message type is not supported</exception>
        public void AddMessage(List<SSAPMessage<SSAPBodyOperationMessage>> ssapMessages)
        {
            //ICollection<SSAPBodyBulkItem> items = SSAPBodyBulkItem.FromJsonArray(this.Body.ToString());
            foreach (var message in ssapMessages)
            {
                AddMessage(message);
                       
            }
            //this.Body = SSAPBodyBulkItem.ToJson(items);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBulkMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBulkMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Private Methods

        private void CheckMessageType(SSAPMessageTypesEnum messageType)
        {
            switch(messageType)
            {
                case SSAPMessageTypesEnum.INSERT:
                case SSAPMessageTypesEnum.UPDATE:
                case SSAPMessageTypesEnum.DELETE:
                    break;
                default:
                    throw new NotSupportedMessageTypeException(String.Format(NOT_SUPPORTED_MESSAGE, messageType.ToString("G")));
            }
        }

        #endregion Private Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBulkMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBulkMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBulkMessage> collection)
        {
            return SerializationHelper<SSAPBulkMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBulkMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBulkMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBulkMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBulkMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBulkMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBulkMessage instance</returns>
        public new static SSAPBulkMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBulkMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBulkMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBulkMessage collection</returns>
        public new static ICollection<SSAPBulkMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBulkMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
