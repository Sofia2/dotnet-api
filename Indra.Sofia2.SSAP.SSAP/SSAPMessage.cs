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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Indra.Sofia2.SSAP.Common.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Indra.Sofia2.SSAP.SSAP.Body;
using Indra.Sofia2.SSAP.SSAP.JSON;
using Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message;

namespace Indra.Sofia2.SSAP.SSAP
{
    public class SSAPMessage<T> where T : SSAPBodyMessage
    {
        #region Constantes

        private const long SERIAL_VERSION_UID = 1L;

        #endregion Constantes

        #region Propiedades Públicas

        private string _messageId;
        /// <summary>
        /// Gets or Sets the unique message Id.
        /// </summary>
        [JsonProperty(PropertyName = "messageId")]
        public string MessageId
        {
            get { return _messageId; }
            set { _messageId = value; }
        }

        private string _sessionKey;
        /// <summary>
        /// Gets or sets the SIB session Id 
        /// </summary>

        [JsonProperty(PropertyName = "sessionKey")]
        public string SessionKey
        {
            get { return _sessionKey; }
            set { _sessionKey = value; }
        }

        private string _ontology;
        /// <summary>
        /// Gets or sets the ontology 
        /// </summary>
         
        [JsonProperty(PropertyName = "ontology")]
        public string Ontology
        {
            get { return _ontology; }
            set { _ontology = value; }
        }

        private SSAPMessageDirectionEnum _direction;
        /// <summary>
        /// Gets or sets the message direction
        /// </summary>

        [JsonProperty(PropertyName = "direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPMessageDirectionEnum Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        
        private SSAPMessageTypesEnum _messageType;
        /// <summary>
        /// Gets or sets the Message type
        /// </summary>

        [JsonProperty(PropertyName = "messageType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPMessageTypesEnum MessageType
	    {
		    get { return _messageType;}
		    set { _messageType = value;}
	    }

        private T _body;
        /// <summary>
        /// Gets or sets the body message
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public T Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _version = "ONE";
        /// <summary>
        /// Gets or sets the body message
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        /// <summary>
        /// Gets the serial version Id.
        /// </summary>
        public static long SerialVersionUID
        {
            get { return SERIAL_VERSION_UID; }
        }

        #endregion Propiedades Públicas

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPMessage<SSAPBodyMessage>>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPMessage<SSAPBodyMessage>>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPMessage<SSAPBodyMessage>> collection)
        {
            return SerializationHelper<SSAPMessage<SSAPBodyMessage>>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPMessage<SSAPBodyMessage>> collection, List<string> fields)
        {
            return SerializationHelper<SSAPMessage<SSAPBodyMessage>>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPMessage instance</returns>
        public static SSAPMessage<T>FromJson<T>(string json) where T : SSAPBodyMessage
        {
            return SerializationHelper<SSAPMessage<T>>.FromJson(json, new JsonSSAPBodyMessageConverter());
        }

        /// <summary>
        /// Creates a SSAPMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPMessage collection</returns>
        public static ICollection<SSAPMessage<SSAPBodyMessage>> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPMessage<SSAPBodyMessage>>>.FromJson(json);
        }
        
        #endregion Static Methods
    }
}
