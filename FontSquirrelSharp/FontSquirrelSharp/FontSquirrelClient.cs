// MIT License

// Copyright(c) 2020 Mark Ivan Basto

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FontSquirrelSharp
{
    public class FontSquirrelClient : IDisposable
    {
        private readonly HttpClient httpClient;

        public FontSquirrelClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.fontsquirrel.com/");
        }

        public async Task<Collection<Classification>> GetClassifications()
        {
            try
            {
                var response = await httpClient.GetAsync("api/classifications");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Collection<Classification>>(json);
                }
                return new Collection<Classification>();
            }
            catch (Exception)
            {
                return new Collection<Classification>();
            }
        }

        public async Task<Collection<Font>> GetFonts()
        {
            try
            {
                var response = await httpClient.GetAsync("api/fontlist/all");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Collection<Font>>(json);
                }
                return new Collection<Font>();
            }
            catch (Exception)
            {
                return new Collection<Font>();
            }
        }

        public async Task<Collection<Font>> GetFonts(string classification)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/fontlist/{classification}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Collection<Font>>(json);
                }
                return new Collection<Font>();
            }
            catch (Exception)
            {
                return new Collection<Font>();
            }
        }

        public async Task<Family> GetFamily(string familyUrlName)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/familyinfo/{familyUrlName}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var info = JsonConvert.DeserializeObject<Collection<Family>>(json);
                    return info.FirstOrDefault();
                }
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public string GetKitUrl(string familyUrlName)
        {
            return $"https://www.fontsquirrel.com/fontfacekit/{familyUrlName}";
        }

        public async Task<Stream> GetKitStream(string familyUrlName)
        {
            try
            {
                var response = await httpClient.GetAsync($"fontfacekit/{familyUrlName}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStreamAsync();
                }
                return default;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public string GetFontUrl(string familyUrlName)
        {
            return $"https://www.fontsquirrel.com/fonts/{familyUrlName}";
        }

        public string GetFoundryUrl(string foundryUrlName)
        {
            return $"https://www.fontsquirrel.com/fonts/list/foundry/{foundryUrlName}";
        }

        public string GetLicenseUrl(string familyUrlName)
        {
            return $"https://www.fontsquirrel.com/license/{familyUrlName}";
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
