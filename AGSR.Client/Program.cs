using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

string apiUrl = $"http://172.24.0.3:80/WeatherForecast";

using (var httpClientHandler = new HttpClientHandler())
{
    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
    {
        return true;
    };

    using (var httpClient = new HttpClient(httpClientHandler))
    {
        var response = await httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
        else
        {
            Console.WriteLine("An error occurred: " + response.StatusCode);
        }
    }
}
