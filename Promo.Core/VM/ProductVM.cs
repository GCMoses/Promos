using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Promo.Core.Models;

namespace Promo.Core.VM;

public class ProductVM
{
    public Product Product { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> CategoryList { get; set; }
    [ValidateNever]
    public IEnumerable<SelectListItem> PromoCoverList { get; set; }

}
