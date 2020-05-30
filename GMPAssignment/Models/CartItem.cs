namespace GMPAssignment.Models
{
    public class CartItem
    {
        public CartItem(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }

        public void UpdateAdditionalQuantity(int quantity)
        {
            this.Quantity += quantity;
        }

        public double GetCartItemValue()
        {
            return this.Quantity * this.Product.Price;
        }

        public override string ToString()
        {
            return this.Product.Id + "     " + this.Product.Name + "     " + this.Product.Description + "     " + "(" + "INR " +
                this.Product.Price + " * " + this.Quantity + ") " + " = " + "INR " + this.GetCartItemValue();
        }
    }
}
