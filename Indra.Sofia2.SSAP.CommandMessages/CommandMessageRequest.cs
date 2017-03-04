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
    public class CommandMessageRequest
    {
        #region Properties

        private string _messageId;
        /// <summary>
        /// Gets or sets the Message Id.
        /// </summary>
        public string MessageId
        {
            get { return _messageId; }
            set { _messageId = value; }
        }

        private CommandType _commandType;
        /// <summary>
        /// Gets or sets the Message Command Type 
        /// </summary>
        public CommandType CommandType
        {
            get { return _commandType; }
            set { _commandType = value; }
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

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<CommandMessageRequest>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<CommandMessageRequest>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a CommandMessageRequest collection in a Json string
        /// </summary>
        /// <param name="collection">CommandMessageRequest collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<CommandMessageRequest> collection)
        {
            return SerializationHelper<CommandMessageRequest>.ToJson(collection);
        }

        /// <summary>
        /// Converts a CommandMessageRequest collection in a Json string
        /// </summary>
        /// <param name="collection">CommandMessageRequest collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<CommandMessageRequest> collection, List<string> fields)
        {
            return SerializationHelper<CommandMessageRequest>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a CommandMessageRequest instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A CommandMessageRequest instance</returns>
        public static CommandMessageRequest FromJson(string json)
        {
            return SerializationHelper<CommandMessageRequest>.FromJson(json);
        }

        /// <summary>
        /// Creates a CommandMessageRequest collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>CommandMessageRequest collection</returns>
        public static ICollection<CommandMessageRequest> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<CommandMessageRequest>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
