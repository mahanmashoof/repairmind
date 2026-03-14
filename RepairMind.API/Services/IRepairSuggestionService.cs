namespace RepairMind.API.Services;

public interface IRepairSuggestionService
{
    Task<string> GetSuggestionAsync(string itemName, string problemDescription);
}