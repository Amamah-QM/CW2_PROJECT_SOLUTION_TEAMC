using System;
using System.Collections.Generic;

public class Order
{
        private int OrderId { get; set; }
        private DateTime DateOrdered { get; set; }
        private string OrderStatus { get; set; }

        public Order(int orderId, DateTime dateOrdered, string orderStatus)
        {
            OrderId = orderId;
            DateOrdered = dateOrdered;
            OrderStatus = orderStatus;
        }
}
