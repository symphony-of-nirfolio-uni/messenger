using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Messenger
{
    class HttpRequests
    {
        public static readonly HttpClient client = new HttpClient();

        public async Task SendMessage(string sender, string receiver, string message)
        {

            var values = new Dictionary<string, string>
            {
               { "sender", sender },
               { "receiver", receiver },
               { "message", message }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:8080/send_message", content);

            var responseString = await response.Content.ReadAsStringAsync();

            System.Console.WriteLine(responseString);
        }

        public async Task<string> GetMessages(string sender, string receiver)
        {

            var values = new Dictionary<string, string>
            {
               { "sender", sender },
               { "receiver", receiver }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:8080/get_messages", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;

            //System.Console.WriteLine(responseString);
        }

        public async Task<string> DeleteMessages(string sender, string receiver)
        {

            var values = new Dictionary<string, string>
            {
               { "sender", sender },
               { "receiver", receiver }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:8080/delete_messages", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;

            //System.Console.WriteLine(responseString);
        }
    }
}
    