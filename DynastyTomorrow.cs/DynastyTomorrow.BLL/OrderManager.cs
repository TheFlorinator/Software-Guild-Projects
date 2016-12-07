using DynastyTomorrow.Data;
using DynastyTomorrow.Models;
using DynastyTomorrow.Models.Interfaces;
using DynastyTomorrow.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynastyTomorrow.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public LookUpOrderResponse LookUpOrderList(Order order)
        {
            LookUpOrderResponse response = new LookUpOrderResponse();
            response.OrderList = _orderRepository.LookUpOrders(order);

            if (response.OrderList != null)
            {
                response.Success = true;
                return response;
            }
            else
            {
                response.Success = false;
                response.Message = $"There are no orders for {order.Date}.";
                return response;
            }
        }

        public AddOrderResponse AddOrder(Order newOrder)
        {
            AddOrderResponse response = new AddOrderResponse();
            IsValidChecker orderCheck = new IsValidChecker();
            var validOrder = orderCheck.ValidOrderChecker(newOrder);
            if (validOrder.IsValid == false)
            {
                response.Success = false;
                response.Message = "An error has occurred";
                return response;
            }
            else if (validOrder.IsValid == true)
            {
                if (!_orderRepository.AddOrders(validOrder))
                {
                    response.Success = false;
                    response.Message = "An error has occurred, please retry";
                }
                return response;
            }
            return response;
        }

        public AddOrderResponse StateTaxCheck(States state)
        {
            AddOrderResponse response = new AddOrderResponse();
            response.Order.TaxRate = StateTaxRepo.GetStateTax(state);
            return response;
        }

        public AddOrderResponse GetProductInfo(ProductType type)
        {
            AddOrderResponse response = new AddOrderResponse();
            response.Order.Product = ProductCostsRepo.GetProductInfor(type);
            return response;
        }

        public OrderResponse DisplaySingleOrder(Order order)
        {
            OrderResponse response = new OrderResponse();
            IsValidChecker validChecker = new IsValidChecker();
            response.Order = _orderRepository.LookUpIndividualOrder(order);
            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "Please provide a date or order";
            }
            else
            {
                var validOrder = validChecker.ValidOrderChecker(response.Order);
                if (validOrder.IsValid == false)
                {
                    response.Success = false;
                    response.Message = "That order/date does not exsist";
                }
                else
                {
                    response.Success = true;
                }
            }
            return response;
        }

        public OrderResponse WriteEditedOrder(Order order)
        {
            OrderResponse respnose = new OrderResponse();
            IsValidChecker validChecker = new IsValidChecker();
            var validOrder = validChecker.ValidOrderChecker(order);
            if (validOrder.IsValid == false)
            {
                respnose.Success = false;
                return respnose;
            }
            else
            {
                if (!_orderRepository.WriteOrders(order))
                {
                    respnose.Success = false;
                    respnose.Message = "Not able to write order";
                }
                else
                {
                    respnose.Success = true;
                }
            }
            return respnose;
        }

        public OrderResponse DeletingOrder(Order order)
        {
            OrderResponse response = new OrderResponse();
            if (order == null)
            {
                response.Success = false;
                return response;
            }
            else
            {
                if (!_orderRepository.DeleteOrder(order))
                {
                    response.Success = false;
                    response.Message = "Order not found!";
                }
                else
                {
                    response.Success = true;
                }
            }
            
            return response;

        }
    }
}
