using System;
using System.ComponentModel.DataAnnotations;

namespace BusManager.Models
{
    public class Repair
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public double Cost { get; set; }

        public int BusId { get; set; }
        public Bus? Bus { get; set; }
    }
}
