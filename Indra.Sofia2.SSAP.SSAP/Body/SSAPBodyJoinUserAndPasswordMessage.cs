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
    public class SSAPBodyJoinUserAndPasswordMessage : SSAPBodyJoinMessage
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
                return "SSAPBodyJoinUserAndPasswordMessage";
            }
        }

        private string _user;
        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _password;
        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }        

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyJoinUserAndPasswordMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyJoinUserAndPasswordMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyJoinUserAndPasswordMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyJoinUserAndPasswordMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyJoinUserAndPasswordMessage> collection)
        {
            return SerializationHelper<SSAPBodyJoinUserAndPasswordMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyJoinUserAndPasswordMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyJoinUserAndPasswordMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyJoinUserAndPasswordMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyJoinUserAndPasswordMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyJoinUserAndPasswordMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyJoinUserAndPasswordMessage instance</returns>
        public new static SSAPBodyJoinUserAndPasswordMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyJoinUserAndPasswordMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyJoinUserAndPasswordMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyJoinUserAndPasswordMessage collection</returns>
        public new static ICollection<SSAPBodyJoinUserAndPasswordMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyJoinUserAndPasswordMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
