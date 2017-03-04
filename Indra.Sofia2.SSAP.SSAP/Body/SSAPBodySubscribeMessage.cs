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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodySubscribeMessage : SSAPBodyMessage
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
                return "SSAPBodySubscribeMessage";
            }
        }

        private int _msRefresh = 0;
        /// <summary>
        /// Gets or sets the forward time (in milliseconds)
        /// </summary>
        [JsonProperty(PropertyName = "msRefresh")]
        public int MsRefresh
        {
            get { return _msRefresh; }
            set { _msRefresh = value; }
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
        public SSAPQueryTypeEnum QueryType
        {
            get { return _queryType; }
            set { _queryType = value; }
        }

        private Dictionary<string, string> _queryParams;
        /// <summary>
        /// Gets or sets thq query params (key-value)
        /// </summary>
        [JsonProperty(PropertyName = "queryParams")]
        public Dictionary<string, string> QueryParams
        {
            get { return _queryParams; }
            set { _queryParams = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodySubscribeMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodySubscribeMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodySubscribeMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodySubscribeMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodySubscribeMessage> collection)
        {
            return SerializationHelper<SSAPBodySubscribeMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodySubscribeMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodySubscribeMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodySubscribeMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodySubscribeMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodySubscribeMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodySubscribeMessage instance</returns>
        public static new SSAPBodySubscribeMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodySubscribeMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodySubscribeMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodySubscribeMessage collection</returns>
        public static new ICollection<SSAPBodySubscribeMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodySubscribeMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
