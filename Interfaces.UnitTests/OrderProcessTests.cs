using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interfaces.UnitTests
{
    [TestClass]
    public class OrderProcessTests
    {

        // METHODNAME_CONDITION_EXPECTATION

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsShipped_InvalidOprationException()
        {
            var orderProcess = new OrderProcessor(new FakeShipmentCalculator());

            orderProcess.Process(new Order { Cost = 500, Shipment = new Shipment(), CreatedDate = DateTime.Now });
        }

        [TestMethod]
        public void Process_OrderIsShipped_ShouldSetShipment()
        {
            var orderProcess = new OrderProcessor(new FakeShipmentCalculator());
            var order = new Order {Cost = 500, CreatedDate = DateTime.Now};
            orderProcess.Process(order);
            
            Assert.IsTrue(order.IsShipped);
            Assert.AreEqual(1, order.Shipment.Cost);
            Assert.AreEqual(DateTime.Today.AddDays(1), order.Shipment.ShipmentDate);
        }
    }


    public class FakeShipmentCalculator : ICalculateShipmentCost
    {
        public float CalculateCost(Order order)
        {
            return 1;
        }
    }
}
