using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quality2.Controllers;
using Quality2.Database;
using Quality2.Entities;
using Quality2.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quality2.Tests
{
    [TestFixture]
    public class OrderQualityControllerTests
    {
        [Test]
        public async Task GetOrdersTest()
        {
            var dataStore = A.Fake<IOrderQuailtyService>();
            var fakeOrders = A.CollectionOfDummy<OrderQuality>(7).AsEnumerable().ToList();
            A.CallTo(() => dataStore.GetOrdersQualityAsync()).Returns(Task.FromResult(fakeOrders));
            var orderController = new OrderQualityController(dataStore);
            var actionResult = await orderController.GetAllOrdersQualityAsync();
            var result = actionResult as OkObjectResult;
            var resultValue = result?.Value as List<OrderQuality>;
            Assert.That(resultValue?.Count, Is.EqualTo(fakeOrders.Count));
        }
    }
}
