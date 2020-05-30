using GMPAssignment.Interfaces;
using GMPAssignment.Models;
using System;
using System.Collections.Generic;

namespace GMPAssignment.Managers
{
    public class CartManager : ICartManager
    {
        public Dictionary<int, Cart> UserCartMap { get; private set; }

        public CartManager()
        {
            this.UserCartMap = new Dictionary<int, Cart>();
        }

        public void AddCartForUser(int userId)
        {
            if (!this.UserCartMap.ContainsKey(userId))
                this.UserCartMap[userId] = new Cart();
        }

        public void AddProductToCart(int userId, Product product, int quantity)
        {
            if (!this.UserCartMap.ContainsKey(userId))
                this.UserCartMap[userId] = new Cart();

            this.UserCartMap[userId].AddProductToCart(product, quantity);
        }

        public void Checkout(int userId)
        {            
            if (this.UserCartMap.ContainsKey(userId))
            {
                Console.WriteLine(this.UserCartMap[userId].ToString());             
                Console.WriteLine("Total Cart Value = INR {0}", this.UserCartMap[userId].GetTotalCartValue());
            }

            // Checkout should clear cart
            this.ClearCart(userId);
        }

        public void ClearCart(int userId)
        {
            if (this.UserCartMap.ContainsKey(userId))
                this.UserCartMap[userId] = new Cart();
        }

        public void ShowCart(int userId)
        {
            if (this.UserCartMap.ContainsKey(userId))
                Console.WriteLine(this.UserCartMap[userId].ToString());
        }

        public void RemoveProductFromCart(int userId, int productId)
        {
            if (this.UserCartMap.ContainsKey(userId))
                this.UserCartMap[userId].RemoveProductFromCart(productId);
        }
    }
}
