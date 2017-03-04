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
    [XmlType(TypeName = "insert_response")]
    [Serializable]
    public class InsertResponse : CommonResponse
    {
        private string _ontologyInstanceId;

        public string OntologyInstanceId
        {
            get { return _ontologyInstanceId; }
            set { _ontologyInstanceId = value; }
        }

        #region Public Methods

        /// <summary>
        /// Converts the object in a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return new ToStringBuilder<InsertResponse>(this)
            .Append(x => x.Ok)
            .Append(x => x.ErrorCode)
            .Append(x => x.Error)
            .Append(x => x.OntologyInstanceId)
            .ToString();
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<InsertResponse>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<InsertResponse>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a InsertResponse collection in a Json string
        /// </summary>
        /// <param name="collection">InsertResponse collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<InsertResponse> collection)
        {
            return SerializationHelper<InsertResponse>.ToJson(collection);
        }

        /// <summary>
        /// Converts a InsertResponse collection in a Json string
        /// </summary>
        /// <param name="collection">InsertResponse collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<InsertResponse> collection, List<string> fields)
        {
            return SerializationHelper<InsertResponse>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a InsertResponse instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A InsertResponse instance</returns>
        public static InsertResponse FromJson(string json)
        {
            return SerializationHelper<InsertResponse>.FromJson(json);
        }

        /// <summary>
        /// Creates a InsertResponse collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>InsertResponse collection</returns>
        public static ICollection<InsertResponse> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<InsertResponse>>.FromJson(json);
        }

        #endregion Static Methods


    }
}
