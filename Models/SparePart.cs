using System.ComponentModel.DataAnnotations;
namespace BusManager.Models

{
    public class SparePart
    {
        public int Id { get; set; }
        [Display(Name = "Название Детали")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Количество на складе")]
        public int Quantity { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
    }
}
