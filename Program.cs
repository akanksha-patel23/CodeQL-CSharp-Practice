
// using Microsoft.Data.SqlClient;

// var builder = WebApplication.CreateBuilder(args);

// var app = builder.Build();

// app.MapGet("/users", async (HttpRequest request) =>
// {
    
//     string username = request.Query["username"].ToString();

//     string connectionString =
//         "Server=localhost;Database=PracticeDb;Integrated Security=true;TrustServerCertificate=true;";

//     await using var connection =
//         new SqlConnection(connectionString);

// string query =
//     "SELECT * FROM Users WHERE Username = '" + username;
    
// //     string query =
// //     "SELECT * FROM Users WHERE Username = @Username";

// // await using var command =
// //     new SqlCommand(query, connection);

// // command.Parameters.AddWithValue("@Username", username);

//     await connection.OpenAsync();

//     await using var command = new SqlCommand(query, connection);
//     await using var reader = await command.ExecuteReaderAsync();

//     return Results.Ok(reader.HasRows);
// });


// app.MapGet("/hash", (string input) =>
// {
//     using var md5 = System.Security.Cryptography.MD5.Create();

//     byte[] hash = md5.ComputeHash(
//         System.Text.Encoding.UTF8.GetBytes(input));

//     return Results.Ok(Convert.ToHexString(hash));
// });

// app.Run();



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/credential", () =>
    Results.Ok(SecurityExamples.GetCredential()));

app.MapGet("/token", () =>
    Results.Ok(SecurityExamples.GenerateToken()));

app.MapGet("/file", (string fileName) =>
    Results.Ok(SecurityExamples.ReadFile(fileName)));

app.MapGet("/greeting", (string name) =>
    Results.Content($"<h1>Hello, {name}</h1>", "text/html"));

app.Run();
