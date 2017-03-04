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


namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodyUnsubscribeMessage : SSAPBodyMessage
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
                return "SSAPBodyUnsubscribeMessage";
            }
        }

        private string _idSuscripcion;
        /// <summary>
        /// Obtiene o establece el Id de suscripción
        /// </summary>
        [JsonProperty(PropertyName = "idSuscripcion")]
        public string IdSuscripcion
        {
            get { return _idSuscripcion; }
            set { _idSuscripcion = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyUnsubscribeMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyUnsubscribeMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyUnsubscribeMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyUnsubscribeMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyUnsubscribeMessage> collection)
        {
            return SerializationHelper<SSAPBodyUnsubscribeMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyUnsubscribeMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyUnsubscribeMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyUnsubscribeMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyUnsubscribeMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyUnsubscribeMessage instance</returns>
        public static new SSAPBodyUnsubscribeMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyUnsubscribeMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyUnsubscribeMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyUnsubscribeMessage collection</returns>
        public static new ICollection<SSAPBodyUnsubscribeMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyUnsubscribeMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
