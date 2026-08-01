using System.Text.Json;

namespace LogisticsPlanner.DataAccess;

public class TariffRepository
{
    // Path to the JSON file containing tariff data
    private readonly string _filePath;

    public TariffRepository (string filePath)
    {
        _filePath = filePath;
    }

    // Method to read tariffs from the JSON file
    public List<TariffModel> GetTariffs()
    {
        if(!File.Exists(_filePath))
        return new List<TariffModel>();

    string jsonString = File.ReadAllText(_filePath);
    
    // Configure JsonSerializer to ignore case when matching property names
    var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};

    try
        {
            return JsonSerializer.Deserialize <List<TariffModel>>(jsonString, options) ?? new List<TariffModel>();
        }
    catch
        {
            return new List<TariffModel>();
        }

    }

}