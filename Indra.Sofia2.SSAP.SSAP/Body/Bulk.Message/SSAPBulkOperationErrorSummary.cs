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

namespace Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message
{
    public class SSAPBulkOperationErrorSummary
    {
        #region Public Properties

        private string _requestBody;
        /// <summary>
        /// Gets or sets the request body
        /// </summary>
        public string RequestBody
        {
            get { return _requestBody; }
            set { _requestBody = value; }
        }

        private string _responseBody;
        /// <summary>
        /// Gets or sets the response body
        /// </summary>
        public string ResponseBody
        {
            get { return _responseBody; }
            set { _responseBody = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBulkOperationErrorSummary>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBulkOperationErrorSummary>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBulkOperationErrorSummary collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBulkOperationErrorSummary collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBulkOperationErrorSummary> collection)
        {
            return SerializationHelper<SSAPBulkOperationErrorSummary>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBulkOperationErrorSummary collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBulkOperationErrorSummary collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBulkOperationErrorSummary> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBulkOperationErrorSummary>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBulkOperationErrorSummary instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBulkOperationErrorSummary instance</returns>
        public static SSAPBulkOperationErrorSummary FromJson(string json)
        {
            return SerializationHelper<SSAPBulkOperationErrorSummary>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBulkOperationErrorSummary collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBulkOperationErrorSummary collection</returns>
        public static ICollection<SSAPBulkOperationErrorSummary> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBulkOperationErrorSummary>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
