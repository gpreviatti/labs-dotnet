using System.Data.SqlClient;
using System.Diagnostics;
using SqlServerTestContainer.Database.Models;
using Testcontainers.MsSql;
// ReSharper disable All

namespace SqlServerTestContainer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var container = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2017-GA-ubuntu")
            .WithPassword("29d80fda-bb5e-49ab-81ce-8c057dfaae55")
            .WithCleanUp(true)
            .Build();

        await container.StartAsync();

        var connectionString = container.GetConnectionString().Replace("localhost", "127.0.0.1");
        Console.WriteLine(connectionString);

        await RunScript(connectionString, "./Scripts/CreateTable.sql");
        await RunScript(connectionString, "./Scripts/Insert.sql");

        var people = await GetPeople(connectionString);

        Debug.Assert(people!.Any());

        await container.StopAsync();
    }

    private static async Task<IEnumerable<Person>?> GetPeople(string connectionString)
    {
        await using var connection = new SqlConnection(connectionString);

        connection.Open();

        var sqlQuery = "SELECT * FROM Person";

        await using var command = new SqlCommand(sqlQuery, connection);

        await using var reader = await command.ExecuteReaderAsync();

        var people = new List<Person>();

        while (reader.Read())
        {
            people.Add(new()
            {
                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Email = reader.GetString(reader.GetOrdinal("Email"))
            });
        }

        return people;
    }

    static async Task RunScript(string connectionString, string scriptPath)
    {
        var script = await File.ReadAllTextAsync(scriptPath);

        await using var connection = new SqlConnection(connectionString);

        connection.Open();

        await using var command = new SqlCommand(script, connection);

        await command.ExecuteNonQueryAsync();

        connection.Close();
    }
}