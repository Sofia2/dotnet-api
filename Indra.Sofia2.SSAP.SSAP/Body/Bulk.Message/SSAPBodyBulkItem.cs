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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message
{
    public class SSAPBodyBulkItem
    {
        #region Public Properties

        private SSAPMessageTypesEnum _messageType;
        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPMessageTypesEnum MessageType
        {
            get { return _messageType; }
            set { _messageType = value; }
        }

        private string _body;
        /// <summary>
        /// Gets or sets the message body
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _ontology;
        /// <summary>
        /// Gets or sets the message ontology
        /// </summary>
        [JsonProperty(PropertyName = "ontology")]
        public string Ontology
        {
            get { return _ontology; }
            set { _ontology = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBodyBulkItem>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyBulkItem>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyBulkItem collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyBulkItem collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyBulkItem> collection)
        {
            return SerializationHelper<SSAPBodyBulkItem>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyBulkItem collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyBulkItem collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyBulkItem> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyBulkItem>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyBulkItem instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyBulkItem instance</returns>
        public static SSAPBodyBulkItem FromJson(string json)
        {
            return SerializationHelper<SSAPBodyBulkItem>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyBulkItem collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyBulkItem collection</returns>
        public static ICollection<SSAPBodyBulkItem> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyBulkItem>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
