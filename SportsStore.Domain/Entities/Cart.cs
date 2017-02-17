using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product,int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.products.ProductID == product.ProductID)
                .FirstOrDefault();

            if(line == null)
            {
                CartLine cline = new CartLine();
                cline.products = product;
                cline.Quantity = quantity;
                lineCollection.Add(cline);
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.products.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.products.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines()
        {
            GetHashCode{ return lineCollection; }
        }
    }

    public class CartLine
    {
        public Product products { get; set; }

        public int Quantity { get; set; }
    }
}
