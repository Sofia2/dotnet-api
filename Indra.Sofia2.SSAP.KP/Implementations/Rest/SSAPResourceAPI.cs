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
using Indra.Sofia2.SSAP.KP.Implementations.Rest.Resource;
using Indra.Sofia2.SSAP.SSAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Indra.Sofia2.SSAP.KP.Implementations.Rest
{
    public class SSAPResourceAPI
    {
        #region Consts

        private const string STR_PATH = "/v01/SSAPResource";
        private const string STR_APPLICATION_HEADER = "application/json";
        private const string STR_SESSION_KEY = "$sessionKey";
        private const string STR_ONTOLOGY = "$ontology";
        private const string STR_KP = "$kp";
        private const string STR_INSTANCIA_KP = "$instanciakp";
        private const string STR_TOKEN = "$token";
        private const string STR_ASSET_SERVICE = "$assetService";
        private const string STR_ASSET_SERVICE_PARAM = "$assetServiceParam";
        private const string STR_QUERY = "$query";
        private const string STR_QUERY_ARGUMENTS = "$queryArguments";
        private const string STR_QUERY_TYPE = "$queryType";
        private const string STR_BAD_REQUEST_OBJECT = "Bad Request: could not get ObjectId from body Object";
        private const string STR_BAD_REQUEST_SESSION_ONTOLOGY = "Bad Request: could not get session key or ontology";
        private const string STR_BAD_REQUEST_KP = "Bad Request: could not get kp or kp instance";
        private const string STR_BAD_REQUEST_TOKEN = "Bad Request: Token must be provided in this operation";

        #endregion Consts

        private string _serviceBaseUrl;

        public SSAPResourceAPI(string serviceURL)
        {
            _serviceBaseUrl = serviceURL;
            if (_serviceBaseUrl.EndsWith("/"))
                _serviceBaseUrl = _serviceBaseUrl.Remove(_serviceBaseUrl.Length - 1);
        }

        public async Task<HttpResponseMessage> Delete(SSAPResource ssap)
        {
            return await DeleteOid(ssap.Data.ToString(), ssap.SessionKey, ssap.Ontology);
        }

        public async Task<HttpResponseMessage> DeleteOid(string oid, string sessionKey, string ontology)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(oid))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_OBJECT) };
            if (String.IsNullOrWhiteSpace(sessionKey) || String.IsNullOrWhiteSpace(ontology))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_SESSION_ONTOLOGY) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //delete URI
                var query = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(sessionKey))
                    query.Add(STR_SESSION_KEY, sessionKey);
                if (!String.IsNullOrWhiteSpace(ontology))
                    query.Add(STR_ONTOLOGY, ontology);
                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/{2}", _serviceBaseUrl, STR_PATH, oid));
                if (query.HasKeys())
                    builder.Query = query.ToString();

                return await client.DeleteAsync(builder.ToString());
            }
        }

        public async Task<HttpResponseMessage> Query(string oid, string sessionKey, string ontology)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(oid))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_OBJECT) };
            if (String.IsNullOrWhiteSpace(sessionKey) || String.IsNullOrWhiteSpace(ontology))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_SESSION_ONTOLOGY) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));
                

                //delete URI
                var query = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(sessionKey))
                    query.Add(STR_SESSION_KEY, sessionKey);
                if (!String.IsNullOrWhiteSpace(ontology))
                    query.Add(STR_ONTOLOGY, ontology);
                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/{2}", _serviceBaseUrl, STR_PATH, oid));
                if (query.HasKeys())
                    builder.Query = query.ToString();

                return await client.GetAsync(builder.ToString());
            }
        }

        public async Task<HttpResponseMessage> Query(string sessionKey, string ontology, string query,
            string queryArguments, string queryType)
        {
            //data validation
            //if (String.IsNullOrWhiteSpace(sessionKey) || String.IsNullOrWhiteSpace(ontology))
            if (String.IsNullOrWhiteSpace(sessionKey))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_SESSION_ONTOLOGY) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Query URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(sessionKey))
                    queryParams.Add(STR_SESSION_KEY, sessionKey);
                if (!String.IsNullOrWhiteSpace(ontology))
                    queryParams.Add(STR_ONTOLOGY, ontology);
                if (!String.IsNullOrWhiteSpace(query))
                    queryParams.Add(STR_QUERY, query);
                if (!String.IsNullOrWhiteSpace(queryArguments))
                    queryParams.Add(STR_QUERY_ARGUMENTS, queryArguments);
                if (!String.IsNullOrWhiteSpace(queryType))
                    queryParams.Add(STR_QUERY_TYPE, queryType);
                else
                    queryParams.Add(STR_QUERY_TYPE, "SQLLIKE");

                UriBuilder builder = new UriBuilder(_serviceBaseUrl + STR_PATH);
                if (queryParams.HasKeys())
                    builder.Query = queryParams.ToString();


                return await client.GetAsync(builder.ToString());
            }
        }

        public async Task<HttpResponseMessage> Insert(SSAPResource ssap)
        {
            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Insert URI
                UriBuilder builder = new UriBuilder(_serviceBaseUrl + STR_PATH);

                return await client.PostAsJsonAsync<SSAPResource>(builder.ToString(), ssap);
            }
        }

        public async Task<HttpResponseMessage> Update(SSAPResource ssap)
        {
            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Update URI
                UriBuilder builder = new UriBuilder(_serviceBaseUrl + STR_PATH);

                return await client.PutAsJsonAsync<SSAPResource>(builder.ToString(), ssap);
            }
        }

        public async Task<HttpResponseMessage> GetConfig(string kp, string instanciaKp, string token,
            string assetService, string assetServiceParam)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(kp) || String.IsNullOrWhiteSpace(instanciaKp))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_KP) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Config URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(kp))
                    queryParams.Add(STR_KP, kp);
                if (!String.IsNullOrWhiteSpace(instanciaKp))
                    queryParams.Add(STR_INSTANCIA_KP, instanciaKp);
                if (!String.IsNullOrWhiteSpace(token))
                    queryParams.Add(STR_TOKEN, token);
                if (!String.IsNullOrWhiteSpace(assetService))
                    queryParams.Add(STR_ASSET_SERVICE, assetService);
                if (!String.IsNullOrWhiteSpace(assetServiceParam))
                    queryParams.Add(STR_ASSET_SERVICE_PARAM, assetServiceParam);

                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/config", _serviceBaseUrl, STR_PATH));
                builder.Query = queryParams.ToString();

                return await client.GetAsync(builder.ToString());
            }
        }

        public async Task<HttpResponseMessage> Status(string thinkp, string thinkpInstance, string token, string owner, Dictionary<string, string> status, string timestamp)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(thinkp) || String.IsNullOrWhiteSpace(thinkpInstance) || String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_KP) };

            if (String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_TOKEN) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Config URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(thinkp))
                    queryParams.Add("$thinkp", thinkp);
                if (!String.IsNullOrWhiteSpace(thinkpInstance))
                    queryParams.Add("$kp", thinkpInstance);
                if (!String.IsNullOrWhiteSpace(token))
                    queryParams.Add("$token", token);
                if (!String.IsNullOrWhiteSpace(owner))
                    queryParams.Add("$owner", owner);
                if (!String.IsNullOrWhiteSpace(timestamp))
                    queryParams.Add("$timestamp", timestamp);

                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/status", _serviceBaseUrl, STR_PATH));
                builder.Query = queryParams.ToString();

                if (status == null)
                {
                    status = new Dictionary<string, string>();
                }
                return await  client.PostAsJsonAsync<Dictionary<string, string>>(builder.ToString(), status);

            }
        }

        public async Task<HttpResponseMessage> Location(string thinkp, string thinkpInstance, string token, string owner,
            double accuracy, double lat, double lon, double alt, double bearing, double speed, string timestamp)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(thinkp) || String.IsNullOrWhiteSpace(thinkpInstance) || String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_KP) };

            if (String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_TOKEN) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Config URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(thinkp))
                    queryParams.Add("$thinkp", thinkp);
                if (!String.IsNullOrWhiteSpace(thinkpInstance))
                    queryParams.Add("$kp", thinkpInstance);
                if (!String.IsNullOrWhiteSpace(token))
                    queryParams.Add("$token", token);
                if (!String.IsNullOrWhiteSpace(owner))
                    queryParams.Add("$owner", owner);

                queryParams.Add("$accuracy", accuracy.ToString());
                queryParams.Add("$lat", lat.ToString());
                queryParams.Add("$lon", lon.ToString());
                queryParams.Add("$alt", alt.ToString());
                queryParams.Add("$bearing", bearing.ToString());
                queryParams.Add("$speed", speed.ToString());

                if (!String.IsNullOrWhiteSpace(timestamp))
                    queryParams.Add("$timestamp", timestamp);

                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/location", _serviceBaseUrl, STR_PATH));
                builder.Query = queryParams.ToString();

                return await client.PostAsync(builder.ToString(), null);
            }
        }

        public async Task<HttpResponseMessage> Error(string thinkp, string thinkpInstance, string token, string owner,
            SSAPSeverityLevel severity, string code, string message, string timestamp)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(thinkp) || String.IsNullOrWhiteSpace(thinkpInstance) || String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_KP) };

            if (String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_TOKEN) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Config URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(thinkp))
                    queryParams.Add("$thinkp", thinkp);
                if (!String.IsNullOrWhiteSpace(thinkpInstance))
                    queryParams.Add("$kp", thinkpInstance);
                if (!String.IsNullOrWhiteSpace(token))
                    queryParams.Add("$token", token);
                if (!String.IsNullOrWhiteSpace(owner))
                    queryParams.Add("$owner", owner);
                if (!String.IsNullOrWhiteSpace(code))
                    queryParams.Add("$code", code);
                if (!String.IsNullOrWhiteSpace(message))
                    queryParams.Add("$message", message);
                if (!String.IsNullOrWhiteSpace(timestamp))
                    queryParams.Add("$timestamp", timestamp);

                queryParams.Add("$severity", severity.ToString());

                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/error", _serviceBaseUrl, STR_PATH));
                builder.Query = queryParams.ToString();

                return await client.PostAsync(builder.ToString(), null);


            }
        }

        public async Task<HttpResponseMessage> Log(string thinkp, string thinkpInstance, string token, string owner,
            SSAPLogLevel severity, string code, string message, string timestamp)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(thinkp) || String.IsNullOrWhiteSpace(thinkpInstance) || String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_KP) };

            if (String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_TOKEN) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Config URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(thinkp))
                    queryParams.Add("$thinkp", thinkp);
                if (!String.IsNullOrWhiteSpace(thinkpInstance))
                    queryParams.Add("$kp", thinkpInstance);
                if (!String.IsNullOrWhiteSpace(token))
                    queryParams.Add("$token", token);
                if (!String.IsNullOrWhiteSpace(owner))
                    queryParams.Add("$owner", owner);
                if (!String.IsNullOrWhiteSpace(code))
                    queryParams.Add("$code", code);
                if (!String.IsNullOrWhiteSpace(message))
                    queryParams.Add("$message", message);
                if (!String.IsNullOrWhiteSpace(timestamp))
                    queryParams.Add("$timestamp", timestamp);

                queryParams.Add("$severity", severity.ToString());

                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/log", _serviceBaseUrl, STR_PATH));
                builder.Query = queryParams.ToString();

                return await client.PostAsync(builder.ToString(), null);
            }
        }

        public async Task<HttpResponseMessage> Command(string sessionKey, string thinkp, string thinkpInstance,
            SSAPCommandType type, Dictionary<string, string> args)
        {
            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Config URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(sessionKey))
                    queryParams.Add("$sessionKey", sessionKey);
                if (!String.IsNullOrWhiteSpace(thinkp))
                    queryParams.Add("$thinkp", thinkp);
                if (!String.IsNullOrWhiteSpace(thinkpInstance))
                    queryParams.Add("$kp", thinkpInstance);

                queryParams.Add("$type", type.ToString());

                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/command", _serviceBaseUrl, STR_PATH));
                builder.Query = queryParams.ToString();

                if (args == null)
                {
                    args = new Dictionary<string, string>();
                }

                return await client.PostAsJsonAsync<Dictionary<string, string>>(builder.ToString(), args);

            }
        }

        public async Task<HttpResponseMessage> SubscribeCommand(string thinkp, string thinkpInstance, string token,
            SSAPCommandType type, string endpoint)
        {
            //data validation
            if (String.IsNullOrWhiteSpace(thinkp) || String.IsNullOrWhiteSpace(thinkpInstance) || String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_KP) };

            if (String.IsNullOrWhiteSpace(token))
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(STR_BAD_REQUEST_TOKEN) };

            using (var client = new HttpClient())
            {
                //client config
                client.BaseAddress = new Uri(_serviceBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(STR_APPLICATION_HEADER));

                //Config URI
                var queryParams = HttpUtility.ParseQueryString(string.Empty);
                if (!String.IsNullOrWhiteSpace(thinkp))
                    queryParams.Add("$thinkp", thinkp);
                if (!String.IsNullOrWhiteSpace(thinkpInstance))
                    queryParams.Add("$kp", thinkpInstance);
                if (!String.IsNullOrWhiteSpace(token))
                    queryParams.Add("$token", token);
                if (!String.IsNullOrWhiteSpace(endpoint))
                    queryParams.Add("$endpoint", endpoint);

                queryParams.Add("$type", type.ToString());

                UriBuilder builder = new UriBuilder(String.Format("{0}{1}/subscribe_command", _serviceBaseUrl, STR_PATH));
                builder.Query = queryParams.ToString();

                return await client.GetAsync(builder.ToString());
            }
            
        }


        public async Task<SSAPResource> ResponseAsSSAP(HttpResponseMessage resp)
        {
            if (resp.IsSuccessStatusCode)
            {
                SSAPResource ssap = await resp.Content.ReadAsAsync<SSAPResource>();
                return ssap;
            }
            else
                return null;
        }
    }
}
