using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICalculateShipmentCost
    {
        float CalculateCost(Order order);
    }


    public class Order
    {
        public string OrdrNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public float Cost { get; set; }
        public float TotalCost { get; set; }
        public bool IsShipped
        {
            get { return this.Shipment != null ? true : false; }
        }
        public Shipment Shipment { get; set; }
    }

    public class Shipment
    {
        public float Cost { get; set; }
        public DateTime ShipmentDate { get; set; }
    }

    public class CalculateShipmentCost : ICalculateShipmentCost
    {
        public float CalculateCost(Order order)
        {
            if (order.Cost < 3000)
                return (order.Cost * 10) / 100;

            return 0;
        }
    }

    public class CalculateSpecialShipmentCost : ICalculateShipmentCost
    {
        public float CalculateCost(Order order)
        {
            if (order.Cost < 3000)
                return (order.Cost * 5) / 100;

            return 0;
        }
    }

    public class OrderProcessor
    {
        private readonly ICalculateShipmentCost _calculateShipmentCost;
        public OrderProcessor(ICalculateShipmentCost calculateShipmentCost)
        {
            _calculateShipmentCost = calculateShipmentCost;
        }

        public void Process(Order order)
        {
            if (order.IsShipped)
                throw new InvalidOperationException("Order already shipped");


            order.Shipment = new Shipment
            {
                Cost = _calculateShipmentCost.CalculateCost(order),
                ShipmentDate = DateTime.Today.AddDays(1),
            };

            order.TotalCost = order.Cost + order.Shipment.Cost;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                OrdrNo = "ORDER0093989",
                CreatedDate = DateTime.Now,
                Cost = 2500
            };

            var orderProcessor = new OrderProcessor(new CalculateShipmentCost());

            orderProcessor.Process(order);

            Console.WriteLine(order.Shipment.Cost);
            Console.WriteLine(order.Cost);
            Console.WriteLine(order.TotalCost);
        }
    }
}
