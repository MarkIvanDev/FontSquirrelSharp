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
using System.Collections.Generic;
using System.Text;

namespace FontSquirrelSharp
{
    public class Font
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName { get; set; }

        [JsonProperty("family_urlname")]
        public string FamilyUrlName { get; set; }

        [JsonProperty("foundry_name")]
        public string FoundryName { get; set; }

        [JsonProperty("foundry_urlname")]
        public string FoundryUrlName { get; set; }

        [JsonProperty("font_filename")]
        public string FileName { get; set; }

        [JsonProperty("is_monocase")]
        [JsonConverter(typeof(IsMonocaseConverter))]
        public bool IsMonocase { get; set; }

        [JsonProperty("family_count")]
        public int FamilyCount { get; set; }
    }
}
