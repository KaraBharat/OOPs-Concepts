using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Object> OrderList;

        public Customer()
        {
            this.OrderList = new List<object>();
        }
        public Customer(int id)
            : this()
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

    }

    public class Order
    {
        public string OrderNo;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(3, "Smith");
            customer.OrderList.Add(new Order { OrderNo = "ORD123" });

            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.Name);
        }
    }
}
