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
    public class SSAPBodyConfigOntologia
    {
        #region Public Properties

        private string _identificacion;

        public string Identificacion
        {
            get { return _identificacion; }
            set { _identificacion = value; }
        }

        private string _esquemaJSON;

        public string EsquemaJSON
        {
            get { return _esquemaJSON; }
            set { _esquemaJSON = value; }
        }

        private string _tipoPermiso;

        public string TipoPermiso
        {
            get { return _tipoPermiso; }
            set { _tipoPermiso = value; }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBodyConfigOntologia>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyConfigOntologia>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyConfigOntologia collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigOntologia collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigOntologia> collection)
        {
            return SerializationHelper<SSAPBodyConfigOntologia>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyConfigOntologia collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigOntologia collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigOntologia> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyConfigOntologia>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigOntologia instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyConfigOntologia instance</returns>
        public static SSAPBodyConfigOntologia FromJson(string json)
        {
            return SerializationHelper<SSAPBodyConfigOntologia>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigOntologia collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyConfigOntologia collection</returns>
        public static ICollection<SSAPBodyConfigOntologia> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyConfigOntologia>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
