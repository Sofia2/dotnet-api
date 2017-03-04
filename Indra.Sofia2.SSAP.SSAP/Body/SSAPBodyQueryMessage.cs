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

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodyQueryMessage : SSAPBodyMessage
    {
        #region Public Properties

        /// <summary>
        /// Gets type to json serialization
        /// </summary>
        [JsonProperty(PropertyName = "@type")]
        public override string JsonType
        {
            get
            {
                return "SSAPBodyQueryMessage";
            }
        }

        private string _query;
        /// <summary>
        /// Gets or sets the sent query
        /// </summary>
        [JsonProperty(PropertyName = "query")]
        public string Query
        {
            get { return _query; }
            set { _query = value; }
        }

        private SSAPQueryTypeEnum _queryType;
        /// <summary>
        /// Gets or sets the sent query type
        /// </summary>
        [JsonProperty(PropertyName = "queryType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPQueryTypeEnum QueryType
        {
            get { return _queryType; }
            set { _queryType = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyQueryMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyQueryMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyQueryMessage> collection)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyQueryMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyQueryMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyQueryMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyQueryMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyQueryMessage instance</returns>
        public new static SSAPBodyQueryMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyQueryMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyQueryMessage collection</returns>
        public new static ICollection<SSAPBodyQueryMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyQueryMessage>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
