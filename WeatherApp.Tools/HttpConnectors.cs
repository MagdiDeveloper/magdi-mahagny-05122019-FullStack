using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tools.Logger;

namespace WeatherApp.Tools
{
    namespace Tools
    {
        public static class HttpConnectors
        {
            public static class Rest
            {
                public static T Post<T>(string serviceUrl, object data, string authorizationToken = null) where T : class
                {
                    T resp = null;
                    using (var client = new HttpClient())
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(authorizationToken))
                            {
                                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorizationToken);
                            }

                            StringContent sc = BuildStringContent(data, client);
                            HttpResponseMessage response = client.PostAsync(serviceUrl, sc).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                string content = response.Content.ReadAsStringAsync().Result;
                                resp = JsonConvert.DeserializeObject<T>(content);
                            }
                            else
                            {
                                throw new Exception(response.ReasonPhrase);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message);
                        }
                    }
                    return resp;
                }

                public async static Task<T> PostAsync<T>(string serviceUrl, object data, string authorizationToken = null) where T : class
                {
                    T resp = null;

                    using (var client = new HttpClient())
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(authorizationToken))
                            {
                                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorizationToken);
                            }
                            StringContent sc = BuildStringContent(data, client);
                            HttpResponseMessage response = await client.PostAsync(serviceUrl, sc);
                            if (response.IsSuccessStatusCode)
                            {
                                string content = await response.Content.ReadAsStringAsync();
                                resp = JsonConvert.DeserializeObject<T>(content);
                            }
                            else
                            {
                                throw new Exception(response.ReasonPhrase);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message);
                        }
                    }

                    return resp;
                }

                public static T Get<T>(string serviceUrl, string authorizationToken = null) where T : class
                {
                    T resp = null;
                    using (var client = new HttpClient())
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(authorizationToken))
                            {
                                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorizationToken);
                            }
                            HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                string content = response.Content.ReadAsStringAsync().Result;
                                resp = JsonConvert.DeserializeObject<T>(content);
                            }
                            else
                            {
                                throw new Exception(response.ReasonPhrase);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message);
                        }
                    }
                    return resp;
                }

                public static async Task<T> GetAsync<T>(string serviceUrl, string authorizationToken = null) where T : class
                {
                    return await Task.Run(async () =>
                    {
                        T resp = null;
                        using (var client = new HttpClient())
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(authorizationToken))
                                {
                                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorizationToken);
                                }
                                HttpResponseMessage response = await client.GetAsync(serviceUrl);
                                if (response.IsSuccessStatusCode)
                                {
                                    string content = await response.Content.ReadAsStringAsync();
                                    resp = JsonConvert.DeserializeObject<T>(content);
                                }
                                else
                                {
                                    throw new Exception(response.ReasonPhrase);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex.Message);
                            }
                        }
                        return resp;
                    });

                }

                private static StringContent BuildStringContent(object data, HttpClient client)

                {
                    string req = JsonConvert.SerializeObject(data);
                    return new StringContent(req, Encoding.UTF8, "application/json");

                }
            }

            public static class Custom
            {
                public static string Post<T>(string serviceUrl, object data) where T : class
                {
                    string resp = null;
                    using (var client = new HttpClient())
                    {
                        try
                        {
                            StringContent sc = BuildStringContent(data, client);
                            HttpResponseMessage response = client.PostAsync(serviceUrl, sc).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                resp = response.Content.ReadAsStringAsync().Result;
                            }
                            else
                            {
                                throw new Exception(response.ReasonPhrase);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message);
                        }
                    }
                    return resp;
                }

                public static string PostAsync<T>(string serviceUrl, object data) where T : class
                {
                    string resp = null;
                    Task.Run(async () =>
                    {
                        using (var client = new HttpClient())
                        {
                            try
                            {
                                StringContent sc = BuildStringContent(data, client);
                                HttpResponseMessage response = client.PostAsync(serviceUrl, sc).Result;
                                if (response.IsSuccessStatusCode)
                                {
                                    resp = await response.Content.ReadAsStringAsync();

                                }
                                else
                                {
                                    throw new Exception(response.ReasonPhrase);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex.Message);
                            }
                        }
                    });
                    return resp;
                }

                public static string Get<T>(string serviceUrl) where T : class
                {
                    string resp = null;
                    using (var client = new HttpClient())
                    {
                        try
                        {
                            HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                resp = response.Content.ReadAsStringAsync().Result;
                            }
                            else
                            {
                                throw new Exception(response.ReasonPhrase);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex.Message);
                        }
                    }
                    return resp;
                }

                public static async Task<string> GetAsync<T>(string serviceUrl) where T : class
                {
                    return await Task.Run(async () =>
                    {
                        string resp = null;
                        using (var client = new HttpClient())
                        {
                            try
                            {
                                HttpResponseMessage response = await client.GetAsync(serviceUrl);
                                if (response.IsSuccessStatusCode)
                                {
                                    resp = await response.Content.ReadAsStringAsync();

                                }
                                else
                                {
                                    throw new Exception(response.ReasonPhrase);
                                }
                            }
                            catch (Exception ex)
                            {
                                Logger.Error(ex.Message);
                            }
                        }
                        return resp;
                    });

                }

                private static StringContent BuildStringContent(object data, HttpClient client)

                {
                    string req = JsonConvert.SerializeObject(data);
                    return new StringContent(req, Encoding.UTF8, "application/json");

                }
            }
        }
    }
}
