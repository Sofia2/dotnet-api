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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP.Implementations.TcpIp.Core
{
    public abstract class ClientConnectionAttachment
    {
        /// <summary>
        /// Temporary buffer before it is converted into a message.
        /// </summary>
        private byte[] _buffer;

        /// <summary>
        /// List of ClientMessages already decoded.
        /// </summary>
        private List<ClientMessage> _decodedMessages;

        private int _alloc;
        private int _used;

        /// <summary>
        /// Gets the lenght of this array
        /// </summary>
        public int Length
        {
            get { return _used; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ClientConnectionAttachment()
        {
            _buffer = new byte[TcpIpConfiguration.BUFFER_SIZE];
            _alloc = TcpIpConfiguration.BUFFER_SIZE;
            _used = 0;
            _decodedMessages = new List<ClientMessage>();
        }

        /// <summary>
        /// Check if there are enough bytes to build message(s).
        /// </summary>
        /// <exception cref="MessageParseException">
        /// The length of the indexes is no even.</exception>
        /// <returns></returns>
        public bool CheckForMessages()
        {
            int[] indexes = ParseMessages(_buffer);
            if (indexes == null)
            {
                return false;
            }
            else
            {
                if (indexes.Length % 2 != 0)
                {
                    throw new MessageParseException("The length of the indexes is no even.");
                }
                try
                {
                    // Create client messages.
                    for (int i = 0; i<indexes.Length; i+=2)
                    {
                        var messageSize = indexes[i + 1] - indexes[i] + 1;
                        var payload = new byte[messageSize];
                        Array.Copy(_buffer, indexes[i], payload, 0, messageSize);
                        ClientMessage cm = new ClientMessage(payload);
                        _decodedMessages.Add(cm);
                    }
                    // Compact the buffer.
                    var remaining = _used - indexes[indexes.Length - 1] - 1;
                    var newLength = Math.Max(remaining, TcpIpConfiguration.BUFFER_SIZE);
                    var newBuffer = new byte[newLength];
                    Array.Copy(_buffer, indexes[indexes.Length - 1] + 1, newBuffer, 0, remaining);
                    _buffer = newBuffer;
                    _alloc = newLength;
                    _used = remaining;
                    return true;
                }
                catch (Exception ex)
                {
                    throw new MessageParseException(ex.Message);
                }

            }
        }

        /// <summary>
        /// Returns pairs of indexes indicating the start index (included) 
        /// and the last index (included) of the detected messages.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public abstract int[] ParseMessages(byte[] buffer);

        /// <summary>
        /// Indicates if there are pending messages.
        /// </summary>
        /// <returns></returns>
        public bool HasMessages()
        {
            return _decodedMessages.Any();
        }

        /// <summary>
        /// This method removes the messages returned each time is called
        /// </summary>
        /// <returns>Iterator with the parsed messages</returns>
        public System.Collections.Generic.IEnumerator<ClientMessage> GetMessages()
        {
            if (HasMessages())
            {
                List<ClientMessage> messages = new List<ClientMessage>(_decodedMessages);
                _decodedMessages.Clear();
                return messages.GetEnumerator();
            }
            else
                return null;
        }

        /// <summary>
        /// Clear this array
        /// </summary>
        public void Reset()
        {
            _used = 0;
        }

        /// <summary>
        /// Add a byte to this array
        /// </summary>
        /// <param name="b">byte to add</param>
        public void Add(byte b)
        {
            _buffer[_used++] = b;
            if (_used == _alloc)
            {
                Grow(TcpIpConfiguration.BUFFER_GROW);
            }
        }

        /// <summary>
        /// Add a array of bytes to this array
        /// </summary>
        /// <param name="b">Byte array to add</param>
        /// <param name="len">Lenght of byte array to add</param>
        public void Add(byte[] b, int len)
        {
            if (_used + len >= _alloc)
            {
                Grow(len + TcpIpConfiguration.BUFFER_GROW);
            }
            Array.Copy(b, 0, _buffer, _used, len);
            _used += len;
        }

        /// <summary>
        /// Add a array of bytes to this array
        /// </summary>
        /// <param name="b">Byte array to add</param>
        /// <param name="len">Lenght of byte array to add</param>
        public void Add(MemoryStream stream)
        {
            if (stream.Length + _used >= _alloc)
            {
                Grow((int)stream.Length + TcpIpConfiguration.BUFFER_GROW);
            }
            stream.Read(_buffer, _used, (int)stream.Length);
            _used += (int)stream.Length;
        }

        private void Grow(int newGap)
        {
            _alloc += newGap;
            byte[] aux = new byte[_alloc];
            Array.Copy(_buffer, 0, aux, 0, _used);
            _buffer = aux;
        }
    }
}
