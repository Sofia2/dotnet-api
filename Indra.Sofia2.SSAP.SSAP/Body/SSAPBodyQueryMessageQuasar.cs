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
    public class SSAPBodyQueryMessageQuasar : SSAPBodyQueryMessage
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
                return "SSAPBodyQueryMessageQuasar";
            }
        }

        private int _offset = 0;
        [JsonProperty(PropertyName = "offset")]
        public int Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }


        private SSAPQueryResultFormat _resultFormat = SSAPQueryResultFormat.JSON;
        [JsonProperty(PropertyName = "resultFormat")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SSAPQueryResultFormat ResultFormat
        {
            get { return _resultFormat; }
            set { _resultFormat = value;  }
        }

        private string _formatter = null;
        [JsonProperty(PropertyName = "formatter")]
        public string Formatter
        {
            get { return _formatter; }
            set { _formatter = value;  }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <returns>Json string</returns>
        public new string ToJson()
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(this);
        }

        /// <summary>
        /// Converts this object in a Json string.
        /// </summary>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public new string ToJson(List<String> fields)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(this, fields);
        }


        
        
        
        #endregion Public Methods

        #region Static Methods

        /// <summary>
        /// Converts a SSAPBodyQueryMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyQueryMessage collection</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyQueryMessage> collection)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(collection);
        }

        /// <summary>
        /// Converts a SSAPBodyQueryMessage collection in a Json string
        /// </summary>
        /// <param name="collection">SSAPBodyQueryMessage collection</param>
        /// <param name="fields">Fields to serialize</param>
        /// <returns>Json string</returns>
        public static string ToJson(ICollection<SSAPBodyQueryMessage> collection, List<string> fields)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.ToJson(collection, fields);
        }

        /// <summary>
        /// Creates a SSAPBodyQueryMessage instance with the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>A SSAPBodyQueryMessage instance</returns>
        public new static SSAPBodyQueryMessage FromJson(string json)
        {
            return SerializationHelper<SSAPBodyQueryMessage>.FromJson(json);
        }

        /// <summary>
        /// Creates a SSAPBodyQueryMessage collection from the given json string.
        /// </summary>
        /// <param name="json">Json string</param>
        /// <returns>SSAPBodyQueryMessage collection</returns>
        public new static ICollection<SSAPBodyQueryMessage> FromJsonArray(string json)
        {
            return SerializationHelper<ICollection<SSAPBodyQueryMessage>>.FromJson(json);
        }

        #endregion Static Methods
    }
}
