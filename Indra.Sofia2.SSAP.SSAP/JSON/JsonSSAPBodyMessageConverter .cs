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
