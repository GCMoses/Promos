using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promo.Core.Models;

public class Business
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Display(Name = "Street Address")]
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    [Display(Name = "Province/State")]
    public string? State { get; set; }
    [Display(Name = "Postal Code")]
    public string? PostalCode { get; set; }
    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
   
}
