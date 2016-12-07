using DynastyTomorrow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.BLL
{
    public static class Calculator
    {
        public static decimal MaterialCalculator(Order order)
        {
            decimal area = order.Area;
            decimal materialCost = order.Product.CostPerSquareFoot;
            return area * materialCost;
        }

        public static decimal LaborCalculator(Order order)
        {
            decimal area = order.Area;
            decimal laborCost = order.Product.LaborCostPerSquareFoot;

            return order.LaborCost = area * laborCost;
        }

        public static decimal TaxCalculator(Order order)
        {
            decimal laborTotal = order.LaborCost;
            decimal materialTotal = order.MaterialCost;
            decimal tax = order.TaxRate;
            decimal taxPercent = (tax / 100) * (laborTotal + materialTotal);
            return taxPercent;
        }

        public static decimal TotalCost(Order order)
        {
            return order.MaterialCost + order.LaborCost + order.TaxOfTotal;
        }
    }
}
