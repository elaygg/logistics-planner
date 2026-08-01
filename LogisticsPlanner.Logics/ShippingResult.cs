namespace LogisticsPlanner.Logics;

// Object model for shipping calculation results
public class ShippingResult
{
    public string CarrierName { get; set; } = string.Empty;
    public decimal TotalCost { get; set; }
    public string EstimatedDelivery { get; set; } = string.Empty;
}