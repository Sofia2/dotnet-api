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
    [XmlType(TypeName = "config_response")]
    [Serializable]
    public class ConfigResponse : CommonResponse
    {
        private string _results;
        /// <summary>
        /// Gets or sets configuration software
        /// </summary>
        public string Results
        {
            get { return _results; }
            set { _results = value; }
        }

        #region Public Methods

        /// <summary>
        /// Converts the object in a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return new ToStringBuilder<ConfigResponse>(this)
            .Append(x => x.Ok)            
            .Append(x => x.Results)
            .Append(x => x.ErrorCode)
            .Append(x => x.Error)            
            .ToString();
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<ConfigResponse>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<ConfigResponse>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a ConfigResponse collection in a Json string
        /// </summary>
        /// <param name="collection">ConfigResponse collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<ConfigResponse> collection)
        {
            return SerializationHelper<ConfigResponse>.ToJson(collection);
        }

        /// <summary>
        /// Converts a ConfigResponse collection in a Json string
        /// </summary>
        /// <param name="collection">ConfigResponse collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<ConfigResponse> collection, List<string> fields)
        {
            return SerializationHelper<ConfigResponse>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a ConfigResponse instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A ConfigResponse instance</returns>
        public static ConfigResponse FromJson(string json)
        {
            return SerializationHelper<ConfigResponse>.FromJson(json);
        }

        /// <summary>
        /// Creates a ConfigResponse collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>ConfigResponse collection</returns>
        public static ICollection<ConfigResponse> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<ConfigResponse>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
