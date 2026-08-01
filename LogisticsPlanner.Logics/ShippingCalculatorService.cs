using LogisticsPlanner.DataAccess; //Data access namespace

namespace LogisticsPlanner.Logics;

public class ShippingCalculatorService
{
    // Repository for accessing tariff data
    private readonly TariffRepository _repository;

    public ShippingCalculatorService(string tariffFilePath)
    {
        _repository = new TariffRepository(tariffFilePath);
    }

    //Calculate shipping options based on weight and destination zone
    public List<ShippingResult> CalculateShipping(double weight, string destinationZone)
    {
        var allTariffs = _repository.GetTariffs();
        var results = new List<ShippingResult>();

        //Filter tariffs based on weight and zone
        var applicableTariffs = allTariffs.Where (t=>
            t.Zone.ToLower() == destinationZone.ToLower() &&
            weight >= t.MinWeight &&
            weight <= t.MaxWeight);

        foreach (var tariff in applicableTariffs)
        {
            results.Add(new ShippingResult
            {
                CarrierName = tariff.CarrierName,
                TotalCost = Math.Max(tariff.MinPrice, Math.Min(tariff.Price * (decimal)weight, tariff.MaxPrice)),
                EstimatedDelivery = tariff.DeliveryTime
            });
        }

        return results.OrderBy(r => r.TotalCost).ToList();
    }
}