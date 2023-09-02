using System.Data.SqlClient;
using Testcontainers.MsSql;

public class Program
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

        await RunScript(connectionString, "./Scripts/CreateTable.sql");
        await RunScript(connectionString, "./Scripts/Insert.sql");

        await container.StopAsync();
    }

    public static async Task RunScript(string connectionString, string scriptPath)
    {
        var script = await File.ReadAllTextAsync(scriptPath);

        await using var connection = new SqlConnection(connectionString);
        connection.Open();

        await using var command = new SqlCommand(script, connection);
        await command.ExecuteNonQueryAsync();

        connection.Close();
    }
}