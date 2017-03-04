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
using Indra.Sofia2.SSAP.SSAP.JSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public abstract class SSAPBodyMessage
    {
        #region Public Methods

        /// <summary>
        /// Gets type to json serialization
        /// </summary>
        [JsonProperty(PropertyName = "@type")]
        public abstract string JsonType { get; }

        private object _data;
        /// <summary>
        /// Gets or sets the operation data
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public object Data
        {
            get { return _data; }
            set
            { _data = value; }
        }

        private string _version = "ONE";
        /// <summary>
        /// Gets or sets the body message
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version
        {
            get { return _version; }
            //set { _version = value; }
        }

        /// <summary>
        /// Envolves the JSON string with "{}" if is not envolved yet. 
        /// </summary>
        /// <param name="query">json string</param>
        /// <returns>json string</returns>
        protected string PrepareQuotes(string query)
        {
            string myquery = query;
            if (String.IsNullOrEmpty(myquery))
            {
                myquery = "";
            }
            if (!myquery.StartsWith("{"))
            {
                StringBuilder sb = new StringBuilder(myquery);
                sb.Insert(0, "{");
                sb.Append("}");
                myquery = sb.ToString();
            }
            return myquery;
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBodyMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyMessage> collection)
        {
            return SerializationHelper<SSAPBodyMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyMessage instance</returns>
        public static SSAPBodyMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyMessage collection</returns>
        public static ICollection<SSAPBodyMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
