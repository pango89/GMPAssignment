using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMPAssignment.Models
{
    public class Cart
    {
        // Key: Product Id
        // Value: CartItem
        public Dictionary<int, CartItem> CartItemsMap { get; private set; }

        public Cart()
        {
            this.CartItemsMap = new Dictionary<int, CartItem>();
        }

        public void AddProductToCart(Product product, int quantity)
        {
            if (!this.CartItemsMap.ContainsKey(product.Id))
                this.CartItemsMap.Add(product.Id, new CartItem(product, 0));

            this.CartItemsMap[product.Id].UpdateAdditionalQuantity(quantity);
        }

        public double GetTotalCartValue()
        {
            return this.CartItemsMap.Sum(x => x.Value.GetCartItemValue());
        }

        public void RemoveProductFromCart(int productId)
        {
            if (this.CartItemsMap.ContainsKey(productId))
                this.CartItemsMap.Remove(productId);
        }

        public override string ToString()
        {
            if (this.CartItemsMap.Count == 0)
                return "CART Empty!";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<int, CartItem> entry in this.CartItemsMap)
            {                
                sb.Append(entry.Value.ToString());
                sb.Append('\n');
            }

            return sb.ToString();
        }
    }
}
