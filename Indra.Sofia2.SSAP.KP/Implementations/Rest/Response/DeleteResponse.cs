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
    [XmlType(TypeName = "delete_response")]
    [Serializable]
    public class DeleteResponse : CommonResponse
    {
        private string _ontologiesInstancesIds;

        public string OntologiesInstancesIds
        {
            get { return _ontologiesInstancesIds; }
            set { _ontologiesInstancesIds = value; }
        }

        private int _affectedRecords;

        public int AffectedRecords
        {
            get { return _affectedRecords; }
            set { _affectedRecords = value; }
        }

        #region Public Methods

        /// <summary>
        /// Converts the object in a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return new ToStringBuilder<DeleteResponse>(this)
            .Append(x => x.Ok)
            .Append(x => x.ErrorCode)
            .Append(x => x.Error)
            .Append(x => x.OntologiesInstancesIds)
            .Append(x => x.AffectedRecords)
            .ToString();
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<DeleteResponse>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<DeleteResponse>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a DeleteResponse collection in a Json string
        /// </summary>
        /// <param name="collection">DeleteResponse collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<DeleteResponse> collection)
        {
            return SerializationHelper<DeleteResponse>.ToJson(collection);
        }

        /// <summary>
        /// Converts a DeleteResponse collection in a Json string
        /// </summary>
        /// <param name="collection">DeleteResponse collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<DeleteResponse> collection, List<string> fields)
        {
            return SerializationHelper<DeleteResponse>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a DeleteResponse instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A DeleteResponse instance</returns>
        public static DeleteResponse FromJson(string json)
        {
            return SerializationHelper<DeleteResponse>.FromJson(json);
        }

        /// <summary>
        /// Creates a DeleteResponse collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>DeleteResponse collection</returns>
        public static ICollection<DeleteResponse> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<DeleteResponse>>.FromJson(json);
        }

        #endregion Static Methods

        
    }
}
