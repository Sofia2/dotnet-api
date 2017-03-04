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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Indra.Sofia2.SSAP.KP.Implementations.Rest.Response
{
    [XmlType(TypeName = "join_response")]
    [Serializable]
    public class JoinResponse : CommonResponse
    {
        private string _sessionkey;
        /// <summary>
        /// Gets or Sets the session key value
        /// </summary>
        public string SessionKey
        {
            get { return _sessionkey; }
            set { _sessionkey = value; }
        }

        #region Public Methods

        /// <summary>
        /// Converts the object in a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return new ToStringBuilder<JoinResponse>(this)
            .Append(x => x.Ok)
            .Append(x => x.ErrorCode)
            .Append(x => x.Error)
            .Append(x => x.SessionKey)
            .ToString();
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<JoinResponse>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<JoinResponse>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a JoinResponse collection in a Json string
        /// </summary>
        /// <param name="collection">JoinResponse collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<JoinResponse> collection)
        {
            return SerializationHelper<JoinResponse>.ToJson(collection);
        }

        /// <summary>
        /// Converts a JoinResponse collection in a Json string
        /// </summary>
        /// <param name="collection">JoinResponse collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<JoinResponse> collection, List<string> fields)
        {
            return SerializationHelper<JoinResponse>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a JoinResponse instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A JoinResponse instance</returns>
        public static JoinResponse FromJson(string json)
        {
            return SerializationHelper<JoinResponse>.FromJson(json);
        }

        /// <summary>
        /// Creates a JoinResponse collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>JoinResponse collection</returns>
        public static ICollection<JoinResponse> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<JoinResponse>>.FromJson(json);
        }

        #endregion Static Methods


    }
}
