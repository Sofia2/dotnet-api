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
using Indra.Sofia2.SSAP.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Indra.Sofia2.SSAP.KP.Implementations.Rest.Response
{
    [XmlType(TypeName = "update_response")]
    [Serializable]
    public class UpdateResponse : CommonResponse
    {
        private string _ontologiesInstancesIds;

        public string OntologiesInstancesIds
        {
            get { return _ontologiesInstancesIds; }
            set { _ontologiesInstancesIds = value; }
        }

        private int _affectedRecords;

        public int AffectedRecords
        {
            get { return _affectedRecords; }
            set { _affectedRecords = value; }
        }


        /// <summary>
        /// Converts the object in a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return new ToStringBuilder<UpdateResponse>(this)
            .Append(x => x.Ok)
            .Append(x => x.ErrorCode)
            .Append(x => x.Error)
            .Append(x => x.OntologiesInstancesIds)
            .Append(x => x.AffectedRecords)
            .ToString();
        }


    }
}
