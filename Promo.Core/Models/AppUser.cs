using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promo.Core.Models;


public class AppUser : IdentityUser
{
    [Required]
    public string Name { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    [Display(Name = "Province/State")]
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public int? BusinessId { get; set; }
    [ForeignKey("BusinessId")]
    [ValidateNever]
    public Business Business { get; set; }
}
