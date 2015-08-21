using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace ReplayGG.Replays
{

    public class ReplayWebRequest
    {

        public ReplayWebRequest() { }

        public string GetPlainResponse(Uri uri)
        {
            HttpWebRequest webRequest = this.CreateWebRequest(uri);

            using (HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse())
            using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                return streamReader.ReadToEnd();
        }

        public byte[] GetByteArrayResponse(Uri uri)
        {
            HttpWebRequest webRequest = this.CreateWebRequest(uri);

            using (HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse())
            using (Stream stream = webResponse.GetResponseStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }

        public T GetJsonResponse<T>(Uri uri)
        {
            HttpWebRequest webRequest = this.CreateWebRequest(uri);

            using (HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse())
            using (StreamReader streamReader = new StreamReader(webResponse.GetResponseStream()))
                return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
        }

        private HttpWebRequest CreateWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = HttpWebRequest.CreateHttp(uri);

            webRequest.Method = "GET";

            return webRequest;
        }

    }

}
