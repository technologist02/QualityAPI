using Microsoft.EntityFrameworkCore;
using Quality2.Database;
using Quality2.Entities;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class OrderQualityService : IOrderQuailtyService
    {
        private DataContext context;
        public OrderQualityService(DataContext context)
        {
            this.context = context;
        }
        public async Task AddOrderQualityAsync(OrderQuality order)
        {
            await context.OrderQuality.AddAsync(order);
            await context.SaveChangesAsync();
        }

        public async Task<OrderQuality> GetOrderQualityAsync(OrderQuality order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber)
        {
            var result = await context.OrderQuality.Where(x=>x.OrderNumber == orderNumber).ToListAsync();
            return result;
        }

        public async Task<List<OrderQuality>> GetOrdersQualityAsync()
        {
            var result = await context.OrderQuality.ToListAsync();
            return result;
        }

        public async Task UpdateOrderQualityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
