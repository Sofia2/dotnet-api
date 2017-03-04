using Indra.Sofia2.SSAP.Common.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodySubscribeCommandMessage : SSAPBodyMessage
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
                return "SSAPBodySubscribeCommandMessage";
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

        private string _token;
        [JsonProperty(PropertyName = "token")]
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private SSAPCommandType _type;
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPCommandType Type
        {
            get { return _type; }
            set { _type = value; }
        }



        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodySubscribeCommandMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodySubscribeCommandMessage>.ToJson(this, fields);
        }

        #endregion Public Methods


        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodySubscribeCommandMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodySubscribeCommandMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodySubscribeCommandMessage> collection)
        {
            return SerializationHelper<SSAPBodySubscribeCommandMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodySubscribeCommandMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodySubscribeCommandMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodySubscribeCommandMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodySubscribeCommandMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodySubscribeCommandMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodySubscribeCommandMessage instance</returns>
        public new static SSAPBodySubscribeCommandMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodySubscribeCommandMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodySubscribeCommandMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodySubscribeCommandMessage collection</returns>
        public new static ICollection<SSAPBodySubscribeCommandMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodySubscribeCommandMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
