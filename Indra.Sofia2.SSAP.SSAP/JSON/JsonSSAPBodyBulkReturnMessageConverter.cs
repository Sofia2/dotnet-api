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

using Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Indra.Sofia2.SSAP.SSAP.JSON
{
    public class JsonSSAPBodyBulkReturnMessageConverter : JsonCreationConverter<SSAPBodyBulkReturnMessage>
    {
        protected override SSAPBodyBulkReturnMessage Create(Type objectType, JObject jsonObject)
        {
            SSAPBodyBulkReturnMessage ret = new SSAPBodyBulkReturnMessage();
            if (jsonObject["updateSummary"].Count() > 0)
            {
                foreach (string oidList in jsonObject["updateSummary"]["objectIds"])
                {
                    ret.UpdateSummary.ObjectsIds.Add(oidList);
                }
                foreach (var item in jsonObject["updateSummary"]["errors"].Children())
                {
                    SSAPBulkOperationErrorSummary summary = new SSAPBulkOperationErrorSummary();
                    summary.RequestBody = item["requestBody"].ToString();
                    summary.ResponseBody = item["responseBody"].ToString();
                    var itemProperties = item.Children<JProperty>();

                    ret.UpdateSummary.Errors.Add(summary);
                }
            }
            if (jsonObject["insertSummary"].Count() > 0)
            {
                foreach (var item in jsonObject["insertSummary"]["objectIds"].Children())
                {
                    //var itemProperties = item.Children<JProperty>();
                    ret.InsertSummary.ObjectsIds.Add(item.ToString());
                }
                foreach (var item in jsonObject["insertSummary"]["errors"].Children())
                {
                    SSAPBulkOperationErrorSummary summary = new SSAPBulkOperationErrorSummary();
                    summary.RequestBody = item["requestBody"].ToString();
                    summary.ResponseBody = item["responseBody"].ToString();
                    var itemProperties = item.Children<JProperty>();

                    ret.InsertSummary.Errors.Add(summary);
                }
            }
            if (jsonObject["deleteSummary"].Count() > 0)
            {
                foreach (string oidList in jsonObject["deleteSummary"]["objectIds"])
                {
                    ret.DeleteSummary.ObjectsIds.Add(oidList);
                }
                foreach (var item in jsonObject["deleteSummary"]["errors"].Children())
                {
                    SSAPBulkOperationErrorSummary summary = new SSAPBulkOperationErrorSummary();
                    summary.RequestBody = item["requestBody"].ToString();
                    summary.ResponseBody = item["responseBody"].ToString();
                    var itemProperties = item.Children<JProperty>();

                    ret.DeleteSummary.Errors.Add(summary);
                }
            }
            return ret;
        }
    }
}
