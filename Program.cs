
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/users", async (HttpRequest request) =>
{
    
    string username = request.Query["username"].ToString();

    string connectionString =
        "Server=localhost;Database=PracticeDb;Integrated Security=true;TrustServerCertificate=true;";

    await using var connection =
        new SqlConnection(connectionString);

    
    string query =
        "SELECT * FROM Users WHERE Username = '" + username + "'";

    await using var command =
        new SqlCommand(query, connection);

    await connection.OpenAsync();

    await using var reader = await command.ExecuteReaderAsync();

    return Results.Ok(reader.HasRows);
});

app.Run();
