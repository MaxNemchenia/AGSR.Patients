using AGSR.Patients.ServiceContracts.Dtos.Patient;
using AGSR.Patients.ServiceContracts.Enums;
using System.Text;
using System.Text.Json;

Console.WriteLine("Initiating API request...");

var url = Environment.GetEnvironmentVariable("PATIENTS_API_URL", EnvironmentVariableTarget.Process);
var endpoint = "/Patient/add-batch";
var uri = new Uri(url + endpoint);

var patients = GeneratePatients();
var patientsJson = JsonSerializer.Serialize(patients);

using var httpClientHandler = new HttpClientHandler();

//was used here to bypass the default certificate validation process.
httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
{
    return true;
};

using var httpClient = new HttpClient(httpClientHandler);

var maxAttempts = 5;

for (int attempt = 1; attempt <= maxAttempts; attempt++)
{
    try
    {
        Console.WriteLine("Sending API request (Attempt #" + attempt + ")...");
        var response = await SendRequestAsync(httpClient, patientsJson, uri);
        Console.WriteLine($"Request sent to: {uri}");
        Console.WriteLine($"Response status: {response.StatusCode}");
        Console.WriteLine("API request completed.");

        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Attempt #{attempt} failed: {ex.Message}");
        if (attempt < maxAttempts)
        {
            Console.WriteLine("Retrying...");
            await Task.Delay(10000);
        }
        else
        {
            Console.WriteLine("Maximum attempts reached. API request unsuccessful.");
        }
    }
}

Task<HttpResponseMessage> SendRequestAsync(HttpClient httpClient, string json, Uri uri)
{

    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

    return httpClient.PostAsync(uri, httpContent);
}

static IEnumerable<PatientDto> GeneratePatients()
    => Enumerable.Range(1, 100).Select(
        x => new PatientDto()
        {
            Name = new PatientName()
            {
                Id = Guid.NewGuid(),
                Use = "official",
                Family = $"surname{x}",
                Given = new List<string>() { $"Name{x}", $"FatherName{x}" },
            },
            Gender = Gender.Other,
            BirthDate = DateTime.UtcNow,
            Active = true,
        })
        .ToList();
