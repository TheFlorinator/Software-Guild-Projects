using DynastyTomorrow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.Data
{
    public static class ProductCostsRepo
    {
        public static Product GetProductInfor(ProductType type)
        {
            Product newOrder = new Product();
            switch (type)
            {
                case ProductType.CARPET:
                    newOrder.CostPerSquareFoot = 2.5M;
                    newOrder.LaborCostPerSquareFoot = 3.0M;
                    return newOrder;
                case ProductType.LAMINATE:
                    newOrder.CostPerSquareFoot = 2.5M;
                    newOrder.LaborCostPerSquareFoot = 3.0M;
                    return newOrder;
                case ProductType.TILE:
                    newOrder.CostPerSquareFoot = 2.5M;
                    newOrder.LaborCostPerSquareFoot = 3.0M;
                    return newOrder;
                case ProductType.WOOD:
                    newOrder.CostPerSquareFoot = 11.2M;
                    newOrder.LaborCostPerSquareFoot = 5.9M;
                    return newOrder;
                default:
                    newOrder.CostPerSquareFoot = 50M;
                    newOrder.LaborCostPerSquareFoot = 50M;
                    return newOrder;
            }
        }
    }
}
