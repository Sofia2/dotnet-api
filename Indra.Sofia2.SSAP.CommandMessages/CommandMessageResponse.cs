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
using Indra.Sofia2.SSAP.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.CommandMessages
{
    public class CommandMessageResponse
    {
        #region Public Properties

        private string _messageId;
        /// <summary>
        /// Gets or sets the Message Id.
        /// </summary>
        public string MessageId
        {
            get { return _messageId; }
            set { _messageId = value; }
        }

        private string _clientId;
        /// <summary>
        /// Gets or sets the client Id.
        /// </summary>
        public string ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }
        
        private string _commandMessage;
        /// <summary>
        /// Gets or sets Command Message
        /// </summary>
        public string CommandMessage
        {
            get { return _commandMessage; }
            set { _commandMessage = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<CommandMessageResponse>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<CommandMessageResponse>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a CommandMessageResponse collection in a Json string
        /// </summary>
        /// <param name="collection">CommandMessageResponse collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<CommandMessageResponse> collection)
        {
            return SerializationHelper<CommandMessageResponse>.ToJson(collection);
        }

        /// <summary>
        /// Converts a CommandMessageResponse collection in a Json string
        /// </summary>
        /// <param name="collection">CommandMessageResponse collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<CommandMessageResponse> collection, List<string> fields)
        {
            return SerializationHelper<CommandMessageResponse>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a CommandMessageResponse instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A CommandMessageResponse instance</returns>
        public static CommandMessageResponse FromJson(string json)
        {
            return SerializationHelper<CommandMessageResponse>.FromJson(json);
        }

        /// <summary>
        /// Creates a CommandMessageResponse collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>CommandMessageResponse collection</returns>
        public static ICollection<CommandMessageResponse> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<CommandMessageResponse>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
