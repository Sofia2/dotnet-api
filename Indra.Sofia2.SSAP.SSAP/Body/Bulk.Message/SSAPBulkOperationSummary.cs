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
    public class SSAPBulkOperationSummary
    {
        #region Public Properties

        private List<string> _objectsIds = new List<string>();
        /// <summary>
        /// Gets or sets a list of objects Ids.
        /// </summary>
        public List<string> ObjectsIds
        {
            get { return _objectsIds; }
            set { _objectsIds = value; }
        }

        private List<SSAPBulkOperationErrorSummary> _errors = new List<SSAPBulkOperationErrorSummary>();
        /// <summary>
        /// Gets or sets a list of errors
        /// </summary>
        public List<SSAPBulkOperationErrorSummary> Errors
        {
            get { return _errors; }
            set { _errors = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBulkOperationSummary>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBulkOperationSummary>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBulkOperationSummary collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBulkOperationSummary collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBulkOperationSummary> collection)
        {
            return SerializationHelper<SSAPBulkOperationSummary>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBulkOperationSummary collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBulkOperationSummary collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBulkOperationSummary> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBulkOperationSummary>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBulkOperationSummary instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBulkOperationSummary instance</returns>
        public static SSAPBulkOperationSummary FromJson(string json)
        {
            return SerializationHelper<SSAPBulkOperationSummary>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBulkOperationSummary collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBulkOperationSummary collection</returns>
        public static ICollection<SSAPBulkOperationSummary> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBulkOperationSummary>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
