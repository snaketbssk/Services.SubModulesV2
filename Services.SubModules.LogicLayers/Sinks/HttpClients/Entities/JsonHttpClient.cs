// Copyright 2015-2022 Serilog Contributors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Http;

namespace Services.SubModules.LogicLayers.Sinks.HttpClients.Entities
{
    /// <summary>
    /// HTTP client sending JSON over the network.
    /// </summary>
    /// <seealso cref="JsonGzipHttpClient"/>
    /// <seealso cref="IHttpClient"/>
    public class JsonHttpClient : IHttpClient
    {
        private const string apiUri = "/api/LogEvents";
        private const string JsonContentType = "application/json";
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonHttpClient"/> class with
        /// specified HTTP client.
        /// </summary>
        public JsonHttpClient(string apiKey, HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiKey = apiKey;
        }

        ~JsonHttpClient()
        {
            Dispose(false);
        }

        /// <inheritdoc />
        public virtual void Configure(IConfiguration configuration)
        {
        }

        /// <inheritdoc />
        public virtual async Task<HttpResponseMessage> PostAsync(string requestUri, Stream contentStream)
        {
            var uri = $"{requestUri}{apiUri}";
            using var content = new StreamContent(contentStream);
            content.Headers.Add("Content-Type", JsonContentType);
            content.Headers.Add("X-Api-Key", _apiKey);

            var s = await content.ReadAsStringAsync();

            var response = await _httpClient
                .PostAsync(uri, content)
                .ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _httpClient.Dispose();
            }
        }
    }
}
