using System.ComponentModel.DataAnnotations;
namespace BusManager.Models

{
    public class Bus
{
    public int Id { get; set; }

    [Display(Name = "Модель")]
    public string Model { get; set; } = string.Empty;
    [Display(Name = "Номер")]
    public string Number { get; set; } = string.Empty; 
    [Display(Name = "Вместимость")]
    public int Capacity { get; set; }
    [Display(Name = "Статус")]
    public string Status { get; set; } = string.Empty;
    public int? DriverId { get; set; }
    public Driver? Driver { get; set; }
    public int? RouteId { get; set; }
    public BusRoute? Route { get; set; }
    public ICollection<Repair> Repairs { get; set; } = new List<Repair>();
}
}
