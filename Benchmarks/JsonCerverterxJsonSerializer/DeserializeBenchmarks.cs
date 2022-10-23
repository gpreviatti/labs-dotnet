using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace JsonCerverterxJsonSerializer;

[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class DeserializeBenchmarks
{
    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    [Benchmark(Description = "Deserialize object with JsonSeriealizer")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task DeserializeWithJsonSerializer(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var stringContent = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(person, _serializerOptions),
            Encoding.UTF8,
            "application/json"
        );

        var stream = await stringContent.ReadAsStreamAsync();

        await System.Text.Json.JsonSerializer.DeserializeAsync<List<PersonEntity>>(stream);
    }

    [Benchmark(Description = "Deserialize object with JsonSeriealizer Async")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task DeserializeWithJsonSerializerAsync(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var content = await GetJson(person);

        var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

        var stream = await stringContent.ReadAsStreamAsync();

        await System.Text.Json.JsonSerializer.DeserializeAsync<List<PersonEntity>>(stream);
    }

    [Benchmark(Description = "Deserialize object with JsonConvert (NewtonSoft)")]
    [Arguments(1, 10)]
    [Arguments(10, 100)]
    [Arguments(100, 200)]
    public async Task DeserializeWithJsonConvert(int amountPeople, int amountAccounts)
    {
        var person = PersonEntity.GetPerson(amountPeople, amountAccounts);

        var stringContent = new StringContent(
            JsonConvert.SerializeObject(person),
            Encoding.UTF8,
            "application/json"
        );

        var stream = await stringContent.ReadAsStringAsync();

        JsonConvert.DeserializeObject<List<PersonEntity>>(stream);
    }

    
    private static async Task<string> GetJson(object obj)
    {
        using var stream = new MemoryStream();

        await System.Text.Json.JsonSerializer.SerializeAsync(stream, obj, obj.GetType());

        stream.Position = 0;
        using var reader = new StreamReader(stream);

        return await reader.ReadToEndAsync();
    }
}
