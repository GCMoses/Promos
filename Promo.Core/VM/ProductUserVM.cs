using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Promo.Core.Models;

namespace Promo.Core.VM;

public class ProductUserVM
{
    public ProductUserVM()
    {
        ProductList = new List<Product>();
    }

    public AppUser AppUser { get; set; }
    public IList<Product> ProductList { get; set; }
}
