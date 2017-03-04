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
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP_UTest
{
    class LightHttpListener
    {
        public string Listen(int port)
        {
            TcpListener server = null;

            try
            {
                //Int32 port = 3333;
                IPAddress localAdder = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAdder, port);

                server.Start();

                TcpClient client = server.AcceptTcpClient();

                NetworkStream networkStream = client.GetStream();
                StreamReader streamReader = new StreamReader(networkStream);
                StreamWriter streamWriter = new StreamWriter(networkStream);

                int contentLength = -1;
                String s;

                while (!String.IsNullOrEmpty(s = streamReader.ReadLine()))
                {
                    String[] header = s.Split(':');
                    Console.WriteLine("RECIVIDOL: ", s);
                    if (String.Equals(header[0], "Content-Length", StringComparison.OrdinalIgnoreCase))
                    {
                        contentLength = Int32.Parse(header[1].Trim());
                    }
                }

                char[] buffer = new char[contentLength];
                streamReader.Read(buffer, 0, contentLength);

                streamWriter.Write("HTTP/1.1 200 OK\r\n");
                streamWriter.Write("Content-Length: 0\r\n");
                streamWriter.Write("Connection: close\r\n");
                streamWriter.Write("\r\n");
                streamWriter.Flush();
                String retStr = new string(buffer);
                client.Close();

                return retStr;

            }
            catch (SocketException ex)
            {
                //Trace.Fail(ex.Message, ex.StackTrace);
                //Assert.Fail(ex.Message);
            }
            finally
            {
                server.Stop();
            }

            return null;
        }

    }
}
