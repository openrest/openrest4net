﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace wixrest.v2_0
{
    public class WixClient
    {
        private readonly RestJsonClient restJsonClient;
        private Uri _baseUri;

        public WixClient(Uri uri)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new RestaurantObjectJsonConvertor());
            settings.Converters.Add(new RequestJsonConvertor());
            _baseUri = uri;
            restJsonClient = new RestJsonClient(settings);
        }

        public async Task<T> Post<T>(string endpointUri, Object obj,string token = null)
        {
            try {
                var response =  await restJsonClient.PostAsync<T>(new Uri(_baseUri,endpointUri),token, obj);
                await VerifyResponse(response);
                return await response.Content.ReadAsAsync<T>(new List<MediaTypeFormatter>(){restJsonClient.Formatter});
            } catch (WixHttpException e) {
                throw;
            }
        }

        public async Task<T> Put<T>(string endpointUri, object obj, string token)
        {
            try {
                var response =  await restJsonClient.PutAsync<T>(new Uri(_baseUri,endpointUri),token, obj);
                await VerifyResponse(response);
                return await response.Content.ReadAsAsync<T>(new List<MediaTypeFormatter>(){restJsonClient.Formatter});
            } catch (WixHttpException e) {
                throw;
            }
        }

        public async Task<T> Get<T>(string endpointUri)
        {
            try {
                var response =  await restJsonClient.GetAsync<T>(new Uri(_baseUri,endpointUri));
                await VerifyResponse(response);
                return await response.Content.ReadAsAsync<T>(new List<MediaTypeFormatter>(){restJsonClient.Formatter});
            } catch (WixHttpException e) {
                throw;
            }
        }

        private static async Task VerifyResponse(HttpResponseMessage response) {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var error = await response.Content.ReadAsAsync<WixError>(new List<MediaTypeFormatter>()
                    {
                        new JsonMediaTypeFormatter()
                        {
                            SupportedMediaTypes =
                            {
                                new MediaTypeHeaderValue("application/problem+json"),
                            }
                        }
                    });
                    throw new WixHttpException(error.title,
                        error.detail,
                        error.status, error.type);
                }
                catch (Exception ex)
                {
                    throw new WixHttpException("Api Error",
                        "",
                        response.StatusCode,
                        response.EnsureSuccessStatusCode().ReasonPhrase);
                }
            }
        }

     
    }

    internal class WixError
    {
        public string type { get; set; }
        public string title { get; set; }
        public HttpStatusCode status { get; set; }
        public string detail { get; set; }
    }
}