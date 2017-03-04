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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP.Implementations.TcpIp.Core
{
    public class ClientMessage
    {

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        private long _timeStamp;

        public long TimeStamp
        {
            get { return _timeStamp; }
            private set { _timeStamp = value; }
        }

        private byte[] _payload;

        public byte[] Payload
        {
            get { return _payload; }
            private set { _payload = value; }
        }
        
        public ClientMessage()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.Now.Ticks;
        }

        public ClientMessage(byte[] payload) : this()
        {
            this.Payload = payload;
        }

        public int GetPayloadSize()
        {
            return Payload==null ?  0: Payload.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id: ");
            sb.Append(this.Id);
            sb.Append(", TimeStamp: ");
            sb.Append(this.TimeStamp);
            sb.Append(", len: ");
            sb.Append(GetPayloadSize());
            sb.Append(", content:\n");
            sb.Append(this.Payload != null ? System.Text.Encoding.UTF8.GetString(this.Payload) : String.Empty);
            return sb.ToString();
        }
    }
}
