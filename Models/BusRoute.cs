using System.ComponentModel.DataAnnotations;
namespace BusManager.Models

{
    public class BusRoute
    {
        public int Id { get; set; }
        public string? BusId { get; set; }
        public string? DriverId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public double DistanceKm { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? MapImagePath { get; set; }
        public ICollection<Bus> Buses { get; set; } = new List<Bus>();
        public string? RouteImagePath { get; set; }

    }
}
