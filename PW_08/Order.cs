using System;

namespace PW_08
{
    internal class Order : IOrder, IComparable<Order>
    {
        public int OrderId {  get; }
        public string CustomerName {  get; }
        public double TotalAmount {  get; }

        public Order(int orderId, string customerName, double totalAmount)
        {
            OrderId = orderId;
            CustomerName = customerName;
            TotalAmount = totalAmount;
        }

        public int CompareTo(Order other) { return TotalAmount.CompareTo(other.TotalAmount); }

        public string GetCustomerName() { return CustomerName; }

        public int GetOrderId() { return OrderId; }

        public double GetTotalAmount() { return TotalAmount; }

    }
}
