using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service.Service
{
    public class PushNotification
    {
        private string serverKeys = "AAAA56ixLsM:APA91bHnAPKbhhWVPpHRbo2SqYsmZrXtp4DqqCxulD7yBQuwqxuJazQvU3RFKp24Ed6SgKrAQrXLk5Xv4cXSbd05bDNzjC7x6Izcwc5Xamv8Mrz5iObzTwYnRhbvd11fzPcIgLh-j3rK";
        private string senderIds = "994967629507";

        public async Task<bool> NotifyAsync(string to, string title, string body)
        {
            try
            {
                // Get the server key from FCM console
                var serverKey = string.Format("key={0}", serverKeys);

                // Get the sender id from FCM console
                var senderId = string.Format("id={0}", senderIds);

                var data = new
                {
                    to, // Recipient device token
                    notification = new { title, body }
                };

                // Using Newtonsoft.Json
                var jsonBody = JsonConvert.SerializeObject(data);

                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send"))
                {
                    httpRequest.Headers.TryAddWithoutValidation("Authorization", serverKey);
                    httpRequest.Headers.TryAddWithoutValidation("Sender", senderId);
                    httpRequest.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient())
                    {
                        var result = await httpClient.SendAsync(httpRequest);

                        if (result.IsSuccessStatusCode)
                        {
                            return true;
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return false;
        }
    }
}
