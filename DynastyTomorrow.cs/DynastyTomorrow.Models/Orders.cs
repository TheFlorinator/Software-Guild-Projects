using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.Models
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public States State { get; set; }
        public Product Product { get; set; }
        public decimal Area { get; set; }
        public decimal LaborCost { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxOfTotal { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsValid { get; set; }
        public string Date { get; set; }

        public Order()
        {
            this.Product = new Product();
        }
    }
}
