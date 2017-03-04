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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP.Implementations.TcpIp.Core
{
    /// <summary>
    /// This class is responsible for detecting a SSAP message from the received string
    /// of bytes. A SSAP message starts with the tag <SSAP_message> and
    /// ends with </SSAP_message>
    /// </summary>
    public class SSAPMessageParser : ClientConnectionAttachment
    {
        #region Const

        private const String START_TOKEN = "<TCP_JSON>";
	    private const String END_TOKEN = "</TCP_JSON>";

        #endregion Const

        #region Private vars

        private List<int> _indexes = new List<int>();

        #endregion Private vars

        #region Consructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SSAPMessageParser()
        {

        }

        #endregion Constructor

        #region Public Methods

        public override int[] ParseMessages(byte[] buffer)
        {
            _indexes.Clear();
            MemoryStream stream = new MemoryStream(buffer);
            StreamReader reader = new StreamReader(stream);
            string s = reader.ReadToEnd().ToUpper();
            int startPos = s.IndexOf(START_TOKEN);
            int finishPos = 0;
            while (startPos >= 0)
            {
                finishPos = s.IndexOf(END_TOKEN, startPos);
                if (finishPos >= 0)
                {
                    _indexes.Add(startPos);
                    _indexes.Add(finishPos + END_TOKEN.Length -1);
                }
                startPos = s.IndexOf(START_TOKEN, finishPos);
            }
            if (_indexes.Any())
            {
                return _indexes.ToArray();
            }
            else
                 return null;
        }

        #endregion Public Methods
    }
}
