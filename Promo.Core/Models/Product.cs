using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Promo.Core.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Display(Name ="Email")] //made a mistake when I named it social link
    public string SocialLink { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ContactDetails { get; set; }
    [ValidateNever]
    public string WhatsApp { get; set; }
    [ValidateNever]
    public string Facebook { get; set; }
    [ValidateNever]
    public string Instagram { get; set; }


    [Required]
    [Range(1, 10000)]
    [Display(Name = "Item Price")]
    public double ListPrice { get; set; }
    [Required]
    [Range(1, 10000)]
    [Display(Name = "Price for 1-50 items")]
    public double Price { get; set; }
    [Required]
    [Range(1, 10000)]
    [Display(Name = "Price for 51-100 items")]
    public double Price50 { get; set; }

    [Required]
    [Range(1, 10000)]
    [Display(Name = "Price for 100+")]
    public double Price100 { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }
    [Display(Name = "Category")]
    [Required]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    [ValidateNever]
    public Category Category { get; set; }
    [Display(Name = "Item Cover")]
    [Required]
    public int PromoCoverId { get; set; }
    [ValidateNever]

    public PromoCover PromoCover { get; set; }
}
