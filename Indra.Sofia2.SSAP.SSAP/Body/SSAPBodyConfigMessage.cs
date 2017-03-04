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
using System.Text;
using System.Threading.Tasks;
using Indra.Sofia2.SSAP.SSAP.Body.Config.Message;
using System.Runtime.Serialization;
using Indra.Sofia2.SSAP.Common.Serialization;
using Newtonsoft.Json;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodyConfigMessage : SSAPBodyMessage
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
                return "SSAPBodyConfigMessage";
            }
        }

        private string _kp;

        public string Kp
        {
            get { return _kp; }
            set { _kp = value; }
        }

        private string _instanciaKp;

        public string InstanciaKp
        {
            get { return _instanciaKp; }
            set { _instanciaKp = value; }
        }

        private string _token;

        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private string _assetService;

        public string AssetService
        {
            get { return _assetService; }
            set { _assetService = value; }
        }

        private Dictionary<string, string> _assetServiceParam;

        public Dictionary<string, string> AssetServiceParam
        {
            get { return _assetServiceParam; }
            set { _assetServiceParam = value; }
        }

        private List<SSAPBodyConfigAppsw> _listAppsw;

        public List<SSAPBodyConfigAppsw> ListAppsw
        {
            get { return _listAppsw; }
            set { _listAppsw = value; }
        }

        private List<SSAPBodyConfigAsset> _listAsset;

        public List<SSAPBodyConfigAsset> ListAsset
        {
            get { return _listAsset; }
            set { _listAsset = value; }
        }

        private List<SSAPBodyConfigOntologia> _listOntologia;

        public List<SSAPBodyConfigOntologia> ListOntologia
        {
            get { return _listOntologia; }
            set { _listOntologia = value; }
        }

        private List<ISerializable> _listMisc;

        public List<ISerializable> ListMisc
        {
            get { return _listMisc; }
            set { _listMisc = value; }
        }

        

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyConfigMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyConfigMessage>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyConfigMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigMessage> collection)
        {
            return SerializationHelper<SSAPBodyConfigMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyConfigMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyConfigMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyConfigMessage instance</returns>
        public new static SSAPBodyConfigMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyConfigMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyConfigMessage collection</returns>
        public new static ICollection<SSAPBodyConfigMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyConfigMessage>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
