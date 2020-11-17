using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class EncodeAndDecodeTinyURL
    {
        // 535. Encode and Decode TinyURL
        // Not a good question IMO
        private IDictionary<string, string> _dict = new Dictionary<string, string>();
        private string _base = @"http://tinyurl.com/";

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            var hash = longUrl.GetHashCode();
            _dict.Add(hash.ToString(), longUrl);
            return _base + hash.ToString();
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            var hashPart = shortUrl.Split('/')[^1];
            _dict.TryGetValue(hashPart, out string result);
            return result;
        }
    }
}
