using System.Text.Json.Serialization;
using BlazingPizza.ComponentsLibrary.Map;


namespace BlazingPizza;

public class OrderWithStatus
{
    public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);
    public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);

    public Order Order { get; set; }

    public string StatusText { get; set; }

    public bool IsDelivered => StatusText == "Doręczona";

    public List<Marker> MapMarkers { get; set; }

    public static OrderWithStatus FromOrder(Order order)
    {
        string statusText;
        List<Marker> mapMarkers;
        var dispatchTime = order.CreatedTime.Add(PreparationDuration);

        if (DateTime.Now < dispatchTime)
        {
            statusText = "W przygotowaniu";
            mapMarkers = new List<Marker>
                                {
                                        ToMapMarker("Ty", order.DeliveryLocation, showPopup: true)
                                };
        }
        else if (DateTime.Now < dispatchTime + DeliveryDuration)
        {
            statusText = "Wydana do doręczenia";

            var startPosition = ComputeStartPosition(order);
            var proportionOfDeliveryCompleted = Math.Min(1, (DateTime.Now - dispatchTime).TotalMilliseconds / DeliveryDuration.TotalMilliseconds);
            var driverPosition = LatLong.Interpolate(startPosition, order.DeliveryLocation, proportionOfDeliveryCompleted);
            mapMarkers = new List<Marker>
                                {
                                        ToMapMarker("Ty", order.DeliveryLocation),
                                        ToMapMarker("Kierowca", driverPosition, showPopup: true),
                                };
        }
        else
        {
            statusText = "Doręczona";
            mapMarkers = new List<Marker>
                                {
                                        ToMapMarker("Adres dostawy", order.DeliveryLocation, showPopup: true),
                                };
        }

        return new OrderWithStatus
        {
            Order = order,
            StatusText = statusText,
            MapMarkers = mapMarkers,
        };
    }

    private static LatLong ComputeStartPosition(Order order)
    {
        // Random but deterministic based on order ID
        var rng = new Random(order.OrderId);
        var distance = 0.01 + rng.NextDouble() * 0.02;
        var angle = rng.NextDouble() * Math.PI * 2;
        var offset = (distance * Math.Cos(angle), distance * Math.Sin(angle));
        return new LatLong(order.DeliveryLocation.Latitude + offset.Item1, order.DeliveryLocation.Longitude + offset.Item2);
    }

    static Marker ToMapMarker(string description, LatLong coords, bool showPopup = false)
            => new Marker { Description = description, X = coords.Longitude, Y = coords.Latitude, ShowPopup = showPopup };
}