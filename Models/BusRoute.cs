namespace BusManager.Models
{
    public class BusRoute
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public double DistanceKm { get; set; }
    }
}
