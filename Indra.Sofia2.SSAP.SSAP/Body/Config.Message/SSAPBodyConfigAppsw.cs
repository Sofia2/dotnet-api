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
    public class SSAPBodyConfigAppsw
    {
        #region Public Properties
        private string _identificacion;

        public string Identificacion
        {
            get { return _identificacion; }
            set { _identificacion = value; }
        }

        private int _versionSW;

        public int VersionSW
        {
            get { return _versionSW; }
            set { _versionSW = value; }
        }

        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private int _versionCFG;

        public int VersionCFG
        {
            get { return _versionCFG; }
            set { _versionCFG = value; }
        }

        private Dictionary<string, string> _propiedadesCFG;

        public Dictionary<string, string> PropiedadesCFG
        {
            get { return _propiedadesCFG; }
            set { _propiedadesCFG = value; }
        }
        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public string ToJson()
        {
            return SerializationHelper<SSAPBodyConfigAppsw>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyConfigAppsw>.ToJson(this, fields);
        }

        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyConfigAppsw collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigAppsw collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigAppsw> collection)
        {
            return SerializationHelper<SSAPBodyConfigAppsw>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyConfigAppsw collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyConfigAppsw collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyConfigAppsw> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyConfigAppsw>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigAppsw instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyConfigAppsw instance</returns>
        public static SSAPBodyConfigAppsw FromJson(string json)
        {
            return SerializationHelper<SSAPBodyConfigAppsw>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyConfigAppsw collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyConfigAppsw collection</returns>
        public static ICollection<SSAPBodyConfigAppsw> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyConfigAppsw>>.FromJson(json);
        }

        #endregion Static Methods
        
    }
}
