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
    public class SSAPBodyReturnMessage : SSAPBodyMessage
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
                return "SSAPBodyReturnMessage";
            }
        }

        private bool _isOk;
        /// <summary>
        /// Gets or set the value that indicates the exexution result
        /// </summary>
        [JsonProperty("ok", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOk
        {
            get { return _isOk; }
            set { _isOk = value; }
        }

        private string _error;
        /// <summary>
        /// Gets or sets the error string
        /// </summary>
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private SSAPErrorCodeEnum _errorCode;
        /// <summary>
        /// Gets or sets the error code
        /// </summary>
        [JsonProperty("errorCode", NullValueHandling = NullValueHandling.Ignore)]
        public SSAPErrorCodeEnum ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }     

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBodyReturnMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyReturnMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyReturnMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyReturnMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyReturnMessage> collection)
        {
            return SerializationHelper<SSAPBodyReturnMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyReturnMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyReturnMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyReturnMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyReturnMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyReturnMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyReturnMessage instance</returns>
        public static SSAPBodyReturnMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyReturnMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyReturnMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyReturnMessage collection</returns>
        public static ICollection<SSAPBodyReturnMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyReturnMessage>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
