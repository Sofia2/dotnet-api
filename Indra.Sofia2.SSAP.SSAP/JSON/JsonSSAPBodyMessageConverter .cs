using Indra.Sofia2.SSAP.SSAP.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Indra.Sofia2.SSAP.SSAP.JSON
{
    class JsonSSAPBodyMessageConverter : JsonCreationConverter<SSAPBodyMessage>
    {
        protected override SSAPBodyMessage Create(Type objectType, JObject jsonObject)
        {
            string type = jsonObject["@type"].Value<String>();
            switch (type)
            {
                case "SSAPBodyReturnMessage":
                    return SSAPBodyReturnMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyConfigMessage":
                    return SSAPBodyConfigMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyJoinMessage":
                    return SSAPBodyJoinMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyJoinTokenMessage":
                    return SSAPBodyJoinMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyJoinUserAndPasswordMessage":
                    return SSAPBodyJoinUserAndPasswordMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyLeaveMessage":
                    return SSAPBodyLeaveMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyMessage":
                    return SSAPBodyMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyOperationMessage":
                    return SSAPBodyOperationMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyQueryMessage":
                    return SSAPBodyQueryMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyQueryWithParamMessage":
                    return SSAPBodyQueryWithParamMessage.FromJson(jsonObject.ToString());
                case "SSAPBodySubscribeMessage":
                    return SSAPBodySubscribeMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyUnsubscribeMessage":
                    return SSAPBodyUnsubscribeMessage.FromJson(jsonObject.ToString());
                case "SSAPBodyLogMessage":
                    return SSAPBodyLogMessage.FromJson(jsonObject.ToString());
                default:
                    return null;
            }
            
        }


        


    }
}
