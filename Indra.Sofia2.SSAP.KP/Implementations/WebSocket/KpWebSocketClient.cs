using Indra.Sofia2.SSAP.SSAP;
using Indra.Sofia2.SSAP.SSAP.Body;
using System;
using System.Collections.Concurrent;
using System.Threading;
using Indra.Sofia2.SSAP.KP.Config;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP.Implementations.WebSocket
{
    
    public class KpWebSocketClient : IKp
    {
        protected List<IListener4SIBIndicationNotifications> subscriptionListeners = new List<IListener4SIBIndicationNotifications>();

        private WebSocketSharp.WebSocket client;
        private ConcurrentQueue<Callback> callbacks = new ConcurrentQueue<Callback>();
        protected WebSocketConnectionConfig config;
        private Object thisLock = new Object();

        public KpWebSocketClient(WebSocketConnectionConfig config)
        {
            #region contrat
            if(config == null)
            {
                throw new Exception("Config must be provided");
            }
            if(String.IsNullOrEmpty(config.EnpointUri))
            {
                throw new Exception("EnpointUri must be provided");
            }
            if(config.TimeOutConnectionSIB <= 0)
            {
                throw new Exception("TimeOutConnectionSIB must be greater than zero");
            }
            #endregion contract

            this.config = config;
        }

        public void Connect()
        {
            client = new WebSocketSharp.WebSocket(config.EnpointUri);
            client.WaitTime = new TimeSpan(0, 0, config.KeepAliveInSeconds);

            client.OnMessage += (sender, e) =>
            {
                SSAPMessage<SSAPBodyMessage> message = SSAPMessage<SSAPBodyMessage>.FromJson<SSAPBodyMessage>(e.Data);
                if (message.MessageType != SSAPMessageTypesEnum.INDICATION)
                {
                    Callback c;
                    callbacks.TryDequeue(out c);
                    c.Handle(e.Data);
                }
                else
                {
                    foreach (IListener4SIBIndicationNotifications listener in subscriptionListeners)
                    {
                        Action a = () => { listener.OnIndication("", message); };
                        Task.Factory.StartNew(a);
                    }
                }
            };
            client.Connect();            
        }

        public void Disconnect()
        {
            client.Close();
        }

        public SSAPMessage<SSAPBodyReturnMessage> Send<T>(SSAPMessage<T> request) where T : SSAPBodyMessage
        {
            lock(thisLock)
            { 
                string strRequest = request.ToJson();
                Callback callback = new Callback(config.TimeOutConnectionSIB);
                callbacks.Enqueue(callback);
                client.Send(strRequest);
                string strResponse = callback.Get();
                SSAPMessage<SSAPBodyReturnMessage> response = SSAPMessage<SSAPBodyReturnMessage>.FromJson<SSAPBodyReturnMessage>(strResponse);
                return response;
            }
        }

        public SSAPMessage<SSAPBodyReturnMessage> SendCipher<T>(SSAPMessage<T> msg) where T : SSAPBodyMessage
        {
            throw new NotImplementedException();
        }

        public bool IsConnected()
        {
            return client.IsAlive;
        }

        public string GetSessionKey()
        {
            throw new NotImplementedException();
        }

        public void SetConnectionConfig(ConnectionConfig config)
        {
            this.config = (WebSocketConnectionConfig)config;
        }

        public void SetXxteaCipherKey(string cipherKey)
        {
            throw new NotImplementedException();
        }

        public void AddListener4SIBNotifications(IListener4SIBIndicationNotifications listener)
        {
            subscriptionListeners.Add(listener);
        }

        public void RemoveListener4SIBNotifications(IListener4SIBIndicationNotifications listener)
        {
            subscriptionListeners.Remove(listener);
        }

        public void RemoveListener4SIBNotifications()
        {
            subscriptionListeners.Clear();
        }

        class Callback
        {
            private string response;
            CountdownEvent cde = new CountdownEvent(1);
            private int timeOutConnectionSIB;

            public Callback(int timeOutConnectionSIB)
            {
                this.timeOutConnectionSIB = timeOutConnectionSIB;
            }

            public string Get()
            {
                cde.Wait(timeOutConnectionSIB);

                if (String.IsNullOrEmpty(response))
                    throw new Exception("Timeout: " + "ssapResponseTimeout" + " waiting for SSAP Response");
                return response;
            }

            public void Handle(string response)
            {
                this.response = response;
                cde.Signal();
            }
        }      
    }
}
