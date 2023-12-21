using System.Text;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("sec-ch-ua", "Opera GX");
        while (true)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.discord.gx.games/v1/direct-fulfillment");
            string data = "{\"partnerUserId\":\"6fe29500cdd1c6c621b8ecbefd7e9c4b02f37b947b6e632df730c4789df497cd\"}";
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            JsonDocument doc = JsonDocument.Parse(responseContent);
            string token = doc.RootElement.GetProperty("token").GetString();
            Console.WriteLine("https://discord.com/billing/partner-promotions/1180231712274387115/" + token);
            Console.ReadLine();
        }
    }
}
