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
