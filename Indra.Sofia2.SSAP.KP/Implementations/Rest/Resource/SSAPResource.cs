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
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Indra.Sofia2.SSAP.KP.Implementations.Rest.Resource
{
    [XmlType("ssap")]
    [Serializable]
    //[JsonConverter(typeof(SSAPResourceSerializer))]
    public class SSAPResource
    {
        public enum SSAPVersion { LEVACY, ONE };

        private object data;
        /// <summary>
        /// Gets or Sets Data
        /// </summary>
        [XmlElement("data")]
        [JsonProperty("data", NullValueHandling=NullValueHandling.Ignore)]
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        private string instanceKP;
        [XmlElement("instanceKP")]
        [JsonProperty("instanceKP", NullValueHandling = NullValueHandling.Ignore)]
        public string InstanceKP
        {
            get { return instanceKP; }
            set { instanceKP = value; }
        }

        private bool join;
        [XmlElement("join")]
        [JsonProperty("join", NullValueHandling = NullValueHandling.Ignore)]
        public bool Join
        {
            get { return join; }
            set { join = value; }
        }

        private bool leave;
        [XmlElement("leave")]
        [JsonProperty("leave", NullValueHandling = NullValueHandling.Ignore)]
        public bool Leave
        {
            get { return leave; }
            set { leave = value; }
        }

        private string ontology;
        [XmlElement("ontology")]
        [JsonProperty("ontology", NullValueHandling = NullValueHandling.Ignore)]
        public string Ontology
        {
            get { return ontology; }
            set { ontology = value; }
        }

        private string sessionKey;
        [XmlElement("sessionKey")]
        [JsonProperty("sessionKey", NullValueHandling = NullValueHandling.Ignore)]
        public string SessionKey
        {
            get { return sessionKey; }
            set { sessionKey = value; }
        }

        private string token;
        [XmlElement("token")]
        [JsonProperty("token", NullValueHandling = NullValueHandling.Ignore)]
        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        private SSAPVersion version = SSAPVersion.ONE;
        [XmlElement("version")]
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPVersion Version
        {
            get { return version; }
            set { version = value; }
        }
        
    }
}
