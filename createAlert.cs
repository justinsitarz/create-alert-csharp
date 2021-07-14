using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebAPIClient
{
    class Program
    {

    	private static readonly HttpClient client = new HttpClient();

		static async Task Main(string[] args)
		{
		    await ProcessRepositories();
		}

		private static async Task ProcessRepositories()
		{
		    var url = "https://api.opsgenie.com/v2/alerts";
		    var payload = "{\"message\": \"Does this thing work?\",\"alias\": \"My really cool alias\"}";

            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

		    client.DefaultRequestHeaders.Accept.Clear();
		    client.DefaultRequestHeaders.Accept.Add(
		        new MediaTypeWithQualityHeaderValue("application/json"));
		    client.DefaultRequestHeaders.Add("Authorization", "GenieKey <YOUR API KEY>");

		    var stringTask = client.PostAsync(url, content);

		    var msg = await stringTask;
		    Console.Write(msg);
		}
    }
}
