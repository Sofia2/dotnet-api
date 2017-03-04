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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodyLocationMessage : SSAPBodyMessage
    {
        #region Public Methods

        /// <summary>
        /// Gets type to json serialization
        /// </summary>
        [JsonProperty(PropertyName = "@type")]
        public override string JsonType
        {
            get
            {
                return "SSAPBodyLocationMessage";
            }
        }

        private String _thinkp;
        [JsonProperty(PropertyName = "thinkp")]
        public string Thinkp
        {
            get { return _thinkp; }
            set { _thinkp = value; }
        }

        private string _instanciathinkp;
        [JsonProperty(PropertyName = "instanciathinkp")]
        public string Instanciathinkp
        {
            get { return _instanciathinkp; }
            set { _instanciathinkp = value; }
        }

        private string _token;
        [JsonProperty(PropertyName = "token")]
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private string _owner;
        [JsonProperty(PropertyName = "owner")]
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private double _accuracy;
        [JsonProperty(PropertyName = "accuracy")]
        public double Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }

        private double _lat;
        [JsonProperty(PropertyName = "lat")]
        public double Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }

        private double _lon;
        [JsonProperty(PropertyName = "lon")]
        public double Lon
        {
            get { return _lon; }
            set { _lon = value; }
        }

        private double _alt;
        [JsonProperty(PropertyName = "alt")]
        public double Alt
        {
            get { return _alt; }
            set { _alt = value; }
        }

        private double _bearing;
        [JsonProperty(PropertyName = "bearing")]
        public double Bearing
        {
            get { return _bearing; }
            set { _bearing = value; }
        }

        private double _speed;
        [JsonProperty(PropertyName = "speed")]
        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private string _timestamp;
        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }


        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyLocationMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyLocationMessage>.ToJson(this, fields);
        }

        #endregion Public Methods


        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyLocationMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyLocationMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyLocationMessage> collection)
        {
            return SerializationHelper<SSAPBodyLocationMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyLocationMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyLocationMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyLocationMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyLocationMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyLocationMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyLocationMessage instance</returns>
        public new static SSAPBodyLocationMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyLocationMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyLocationMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyLocationMessage collection</returns>
        public new static ICollection<SSAPBodyLocationMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyLocationMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
