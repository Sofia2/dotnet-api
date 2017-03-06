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
    public class SSAPBodyQueryWithParamMessage : SSAPBodyQueryMessage
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
                return "SSAPBodyQueryWithParamMessage";
            }
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
            return SerializationHelper<SSAPBodyQueryWithParamMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyQueryWithParamMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyQueryWithParamMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyQueryWithParamMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyQueryWithParamMessage> collection)
        {
            return SerializationHelper<SSAPBodyQueryWithParamMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyQueryWithParamMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyQueryWithParamMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyQueryWithParamMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyQueryWithParamMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyQueryWithParamMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyQueryWithParamMessage instance</returns>
        public new static SSAPBodyQueryWithParamMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyQueryWithParamMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyQueryWithParamMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyQueryWithParamMessage collection</returns>
        public new static ICollection<SSAPBodyQueryWithParamMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyQueryWithParamMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
