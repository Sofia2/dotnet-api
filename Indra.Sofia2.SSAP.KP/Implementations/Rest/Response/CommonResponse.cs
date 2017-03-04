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
using Indra.Sofia2.SSAP.SSAP;

namespace Indra.Sofia2.SSAP.KP.Implementations.Rest.Response
{
    [Serializable]
    public class CommonResponse
    {
        private bool _ok;
        /// <summary>
        /// Gets or sets the operation succesfull
        /// </summary>
        public bool Ok
        {
            get { return _ok; }
            set { _ok = value; }
        }

        private string _error;
        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        private SSAPErrorCodeEnum _errorCode;

        public SSAPErrorCodeEnum ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
        
    }
}
