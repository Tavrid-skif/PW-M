using System;
using System.Collections.Generic;

namespace PW_08
{
    internal class Program
    {

        static void PrintOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"Номер заказа: {order.GetOrderId()}, Заказчик: {order.GetCustomerName()}, Сумма: {order.GetTotalAmount()}");
            }
        }

        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
                       
            orders.Add(new Order(1, "Alice", 100.50));
            orders.Add(new Order(2, "Bob", 25.75));
            orders.Add(new Order(3, "Charlie", 150.00));
            orders.Add(new Order(4, "David", 75.25));
            orders.Add(new Order(5, "Eve", 300.00));
            orders.Add(new Order(6, "Frank", 12.99));
            orders.Add(new Order(7, "Grace", 80.50));
            orders.Add(new Order(8, "Heidi", 200.00));
            orders.Add(new Order(9, "Ivan", 45.00));
            orders.Add(new Order(10, "Judy", 175.75));

            Console.Write("Введите количество заказов: ");
            if (int.TryParse(Console.ReadLine(), out int numOrders))
            {
                for (int i = 0; i < numOrders; i++)
                {
                    Console.Write($"Введите номер заказа {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int orderId))
                    {
                        Console.Write($"Введите имя заказчика: ");
                        string customerName = Console.ReadLine();

                        Console.Write($"Введите сумму заказа: ");
                        if (double.TryParse(Console.ReadLine(), out double totalAmount))
                        {
                            orders.Add(new Order(orderId, customerName, totalAmount));
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат суммы заказа.\n");
                            i--; 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат номера заказа.\n");
                        i--; 
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный формат количества заказов.\n");
                return;
            }

            Console.WriteLine("\nНеотсортированный список заказов:");
            PrintOrders(orders);

            orders.Sort();
                       
            Console.WriteLine("\nОтсортированный список заказов (по сумме):");
            PrintOrders(orders);

            Console.ReadLine();
        }
    }
}
