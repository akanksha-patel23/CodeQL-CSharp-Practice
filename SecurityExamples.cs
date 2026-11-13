
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeQLCSharpPractice
{
public static class SecurityExamples
{
    // Example 1: Hardcoded credential
    public static string GetCredential()
    {
        const string apiKey = "MySecretApiKey123";
        return apiKey;
    }

    // Example 2: Weak random number generation
    public static string GenerateToken()
    {
        var random = new Random();

        return random.Next(100000, 999999).ToString();
    }

    // Example 3: Path traversal risk
    public static string ReadFile(string fileName)
    {
        string basePath = Path.Combine(
            Directory.GetCurrentDirectory(), "PracticeFiles");

        string filePath = Path.Combine(basePath, fileName);

        return File.ReadAllText(filePath);
    }
    // Example 4: Clear-text HTTP
        public static async Task<string> InsecureHttp()
        {
            using var client = new HttpClient();

            return await client.GetStringAsync(
                "http://example.com");
        }

        // Example 5: Weak cryptographic key
        public static byte[] WeakKey()
        {
            return new byte[8];
        }
}
}