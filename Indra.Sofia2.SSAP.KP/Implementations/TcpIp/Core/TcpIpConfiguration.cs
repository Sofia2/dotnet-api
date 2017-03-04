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
    public static class TcpIpConfiguration
    {
        /// <summary>
        /// client buffer size in bytes
        /// </summary>
        public static int BUFFER_SIZE = 32768;

        /// <summary>
        /// client buffer grow size in bytes
        /// </summary>
        public static int BUFFER_GROW = 100;

        /// <summary>
        /// Port the server listens on
        /// </summary>
        public static string PORT = "PORT";

        /// <summary>
        /// Size of ByteBuffer for reading/writing from channels
        /// </summary>
        public static string NET_BUFFER_SIZE = "NET_BUFFER_SIZE";

        /// <summary>
        /// Interval to sleep between attempts to write to a channel
        /// </summary>
        public static string CHANNEL_WRITE_SLEEP = "CHANNEL_WRITE_SLEEP";

        /// <summary>
        /// Number of worker threads for EventWriter
        /// </summary>
        public static string EVENT_WRITER_WORKERS = "EVENT_WRITER_WORKERS";

        /// <summary>
        /// Default number of workers for GameControllers
        /// </summary>
        public static string CONTROLLER_WORKERS = "DEFAULT_CONTROLLER_WORKERS";

        /// <summary>
        /// Default size of the write queue
        /// </summary>
        public static string WRITE_QUEUE_SIZE = "WRITE_QUEUE_SIZE";

        /// <summary>
        /// Default sleep for reader channels
        /// </summary>
        public static string CHANNEL_READER_SLEEP = "CHANNEL_READER_SLEEP";

        //The TCP/IP Gateway parameter default values 
        public static int DEFAULT_PORT = 23000;
        public static int DEFAULT_NET_BUFFER_SIZE = 512;
        public static long DEFAULT_CHANNEL_WRITE_SLEEP = 10;
        public static int DEFAULT_EVENT_WRITER_WORKERS = 5;
        public static int DEFAULT_CONTROLLER_WORKERS = 5;
        public static int DEFAULT_WRITE_QUEUE_SIZE = 100;
        public static long DEFAULT_CHANNEL_READER_SLEEP = 30;

    }
}
