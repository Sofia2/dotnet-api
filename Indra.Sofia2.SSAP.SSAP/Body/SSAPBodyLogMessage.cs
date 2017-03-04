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
    public class SSAPBodyLogMessage : SSAPBodyMessage
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
                return "SSAPBodyLogMessage";
            }
        }

        private String _thinkp;
        [JsonProperty(PropertyName = "thinkp")]
        public string Thinkp
        {
            get { return _thinkp;  }
            set { _thinkp = value;  }
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

        private SSAPLogLevel _level;
        [JsonProperty(PropertyName = "level")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPLogLevel Level
        {
            get { return _level; }
            set { _level = value; }
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
            return SerializationHelper<SSAPBodyLogMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyLogMessage>.ToJson(this, fields);
        }

        #endregion Public Methods


        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyLogMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyLogMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyLogMessage> collection)
        {
            return SerializationHelper<SSAPBodyLogMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyLogMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyLogMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyLogMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyLogMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyLogMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyLogMessage instance</returns>
        public new static SSAPBodyLogMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyLogMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyLogMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyLogMessage collection</returns>
        public new static ICollection<SSAPBodyLogMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyLogMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
