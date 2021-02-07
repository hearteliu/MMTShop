using System;
using System.Net;

namespace MMTShop.Consumer
{
    public static class Consumer
    {
        /// <summary>
        /// Consumes the endpoint represented by the url
        /// </summary>
        /// <param name="url">The url to be consumed</param>
        /// <returns>The result or exception</returns>
        public static string Consume(string url)
        {
            var result = string.Empty;

            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add(Constants.Headers.ContentType);
                    client.Headers.Add(Constants.Headers.Accept);

                    result = client.DownloadString(url); 
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result;
        }
    }
}
