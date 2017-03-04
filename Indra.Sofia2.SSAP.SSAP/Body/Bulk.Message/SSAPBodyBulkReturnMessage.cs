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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message
{
    public class SSAPBodyBulkReturnMessage : SSAPBodyReturnMessage
    {
        #region Public Properties

        private SSAPBulkOperationSummary _insertSummary = new SSAPBulkOperationSummary();
        /// <summary>
        /// Gets or sets the insert summary
        /// </summary>
        public SSAPBulkOperationSummary InsertSummary
        {
            get { return _insertSummary; }
            set { _insertSummary = value; }
        }

        private SSAPBulkOperationSummary _updateSummary = new SSAPBulkOperationSummary();
        /// <summary>
        /// Gets or sets the update summary
        /// </summary>
        public SSAPBulkOperationSummary UpdateSummary
        {
            get { return _updateSummary; }
            set { _updateSummary = value; }
        }

        private SSAPBulkOperationSummary _deleteSummary = new SSAPBulkOperationSummary();
        /// <summary>
        /// Gets or sets the delete summary
        /// </summary>
        public SSAPBulkOperationSummary DeleteSummary
        {
            get { return _deleteSummary; }
            set { _deleteSummary = value; }
        }
        
        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBodyBulkReturnMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyBulkReturnMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyBulkReturnMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyBulkReturnMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyBulkReturnMessage> collection)
        {
            return SerializationHelper<SSAPBodyBulkReturnMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyBulkReturnMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyBulkReturnMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyBulkReturnMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyBulkReturnMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyBulkReturnMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyBulkReturnMessage instance</returns>
        public static SSAPBodyBulkReturnMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyBulkReturnMessage>.FromJson(json, new JsonSSAPBodyBulkReturnMessageConverter());
            //return SerializationHelper<SSAPBodyBulkReturnMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyBulkReturnMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyBulkReturnMessage collection</returns>
        public static ICollection<SSAPBodyBulkReturnMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyBulkReturnMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
