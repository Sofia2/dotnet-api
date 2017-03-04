using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP.Implementations.WebSocket
{ 
    public class WebSocketConnectionConfig : Config.ConnectionConfig
    {
        #region Private properties

        private string _endpointUri;
        public string EnpointUri
        {
            get { return _endpointUri; }
            set { _endpointUri = value;  }
        }

        private Int32 _keepAliveInSeconds = 3000;
        public Int32 KeepAliveInSeconds
        {
            get { return _keepAliveInSeconds;  }
            set { _keepAliveInSeconds = value; }
        }



        #endregion Private poperties

    }
}
