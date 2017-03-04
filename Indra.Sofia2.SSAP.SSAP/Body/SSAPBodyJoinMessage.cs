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
    public class SSAPBodyJoinMessage : SSAPBodyMessage
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
                return "SSAPBodyJoinMessage";
            }
        }

        private string _instance;
        /// <summary>
        /// Gets or sets logged device info
        /// </summary>
        [JsonProperty(PropertyName = "instance")]
        public string Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyJoinMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyJoinMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyJoinMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyJoinMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyJoinMessage> collection)
        {
            return SerializationHelper<SSAPBodyJoinMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyJoinMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyJoinMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyJoinMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyJoinMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyJoinMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyJoinMessage instance</returns>
        public new static SSAPBodyJoinMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyJoinMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyJoinMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyJoinMessage collection</returns>
        public new static ICollection<SSAPBodyJoinMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyJoinMessage>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
