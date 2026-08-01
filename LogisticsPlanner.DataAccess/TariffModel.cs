namespace LogisticsPlanner.DataAccess;

public class TariffModel
{
    public string CarrierName {get; set;} = string.Empty;
    public double MinWeight {get; set;}
    public double MaxWeight {get; set;}
    public decimal Price {get; set;}
    public decimal MinPrice {get; set;}
    public decimal MaxPrice {get; set;}
    public string Zone {get; set;} = string.Empty;
    public string DeliveryTime {get; set;} = string.Empty;
}