﻿using BenchmarkDotNet.Attributes;
using Refit;
using System.Net.Http.Json;

namespace HttpClientxRefit;

[MemoryDiagnoser]
[HardwareCounters]
[MarkdownExporter]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class HttpClientxRefitBenchmarks
{
    private IRefitUsersApi? refitUsersApi;
    private HttpClient? httpClient;

    [GlobalSetup]
    public void Setup()
    {
        refitUsersApi = RestService.For<IRefitUsersApi>("http://localhost:8080");
        httpClient = new HttpClient();
    }

    [Benchmark(Description = "Send request with HttpClient")]
    public async Task SendRequestWithHttpClient() => 
        await httpClient!.GetFromJsonAsync<IReadOnlyCollection<User>>("http://localhost:8081/users");

    [Benchmark(Description = "Send request with refit")]
    public async Task SendRequestWithRefit() => 
        await refitUsersApi!.GetUsers();
}