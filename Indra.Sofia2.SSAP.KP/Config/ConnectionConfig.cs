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
using Indra.Sofia2.SSAP.KP.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP.Config
{
    [Serializable]
    public class ConnectionConfig
    {
        private static long SERIAL_VERSION_UID = 1L;

        private const string HOST_CONN_NOT_ESTABLISHED = "Host Connection to SIB not established";
        private const string PORT_CONN_NOT_ESTABLISHED = "Post Connection to SIB not established";

        #region Propiedades Públicas

        private string _hostSIB;

        public string HostSIB
        {
            get { return _hostSIB; }
            set { _hostSIB = value; }
        }

        private int _portSIB;

        public int PortSIB
        {
            get { return _portSIB; }
            set { _portSIB = value; }
        }

        private int _timeOutConnectionSIB = 3000;

        public int TimeOutConnectionSIB
        {
            get { return _timeOutConnectionSIB; }
            set { _timeOutConnectionSIB = value*1000; }
        }

        private int _subscriptionListenersPoolSize;

        public int SubscriptionListenersPoolSize
        {
            get { return _subscriptionListenersPoolSize; }
            set { _subscriptionListenersPoolSize = value; }
        }
        
        #endregion Propiedades Públicas

        #region Constructor

        public ConnectionConfig()
        {
            //Initializations
            this.HostSIB = null;
            this.PortSIB = 0;
            this.TimeOutConnectionSIB = 5000;
            this.SubscriptionListenersPoolSize = 1;           
        }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Validates the configuration
        /// </summary>
        /// <exception cref="ConnectionConfigException">HostSIB or PortSIB are not valid</exception>
        public void ValidateConfig()
        {
            if (this.HostSIB == null)
                throw new ConnectionConfigException(HOST_CONN_NOT_ESTABLISHED);
            if (this.PortSIB == 0)
                throw new ConnectionConfigException(PORT_CONN_NOT_ESTABLISHED);
        }

        #endregion Public Methods
    }
}
