using System.Text;
using Client.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;


namespace Client;

internal class Program
{
    static readonly string inputText = @"C:\ClientService\in.txt";
    static readonly string outputText = @"C:\ClientService\out.txt";
    static readonly string url = @"https://localhost:7052/api/Reverse";

    static async Task Main(string[] args)
    {

        var hostBuilder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHttpClient();
                services.AddScoped<DataReader>();
            }).UseConsoleLifetime();

        var host = hostBuilder.Build();

        try
        {
            var reader = host.Services.GetRequiredService<DataReader>(); 
            var fileContent = reader.GetData(inputText);
            var lines = new List<string>();
            var clientFactory = host.Services.GetRequiredService<IHttpClientFactory>();

            foreach (var text in fileContent)
            {
                var request = new { Text = text.Text };
                var jsonReq = JsonConvert.SerializeObject(request);

                using var client = clientFactory.CreateClient();
                var httpResponse = await client.PostAsync(url, new StringContent(jsonReq, Encoding.UTF8, "application/json"));
                var response = await httpResponse.Content.ReadAsStringAsync();

                lines.Add(response);
            }
            File.WriteAllLines(outputText, lines.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    }
}