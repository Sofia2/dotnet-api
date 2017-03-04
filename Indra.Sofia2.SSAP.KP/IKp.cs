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
using Indra.Sofia2.SSAP.KP.Config;
using Indra.Sofia2.SSAP.SSAP;
using Indra.Sofia2.SSAP.SSAP.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP
{
    public interface IKp
    {
        /// <summary>
        /// Gets if it is connected to SIB
        /// </summary>
        /// <returns>True, if it is connected. False, otherwise</returns>
        bool IsConnected();

        /// <summary>
        /// Gets the session key if it is connected to SIB
        /// </summary>
        /// <returns>Session key if it is connected to SIB. Null, otherwise</returns>
        string GetSessionKey();

        /// <summary>
        /// Connects with the SIB
        /// </summary>
        /// <exception cref="ConnectionToSibException">It throws ConnectionToSibException
        /// with the connection error when there is no connection</exception>
        void Connect();

        /// <summary>
        /// Disconnects from the SIB
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Sets the connection configuration parameters
        /// </summary>
        /// <param name="config">Connection configuration parameters</param>
        void SetConnectionConfig(ConnectionConfig config);

        /// <summary>
        /// Sets Xxtea Cipher key
        /// </summary>
        /// <param name="cipherKey">Xxtea Cipher Key</param>
        void SetXxteaCipherKey(string cipherKey);

        /// <summary>
        /// Sends to SIB a message
        /// </summary>
        /// <param name="msg">Message to send</param>
        /// <exception cref="ConnectionToSibException">Not connected to SIB</exception>
        /// <returns></returns>
        SSAPMessage<SSAPBodyReturnMessage> Send<T>(SSAPMessage<T> msg) where T : SSAPBodyMessage;

        /// <summary>
        /// Sends to SIB a cipher message
        /// </summary>
        /// <param name="msg">Message to send</param>
        /// <exception cref="ConnectionToSibException">Not connected to SIB</exception>
        /// <returns></returns>
        SSAPMessage<SSAPBodyReturnMessage> SendCipher<T>(SSAPMessage<T> msg) where T : SSAPBodyMessage;

        /// <summary>
        /// Registers a SIB Notifications Listener
        /// </summary>
        /// <param name="listener">Listener</param>
        void AddListener4SIBNotifications(IListener4SIBIndicationNotifications listener);

        /// <summary>
        /// Removes a SIB Notifications Listener
        /// </summary>
        /// <param name="listener">Listener</param>
        void RemoveListener4SIBNotifications(IListener4SIBIndicationNotifications listener);

        // <summary>
        /// Removes all SIB Notifications Listener
        /// </summary>
        void RemoveListener4SIBNotifications();
        
        /// <summary>
        /// Registers a listener to receive raw messages notifications from SIB
        /// </summary>
        /// <param name="listener">Listener</param>
        //void AddListener4SIBCommandMessageNotifications(IListener4SIBCommandMessageNotifications listener);

        /// <summary>
        /// Removes a listener from receiving raw messages notifications from SIB
        /// </summary>
        /// <param name="listener">Listener</param>
        //void RemoveListener4SIBCommandMessageNotifications(IListener4SIBCommandMessageNotifications listener);

        /// <summary>
        /// Registers a listener to receive BaseCommandRequets from SIB
        /// </summary>
        /// <param name="listener">Listener</param>
        //void SetListener4BaseCommandRequestNotifications(IListener4SIBIndicationNotifications listener);

        /// <summary>
        /// Registers a listener to receive status from SIB
        /// </summary>
        /// <param name="listener">Listener</param>
        //void SetListener4StatusControlRequestNotifications(IListener4SIBIndicationNotifications listener);
    }
}
