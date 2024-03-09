using BenchmarkDotNet.Attributes;
using Refit;
using System.Net.Http.Json;

namespace HttpClientxRefit;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class HttpClientxRefitBenchmarks
{
    private readonly IRefitUsersApi _refitUsersApi;
    private readonly HttpClient _httpClient;

    public HttpClientxRefitBenchmarks()
    {
        _refitUsersApi = RestService.For<IRefitUsersApi>("http://localhost:8080");
        _httpClient = new HttpClient();
    }

    [Benchmark(Description = "Send request with HttpClient")]
    public async Task SendRequestWithHttpClient() => 
        await _httpClient.GetFromJsonAsync<IEnumerable<User>>("http://localhost:8081/users");

    [Benchmark(Description = "Send request with refit")]
    public async Task SendRequestWithRefit() => 
        await _refitUsersApi.GetUsers();
}
