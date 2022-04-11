using igi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace igi.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        public int Calories
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.Product.Calories);
            }
        }

        public virtual void AddToCart(Product product)
        {
            if (Items.ContainsKey(product.Id))
                Items[product.Id].Quantity++;
            else
                Items.Add(product.Id, new CartItem
                {
                    Product= product,
                    Quantity = 1
                });
        }

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
