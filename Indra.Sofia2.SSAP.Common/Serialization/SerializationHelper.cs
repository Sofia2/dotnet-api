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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.Common.Serialization
{
    public static class SerializationHelper<T> 
    {
        public static string ToJson<T>(T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static string ToJson<T>(T obj, List<string> fields)
        {
            DynamicContractResolver contractResolver = new DynamicContractResolver(fields);

            string json = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = contractResolver });
            return json;
        }

        public static string ToJson(ICollection<T> collection)
        {
            var json = JsonConvert.SerializeObject(collection);
            return json;
        }

        public static string ToJson(ICollection<T> collection, List<string> fields)
        {
            DynamicContractResolver contractResolver = new DynamicContractResolver(fields);
            string json = JsonConvert.SerializeObject(collection, Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings { ContractResolver = contractResolver });
            return json;
        }

        public static T FromJson(string json, JsonConverter c)
        {
           
            var obj = JsonConvert.DeserializeObject<T>(json, c);
            return obj;
        }

        public static T FromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        public static ICollection<T> FromJsonArray(string json)
        {
            var obj = JsonConvert.DeserializeObject<ICollection<T>>(json);
            return obj;
        }

    }
}
