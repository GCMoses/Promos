using System.ComponentModel.DataAnnotations;

namespace Promo.Core.Models;
public class PromoCover
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Promo Cover")]
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
