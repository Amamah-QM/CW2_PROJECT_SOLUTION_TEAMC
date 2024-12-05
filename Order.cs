using System;
using System.Collections.Generic;

public class Order
{
        private int orderId;
        private DateTime dateOrdered;
        private string orderStatus;

        public int OrderID
        {
            get { return orderId; } 
            set { orderId = value; } 
        }
        
        public DateTime DateOrdered
        {
            get { return dateOrdered; } 
            set { dateOrdered = value; } 
        }

        public string OrderStatus
        {
            get { return orderStatus; } 
            set { orderStatus = value; } 
        }

        public Order(int orderId, DateTime dateOrdered, string orderStatus)
        {
            OrderId = orderId;
            DateOrdered = dateOrdered;
            OrderStatus = orderStatus;
        }
}
