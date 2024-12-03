using System;
using System.Collections.Generic;

public class Order
{
        public int OrderId { get; set; }
        public DateTime DateOrdered { get; set; }
        public string OrderStatus { get; set; }

        public Order(int orderId, DateTime dateOrdered, string orderStatus)
        {
            OrderId = orderId;
            DateOrdered = dateOrdered;
            OrderStatus = orderStatus;
        }
}
