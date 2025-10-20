namespace BusManager.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public Bus? Bus { get; set; }
        public string BusNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public DateTime RepairDate { get; set; }
    }
}
