using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP.Implementations.Rest.Resource
{
    class SSAPResourceSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            jsonObject.SelectToken("data");
            jsonObject.SelectToken("instanceKP");
            jsonObject.SelectToken("join");
            jsonObject.SelectToken("leave");
            jsonObject.SelectToken("ontology");
            jsonObject.SelectToken("sessionKey");
            jsonObject.SelectToken("token");
            jsonObject.SelectToken("token");

            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
           
            SSAPResource resource = value as SSAPResource;
            writer.WriteStartObject();
            writer.WritePropertyName("data");
            writer.WriteValue(resource.Data);
            writer.WritePropertyName("instanceKP");
            writer.WriteValue(resource.InstanceKP);
            writer.WritePropertyName("join");
            writer.WriteValue(resource.Join);
            writer.WritePropertyName("leave");
            writer.WriteValue(resource.Leave);
            writer.WritePropertyName("ontology");
            writer.WriteValue(resource.Ontology);
            writer.WritePropertyName("sessionKey");
            writer.WriteValue(resource.SessionKey);
            writer.WritePropertyName("token");
            writer.WriteValue(resource.Token);
            writer.WritePropertyName("version");
            writer.WriteValue(resource.Version);

            writer.WriteEndObject();
            
            //String json = JsonConvert.SerializeObject(resource);
            //writer.WriteRaw(json);
        }
}
}
