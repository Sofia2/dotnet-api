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
    public class SSAPBodyErrorMessage : SSAPBodyMessage
    {
        #region Public Methods

        /// <summary>
        /// Gets type to json serialization
        /// </summary>
        [JsonProperty(PropertyName = "@type")]
        public override string JsonType
        {
            get
            {
                return "SSAPBodyErrorMessage";
            }
        }


        private String _thinkp;
        [JsonProperty(PropertyName = "thinkp")]
        public string Thinkp
        {
            get { return _thinkp; }
            set { _thinkp = value; }
        }

        private String _instanciathinkp;
        [JsonProperty(PropertyName = "instanciathinkp")]
        public string Instanciathinkp
        {
            get { return _instanciathinkp; }
            set { _instanciathinkp = value; }
        }

        private String _token;
        [JsonProperty(PropertyName = "token")]
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private String _owner;
        [JsonProperty(PropertyName = "owner")]
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private SSAPSeverityLevel _severity;
        [JsonProperty(PropertyName = "severity")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPSeverityLevel Severity
        {
            get { return _severity; }
            set { _severity = value; }
        }


        private String _code;
        [JsonProperty(PropertyName = "code")]
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private String _message;
        [JsonProperty(PropertyName = "message")]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        private String _timestamp;
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }


        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyErrorMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyErrorMessage>.ToJson(this, fields);
        }

        #endregion Public Methods


        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyErrorMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyErrorMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyErrorMessage> collection)
        {
            return SerializationHelper<SSAPBodyErrorMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyErrorMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyErrorMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyErrorMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyErrorMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyErrorMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyErrorMessage instance</returns>
        public new static SSAPBodyErrorMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyErrorMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyErrorMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyErrorMessage collection</returns>
        public new static ICollection<SSAPBodyErrorMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyErrorMessage>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
