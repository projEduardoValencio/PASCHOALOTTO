using System.Text.Json;
using RandomuserConsumer.Communication.Responses.RandomUserApi;

namespace RandomUserConsumer.Application.Provider;

public class RandomUserApiProvider
{
    public static async Task<T> GetRandomUser<T>()
    {
        var response = await new HttpClient().GetAsync("https://randomuser.me/api/");
        response.EnsureSuccessStatusCode();
        
        string json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        });
    }
}