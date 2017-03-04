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
using Indra.Sofia2.SSAP.SSAP;
using Indra.Sofia2.SSAP.SSAP.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP
{
    /// <summary>
    /// Interfaz para recibir las notificaciones de suscripciones del Sib
    /// </summary>
    public interface IListener4SIBIndicationNotifications
    {
        /// <summary>
        /// </summary>
        /// <param name="idNotifition">Notification Id</param>
        /// <param name="message">Message</param>
        void OnIndication(String idNotifition, SSAPMessage<SSAPBodyMessage> message);
    }
}
