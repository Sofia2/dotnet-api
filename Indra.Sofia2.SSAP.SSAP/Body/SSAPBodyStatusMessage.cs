using Indra.Sofia2.SSAP.Common.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodyStatusMessage : SSAPBodyMessage
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
                return "SSAPBodyStatusMessage";
            }
        }

        private string _thinkp;
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

        private Dictionary<string, string> _status;
        [JsonProperty(PropertyName = "status")]
        public Dictionary<string, string> Status
        {
            get { return _status; }
            set { _status = value; }
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
            return SerializationHelper<SSAPBodyStatusMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyStatusMessage>.ToJson(this, fields);
        }

        #endregion Public Methods


        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyStatusMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyStatusMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyStatusMessage> collection)
        {
            return SerializationHelper<SSAPBodyStatusMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyStatusMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyStatusMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyStatusMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyStatusMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyStatusMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyStatusMessage instance</returns>
        public new static SSAPBodyStatusMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyStatusMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyStatusMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyStatusMessage collection</returns>
        public new static ICollection<SSAPBodyStatusMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyStatusMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
