using System.ComponentModel.DataAnnotations;
namespace BusManager.Models

{
    public class Driver
    {
        public int Id { get; set; }
        [Display(Name = "Номер")]
        public string Phone { get; set; } = string.Empty;
        [Display(Name = "Имя")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Номер Лицензии")]
        public string LicenseNumber { get; set; } = string.Empty;
        [Display(Name = "Опыт работы")]
        public int ExperienceYears { get; set; }
        public ICollection<Bus> Buses { get; set; } = new List<Bus>();


    }
}
