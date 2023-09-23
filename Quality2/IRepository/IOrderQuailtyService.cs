using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IOrderQuailtyService
    {
        public Task<List<OrderQuality>> GetOrdersQualityAsync();
        public Task<OrderQuality> GetOrderQualityAsync(OrderQuality order);
        public Task<List<OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber);

        public Task AddOrderQualityAsync(OrderQuality order);

        public Task<IResult> UpdateOrderQualityAsync(OrderQuality order);

        public Task<byte[]> GetPassportQualityAsync(int id);
    }
}
