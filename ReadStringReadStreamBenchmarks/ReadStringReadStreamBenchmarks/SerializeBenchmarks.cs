using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Text.Json;

namespace ReadStringReadStreamBenchmarks;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class SerializeBenchmarks
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Benchmark(Description = "Serialize object with JsonSeriealizer")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public void SerializeWithJsonSerializer(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        System.Text.Json.JsonSerializer.Serialize(person, _serializerOptions);
    }

    [Benchmark(Description = "Serialize object with JsonSeriealizerAsync")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task SerializeWithJsonSerializerAsync(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var stream = new MemoryStream();

        await System.Text.Json.JsonSerializer.SerializeAsync(stream, person, _serializerOptions);
    }

    [Benchmark(Description = "Serialize object with JsonConvert (NewtonSoft)")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public void SerializeWithJsonConvert(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        JsonConvert.SerializeObject(person);
    }
}
