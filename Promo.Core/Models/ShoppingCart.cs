using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promo.Core.Models;

public class ShoppingCart
{
    public int Id { get; set; }

    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    [ValidateNever]
    public Product Product { get; set; }
    [Range(1, 10000, ErrorMessage = "Item must be greater than 0.")]
    public int Count { get; set; }

    public string AppUserId { get; set; }
    [ForeignKey("AppUserId")]
    [ValidateNever]
    public AppUser AppUser { get; set; }
    [NotMapped]
    public double Price { get; set; }
}
