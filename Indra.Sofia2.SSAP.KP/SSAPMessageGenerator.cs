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
using Indra.Sofia2.SSAP.KP.Exceptions;
using Indra.Sofia2.SSAP.SSAP;
using Indra.Sofia2.SSAP.SSAP.Body;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Sofia2.SSAP.KP
{
    public class SSAPMessageGenerator
    {

        private static SSAPMessageGenerator _instance = new SSAPMessageGenerator();

        /// <summary>
        /// Constructor. Singleton Pattern
        /// </summary>
        private SSAPMessageGenerator()
        { }

        /// <summary>
        /// Get an instance of the class. Singleton Pattern
        /// </summary>
        public static SSAPMessageGenerator GetInstance()
        {
            return _instance;
        }

        #region Public Methods

        /// <summary>
        /// Generates a Join Message with user/password authentication.
        /// </summary>
        /// <param name="user">User Name</param>
        /// <param name="password">Password</param>
        /// <param name="instance">Logged Device Info</param>
        /// <returns>Join Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateJoinMessage(string user, string password, string instance)
        {
            return GenerateJoinMessage(user, password, instance, null);
        }

        /// <summary>
        /// Generates a Join Message with user/password authentication.
        /// </summary>
        /// <param name="user">User Name</param>
        /// <param name="password">Password</param>
        /// <param name="instance">Logged Device Info</param>
        /// <param name="sessionKey">SIB session Id</param>
        /// <returns>Join Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateJoinMessage(string user, string password, string instance, string sessionKey)
        {
            var body = new SSAPBodyJoinUserAndPasswordMessage()
            {
                User = user,
                Password = password,
                Instance = instance
            };
            return new SSAPMessage<SSAPBodyMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.JOIN,
                SessionKey = sessionKey
            };
        }

        /// <summary>
        /// Generates a Join Message with token authentication.
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="instance">Logged Device Info</param>
        /// <returns>Join Message</returns>
        public SSAPMessage<SSAPBodyJoinTokenMessage> GenerateJoinByTokenMessage(string token, string instace)
        {
            return GenerateJoinByTokenMessage(token, instace, null);
        }

        /// <summary>
        /// Generates a Join Message with token authentication.
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="instance">Logged Device Info</param>
        /// <param name="sessionKey">SIB session Id</param>
        /// <returns>Join Message</returns>
        public SSAPMessage<SSAPBodyJoinTokenMessage> GenerateJoinByTokenMessage(string token, string instance, string sessionKey)
        {
            var body = new SSAPBodyJoinTokenMessage()
            {
                Token = token,
                Instance = instance
            };
            return new SSAPMessage<SSAPBodyJoinTokenMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.JOIN,
                SessionKey = sessionKey
            };
        }

        /// <summary>
        /// Generate a Leave Message to close session
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <returns>Leave Message</returns>
        public SSAPMessage<SSAPBodyLeaveMessage> GenerateLeaveMessage(string sessionKey)
        {
            return new SSAPMessage<SSAPBodyLeaveMessage>()
            {
                SessionKey = sessionKey,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.LEAVE
            };
        }

        /// <summary>
        /// Generates an Insert Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="data">Insert Data</param>
        /// <returns>Insert Message</returns>
        public SSAPMessage<SSAPBodyOperationMessage> GenerateInsertMessage(string sessionKey, string ontology, string data)
        {
            var body = new SSAPBodyOperationMessage()
            {
                Data = JObject.Parse(data)
            };
            return new SSAPMessage<SSAPBodyOperationMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.INSERT,
                Ontology = ontology
            };
        }
        
        /// <summary>
        /// Generates an Insert Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="data">Insert Data</param>
        /// <param name="queryType">Query Type</param>
        /// <exception cref="SQLSentenceNotAllowedForThisOperationException">No Insert values given</exception>
        /// <returns>Insert Message</returns>
        public SSAPMessage<SSAPBodyOperationMessage> GenerateInsertMessage(string sessionKey, string ontology, string data, SSAPQueryTypeEnum queryType)
        {
            if (!IsInsert(data, queryType))
                throw new SQLSentenceNotAllowedForThisOperationException("ERROR - Expected insert values");

            var body = new SSAPBodyOperationMessage()
            {
                Data =data,
                QueryType = queryType
            };
            if (queryType == SSAPQueryTypeEnum.SQLLIKE)
            {
                body.Query = data;
            }
            else
            {
                //body.Data = data;
                body.Data = JObject.Parse(data);
            }
            return new SSAPMessage<SSAPBodyOperationMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.INSERT,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a Native Update Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="data">Update Data</param>
        /// <param name="query">Query</param>
        /// <returns>Update Message</returns>
        public SSAPMessage<SSAPBodyOperationMessage> GenerateUpdateMessage(string sessionKey, string ontology, string data, string query)
        {
            var body = new SSAPBodyOperationMessage()
            {
                Data = JObject.Parse(data),
                Query = query,
                QueryType = SSAPQueryTypeEnum.NATIVE
            };
            return new SSAPMessage<SSAPBodyOperationMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.UPDATE,
                Ontology = ontology
            };
        }


        /// <summary>
        /// Generates a Update Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="data">Update Data</param>
        /// <param name="query">Query</param>
        /// <param name="queryType">Query Type</param>
        /// <exception cref="SQLSentenceNotAllowedForThisOperationException">No Update Query 
        /// given</exception>
        /// <returns>Update Message</returns>
        public SSAPMessage<SSAPBodyOperationMessage> GenerateUpdateMessage(string sessionKey, string ontology, string data, string query, SSAPQueryTypeEnum queryType)
        {
            if (!IsUpdate(query, queryType))
                throw new SQLSentenceNotAllowedForThisOperationException("ERROR - Expected update query");

            var body = new SSAPBodyOperationMessage()
            {
                Data = data,
                QueryType = queryType,
                Query = query
            };
            return new SSAPMessage<SSAPBodyOperationMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.UPDATE,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a Native Remove Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="query">Query</param>
        /// <returns>Remove Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateRemoveMessage(string sessionKey, string ontology, string query)
        {
            var body = new SSAPBodyOperationMessage()
            {
                Query = query,
                QueryType = SSAPQueryTypeEnum.NATIVE
            };
            return new SSAPMessage<SSAPBodyMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.DELETE,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a Remove Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="query">Query</param>
        /// <param name="queryType">Query Type</param>
        /// <exception cref="SQLSentenceNotAllowedForThisOperationException">The query is not
        /// a remove or delete statement</exception>
        /// <returns>Remove Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateRemoveMessage(string sessionKey, string ontology, string query, SSAPQueryTypeEnum queryType)
        {
            if (!IsRemove(query, queryType))
                throw new SQLSentenceNotAllowedForThisOperationException("ERROR - statement no expected");

            var body = new SSAPBodyOperationMessage()
            {
                QueryType = queryType,
                Query = query
            };
            return new SSAPMessage<SSAPBodyMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.DELETE,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a Native Query Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="query">Query</param>
        /// <returns>Query Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateQueryMessage(string sessionKey, string ontology, string query)
        {
            var body = new SSAPBodyQueryMessage()
            {
                Query = query               
            };
            return new SSAPMessage<SSAPBodyMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.QUERY,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a Query Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="query">Query</param>
        /// <param name="queryType">Query Type</param>
        /// <exception cref="SQLSentenceNotAllowedForThisOperationException">Bad format query</exception>
        /// <returns>Query Message</returns>
        public SSAPMessage<SSAPBodyOperationMessage> GenerateQueryMessage(string sessionKey, string ontology, string query, SSAPQueryTypeEnum queryType)
        {
            if (!IsQuery(query, queryType))
                throw new SQLSentenceNotAllowedForThisOperationException("ERROR - statement no expected");

            var body = new SSAPBodyOperationMessage()
            {
                QueryType = queryType,
                Query = query
            };
            return new SSAPMessage<SSAPBodyOperationMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.QUERY,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a predefined in SIB Query Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="idQuery">Predefined Query Id</param>
        /// <returns>Query Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateQueryMessage(string sessionKey, string idQuery)
        {
            var body = new SSAPBodyQueryMessage()
            {
                Query = idQuery,
                QueryType = SSAPQueryTypeEnum.SIB_DEFINED
            };
            return new SSAPMessage<SSAPBodyMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.QUERY,
            };
        }

        /// <summary>
        /// Generates a predefined in SIB Query Message with parameters
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="idQuery">Predefined Query Id</param>
        /// <param name="parameters">Query Parameters Dictionary (param key, value)</param>
        /// <returns>Query Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateQueryMessageWithParams(string sessionKey, string idQuery, Dictionary<string, string> parameters)
        {
            if (!IsQuery(idQuery, SSAPQueryTypeEnum.SIB_DEFINED))
                throw new SQLSentenceNotAllowedForThisOperationException("ERROR - statement no expected");
            if (idQuery.Length>0 && parameters != null)
            {
                var body = new SSAPBodyQueryWithParamMessage() 
                { 
                    Query = idQuery,
                    QueryType = SSAPQueryTypeEnum.SIB_DEFINED,
                    QueryParams = parameters
                };
                return new SSAPMessage<SSAPBodyMessage>()
                {
                    SessionKey = sessionKey,
                    Body = body,
                    Direction = SSAPMessageDirectionEnum.REQUEST,
                    MessageType = SSAPMessageTypesEnum.QUERY,
                };
            }
            else
            {
                return GenerateQueryMessage(sessionKey, idQuery);
            }
            
        }

        /// <summary>
        /// Generates a native Subscribe Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="msRefresh">Refresh Time in milliseconds</param>
        /// <param name="query">Query</param>
        /// <returns>Subscribe Message</returns>
        public SSAPMessage<SSAPBodySubscribeMessage> GenerateSubscribeMessage(string sessionKey, string ontology, int msRefresh, string query)
        {
            return GenerateSubscribeMessage(sessionKey, ontology, msRefresh, query, SSAPQueryTypeEnum.NATIVE);
        }

        /// <summary>
        /// Generates a native Subscribe Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="msRefresh">Refresh Time in milliseconds</param>
        /// <param name="query">Query</param>
        /// <param name="queryType">Query Type</param>
        /// <returns>Subscribe Message</returns>
        public SSAPMessage<SSAPBodySubscribeMessage> GenerateSubscribeMessage(string sessionKey, string ontology, int msRefresh, string query, SSAPQueryTypeEnum queryType)
        {
            var body = new SSAPBodySubscribeMessage()
            {
                Query = query,
                MsRefresh = msRefresh,
                QueryType = queryType
            };
            return new SSAPMessage<SSAPBodySubscribeMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.SUBSCRIBE,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates an Unsubscribe Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontoogy</param>
        /// <param name="idSubscribtion">Subscribtion Id</param>
        /// <returns>Unsubscribe Message</returns>
        public SSAPMessage<SSAPBodyUnsubscribeMessage> GenerateUnsubscribeMessage(string sessionKey, string ontology, string idSubscribtion)
        {
            var body = new SSAPBodyUnsubscribeMessage()
            {
                IdSuscripcion = idSubscribtion
            };
            return new SSAPMessage<SSAPBodyUnsubscribeMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.UNSUBSCRIBE,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a GetConfig Message
        /// </summary>
        /// <param name="kp"></param>
        /// <param name="kpInstance"></param>
        /// <param name="token"></param>
        /// <param name="assetService"></param>
        /// <param name="assetServiceParameters"></param>
        /// <returns>GetConfig Message</returns>
        public SSAPMessage<SSAPBodyMessage> GenerateGetConfigMessage(string kp, string kpInstance, string token, string assetService, Dictionary<string, string> assetServiceParameters)
        {
            var body = new SSAPBodyConfigMessage()
            {
                InstanciaKp = kpInstance,
                Kp = kp,
                Token = token,
                AssetService = assetService,
                AssetServiceParam = assetServiceParameters
            };
            return new SSAPMessage<SSAPBodyMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.CONFIG
            };
        }

        /// <summary>
        /// Generates a Bulk Message
        /// </summary>
        /// <param name="sessionKey">Session Key</param>
        /// <param name="ontology">Ontology</param>
        /// <returns>Bulk Message</returns>
        public SSAPBulkMessage GenerateBulkMessage(string sessionKey, string ontology)
        {
            return new SSAPBulkMessage()
            {
                SessionKey = sessionKey,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.BULK,
                Ontology = ontology
            };
        }

        /// <summary>
        /// Generates a log Message
        /// </summary>
        /// <param name="thinkp">thinkp</param>
        /// <param name="instanciathinkp">instanciathinkp</param>
        /// <param name="token">token</param>
        /// <param name="level">level</param>
        /// <param name="code">code</param>
        /// <param name="message">message</param>
        /// <param name="timestamp">timestamp</param>
        /// <returns>Log Message</returns>
        public SSAPMessage<SSAPBodyLogMessage> GenerateLogMessage(string thinkp, string instanciathinkp, string token, SSAPLogLevel level, string code, string message, string timestamp)
        {
            var body = new SSAPBodyLogMessage()
            {
                Code = code,
                Instanciathinkp = instanciathinkp,
                Level = level,
                Message = message,
                Owner = "",
                Thinkp = thinkp,
                Timestamp = timestamp,
                Token = token
            };

            return new SSAPMessage<SSAPBodyLogMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.LOG,
            };
        }

        /// <summary>
        /// Generates a error Message
        /// </summary>
        /// <param name="thinkp">thinkp</param>
        /// <param name="instanciathinkp">instanciathinkp</param>
        /// <param name="token">token</param>
        /// <param name="severity">level</param>
        /// <param name="code">code</param>
        /// <param name="message">message</param>
        /// <param name="timestamp">timestamp</param>
        /// <returns>Error Message</returns>
        public SSAPMessage<SSAPBodyErrorMessage> GenerateErrorMessage(string thinkp, string instanciathinkp, string token, SSAPSeverityLevel severity, string code, string message, string timestamp)
        {
            var body = new SSAPBodyErrorMessage()
            {
                Code = code,
                Instanciathinkp = instanciathinkp,
                Message = message,
                Owner = "",
                Severity = severity,
                Thinkp = thinkp,
                Timestamp = timestamp,
                Token =token 
            };
            return new SSAPMessage<SSAPBodyErrorMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.ERROR
            };

        }

        /// <summary>
        /// Generates a status Message
        /// </summary>
        /// <param name="thinkp">thinkp</param>
        /// <param name="instanciathinkp">instanciathinkp</param>
        /// <param name="token">token</param>
        /// <param name="status">status</param>
        /// <param name="timestamp">timestamp</param>
        /// <returns>Status Message</returns>
        public SSAPMessage<SSAPBodyStatusMessage> GenerateStatusMessage(string thinkp, string instanciathinkp, string token, Dictionary<string, string> status, string timestamp)
        {
            var body = new SSAPBodyStatusMessage()
            {
                Instanciathinkp = instanciathinkp,
                Status = status,
                Thinkp = thinkp,
                Timestamp = timestamp,
                Token = token
            };

            return new SSAPMessage<SSAPBodyStatusMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.STATUS
            };
        }

        /// <summary>
        /// Generates a location Message
        /// </summary>
        /// <param name="thinkp">thinkp</param>
        /// <param name="instanciathinkp">instanciathinkp</param>
        /// <param name="token">token</param>
        /// <param name="accuracy">status</param>
        /// <param name="lat">status</param>
        /// <param name="lon">status</param>
        /// <param name="alt">status</param>
        /// <param name="bearing">status</param>
        /// <param name="speed">status</param>
        /// <param name="timestamp">status</param>
        /// <returns>Location Message</returns>
        public SSAPMessage<SSAPBodyLocationMessage> GenerateLocationMessage(string thinkp, string instanciathinkp, string token, double accuracy, double lat, double lon, double alt, double bearing, double speed, string timestamp)
        {
            var body = new SSAPBodyLocationMessage()
            {
                Accuracy = accuracy,
                Alt = alt,
                Bearing = bearing,
                Instanciathinkp = instanciathinkp,
                Lat = lat,
                Lon = lon,
                Speed = speed,
                Thinkp = thinkp,
                Timestamp = timestamp,
                Token = token
            };

            return new SSAPMessage<SSAPBodyLocationMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.LOCATION
            };
        }
        /// <summary>
        /// Generates a command Message
        /// </summary>
        /// <param name="sessionKey">sessionKey</param>
        /// <param name="thinkp">thinkp</param>
        /// <param name="instanciathinkp">instanciathinkp</param>
        /// <param name="commandType">commandType</param>
        /// <param name="args">args</param>
        /// <returns>Command Message</returns>
        public SSAPMessage<SSAPBodyCommandMessage> GenerateCommandMessage(string sessionKey, string thinkp, string thinkpInstance, SSAPCommandType commandType, Dictionary<String, String> args)
        {
            var body = new SSAPBodyCommandMessage()
            {
                Args = args,
                
                Thinkp = thinkp,
                ThinkpInstance = thinkpInstance,
                Type = SSAPCommandType.STATUS
            };

            return new SSAPMessage<SSAPBodyCommandMessage>()
            {
                SessionKey = sessionKey,
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.COMMAND
            };
        }

        public SSAPMessage<SSAPBodySubscribeCommandMessage> GenerateSubscribeCommandMessage(string thinkp, string thinkpInstance, string token, SSAPCommandType commandType)
        {
            var body = new SSAPBodySubscribeCommandMessage()
            {
                Thinkp = thinkp,
                ThinkpInstance = thinkpInstance,
                Token = token
            };

            return new SSAPMessage<SSAPBodySubscribeCommandMessage>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.SUBSCRIBECOMMAND
            };
        }


        public SSAPMessage<SSAPBodyQueryMessageQuasar> GenerateQueryMessageQusarSQL(string sessionKey, string query, int offset, SSAPQueryResultFormat resultFormat, string formatter)
        {
            var body = new SSAPBodyQueryMessageQuasar
            {
                Query = query,
                QueryType = SSAPQueryTypeEnum.SQL,
                Formatter = formatter,
                Offset = offset,
                ResultFormat = resultFormat,
            };

            return new SSAPMessage<SSAPBodyQueryMessageQuasar>()
            {
                Body = body,
                Direction = SSAPMessageDirectionEnum.REQUEST,
                MessageType = SSAPMessageTypesEnum.QUERY,
                SessionKey = sessionKey
            };
        }



        #endregion Public Methods

            #region Private Methods

        private bool IsInsert(string data, SSAPQueryTypeEnum? queryType)
        {
            if (queryType.HasValue && data.Length > 0)
            {
                switch(queryType.Value)
                {
                    case SSAPQueryTypeEnum.SQLLIKE:
                    case SSAPQueryTypeEnum.NATIVE:
                        return data.ToUpper().Contains("INSERT");
                    default:
                        return false;
                }
            }
            else
            {
                return data.Length > 0;
            }
        }

        private bool IsUpdate(string query, SSAPQueryTypeEnum? queryType)
        {
            if (queryType.HasValue && query.Length > 0)
            {
                switch (queryType.Value)
                {
                    case SSAPQueryTypeEnum.SQLLIKE:
                        return query.ToUpper().Contains("UPDATE");
                    case SSAPQueryTypeEnum.NATIVE:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return query.Length > 0;
            }
        }

        private bool IsRemove(string query, SSAPQueryTypeEnum? queryType)
        {
            if (queryType.HasValue && query.Length > 0)
            {
                switch (queryType.Value)
                {
                    case SSAPQueryTypeEnum.SQLLIKE:
                        return query.ToUpper().Contains("DELETE ");
                    case SSAPQueryTypeEnum.NATIVE:
                        return query.ToUpper().Contains("REMOVE");
                    default:
                        return false;
                }
            }
            else
            {
                return query.Length > 0;
            }
        }

        private bool IsQuery(string query, SSAPQueryTypeEnum? queryType)
        {
            if (queryType.HasValue && query.Length > 0)
            {
                switch (queryType.Value)
                {
                    case SSAPQueryTypeEnum.SQLLIKE:
                    case SSAPQueryTypeEnum.BDH:
                        return query.ToUpper().Contains("SELECT ") ||
                            query.ToUpper().Contains("INSERT ") ||
                            query.ToUpper().Contains("UPDATE ") ||
                            query.ToUpper().Contains("DELETE ");
                    case SSAPQueryTypeEnum.NATIVE:
                        return true;
                    case SSAPQueryTypeEnum.SIB_DEFINED:
                    case SSAPQueryTypeEnum.CEP:
                        return true;
                    case SSAPQueryTypeEnum.BDC:
                        return query.ToUpper().Contains("SELECT ");
                    default:
                        return false;
                }
            }
            else
            {
                return query.Length > 0;
            }
        }

        #endregion Private Methods

    }
}
