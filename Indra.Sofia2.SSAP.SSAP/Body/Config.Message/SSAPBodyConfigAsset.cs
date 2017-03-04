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

namespace Indra.Sofia2.SSAP.SSAP.Body.Config.Message
{
    public class SSAPBodyConfigAsset
    {
        #region Public Properties

        private string _identificacion;

        public string Identificacion
        {
            get { return _identificacion; }
            set { _identificacion = value; }
        }

        private double _latitud;

        public double Latitud
        {
            get { return _latitud; }
            set { _latitud = value; }
        }

        private double _longitud;

        public double Longitud
        {
            get { return _longitud; }
            set { _longitud = value; }
        }

        private Dictionary<string, string> _propiedades;

        public Dictionary<string, string> Propiedades
        {
            get { return _propiedades; }
            set { _propiedades = value; }
        }

        private Dictionary<string, string> _propiedadesCFG;

        public Dictionary<string, string> PropiedadesCFG
        {
            get { return _propiedadesCFG; }
            set { _propiedadesCFG = value; }
        }

        private bool _isNative;

        public bool IsNative
        {
            get { return _isNative; }
            set { _isNative = value; }
        }

        private string _jsonAssets;

        public string JsonAssets
        {
            get { return _jsonAssets; }
            set { _jsonAssets = value; }
        }
                
        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBodyConfigAsset>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyConfigAsset>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyConfigAsset collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigAsset collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigAsset> collection)
        {
            return SerializationHelper<SSAPBodyConfigAsset>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyConfigAsset collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigAsset collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigAsset> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyConfigAsset>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigAsset instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyConfigAsset instance</returns>
        public static SSAPBodyConfigAsset FromJson(string json)
        {
            return SerializationHelper<SSAPBodyConfigAsset>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigAsset collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyConfigAsset collection</returns>
        public static ICollection<SSAPBodyConfigAsset> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyConfigAsset>>.FromJson(json);
        }

        #endregion Static Methods

    }
}
