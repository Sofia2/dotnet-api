using Indra.Sofia2.SSAP.SSAP.Body.Bulk.Message;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.SSAP.Body
{
    public class SSAPBodyBulkMessage : SSAPBodyMessage
    {
        private List<SSAPBodyBulkItem> _items = new List<SSAPBodyBulkItem>();
        [JsonProperty(PropertyName = "items")]
        public List<SSAPBodyBulkItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }
            
        public override string JsonType
        {
            get { return "SSAPBodyBulkMessage"; }
        }
    }
}
