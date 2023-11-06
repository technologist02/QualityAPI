using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IOrderQuailtyService
    {
        public Task<List<OrderQuality>> GetOrdersQualityAsync();
        public Task<OrderQuality> GetOrderQualityAsync(OrderQuality order);
        public Task<OrderQuality> GetOrderQualityByIdAsync(int id);
        public Task<List<OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber);

        public Task AddOrderQualityAsync(OrderQuality order);

        public Task UpdateOrderQualityAsync(OrderQuality order);

        public Task<(byte[], int)> GetPassportQualityAsync(int id);
    }
}
