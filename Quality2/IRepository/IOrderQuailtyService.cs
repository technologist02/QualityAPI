using Quality2.Entities;
using Quality2.QueryModels;
using Quality2.ViewModels;

namespace Quality2.IRepository
{
    public interface IOrderQuailtyService
    {
        public Task<List<OrderQuality>> GetOrdersQualityAsync();
        public Task<OrderQuality> GetOrderQualityByIdAsync(int id);
        public Task<List<OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber);

        public Task AddOrderQualityAsync(OrderQualityView order);

        public Task UpdateOrderQualityAsync(OrderQuality order);

        public Task<(byte[], int)> GetPassportQualityAsync(int id);

        public Task<IEnumerable<OrderQuality>> GetFilteredOrdersAsync(OrdersQuery query);
    }
}
