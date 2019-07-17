using System.ComponentModel.DataAnnotations;

namespace flowershop.Models
{
  public class Flower
  {
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Description { get; set; }
    public int Quantity { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public double Price { get; set; }
  }
}