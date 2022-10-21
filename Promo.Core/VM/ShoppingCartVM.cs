using Promo.Core.Models;

namespace Promo.Core.VM;

public class ShoppingCartVM
{
    public IEnumerable<ShoppingCart> ListCart { get; set; }
    
    public OrderHeader OrderHeader { get; set; }
}

