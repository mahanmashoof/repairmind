using OpenAI.Chat;

namespace RepairMind.API.Services;

public class RepairSuggestionService : IRepairSuggestionService
{
    private readonly ChatClient _chatClient;

    public RepairSuggestionService(IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"];
        _chatClient = new ChatClient("gpt-4o-mini", apiKey);
    }

    public async Task<string> GetSuggestionAsync(string itemName, string problemDescription)
    {
        var prompt = $"""
            You are a repair expert. A customer has a broken {itemName}.
            Problem: {problemDescription}
            Give a concise, practical repair suggestion in 2-3 sentences.
            """;

        var response = await _chatClient.CompleteChatAsync(prompt);
        return response.Value.Content[0].Text;
    }
}