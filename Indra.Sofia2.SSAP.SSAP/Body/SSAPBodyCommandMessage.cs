using Indra.Sofia2.SSAP.Common.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodyCommandMessage : SSAPBodyMessage
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
                return "SSAPBodyCommandMessage";
            }
        }
        
        private string _thinkp;
        [JsonProperty(PropertyName = "thinkp")]
        public string Thinkp
        {
            get { return _thinkp; }
            set { _thinkp = value; }
        }

        private string _thinkpInstance;
        [JsonProperty(PropertyName = "thinkpInstance")]
        public string ThinkpInstance
        {
            get { return _thinkpInstance; }
            set { _thinkpInstance = value; }
        }

        private SSAPCommandType _type;
        [JsonProperty(PropertyName = "type")]
        public SSAPCommandType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private Dictionary<String, String> _args;
        [JsonProperty(PropertyName = "args")]
        public Dictionary<String, String> Args
        {
            get { return _args; }
            set { _args = value; }
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyCommandMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyCommandMessage>.ToJson(this, fields);
        }

        #endregion Public Methods


        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyCommandMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyCommandMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyCommandMessage> collection)
        {
            return SerializationHelper<SSAPBodyCommandMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyCommandMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyCommandMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyCommandMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyCommandMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyCommandMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyCommandMessage instance</returns>
        public new static SSAPBodyCommandMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyCommandMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyCommandMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyCommandMessage collection</returns>
        public new static ICollection<SSAPBodyCommandMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyCommandMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
