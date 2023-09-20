using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;
using Quality2.Database;
using Quality2.IRepository;

namespace Quality2.Services
{
    public class OrderQualityService : IOrderQuailtyService
    {
        private DataContext context;
        private static readonly IMapper Mapper;

        static OrderQualityService()
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Entities.OrderQuality, Database.OrderQuality>();
                config.CreateMap<Database.OrderQuality, Entities.OrderQuality>();
            }).CreateMapper();
        }
        public OrderQualityService(DataContext context)
        {
            this.context = context;
        }
        public async Task AddOrderQualityAsync(Entities.OrderQuality order)
        {
            using var db = new DataContext();
            var dbModel = Mapper.Map<Database.OrderQuality>(order);
            await context.OrderQuality.AddAsync(dbModel);
            await context.SaveChangesAsync();
        }

        public async Task<Entities.OrderQuality> GetOrderQualityAsync(Entities.OrderQuality order)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entities.OrderQuality>> GetOrderQualityByNumberAsync(int orderNumber)
        {
            using var db = new DataContext();
            var orders = await db.OrderQuality.Where(x=>x.OrderNumber == orderNumber).ToListAsync();
            return Mapper.Map<List<Entities.OrderQuality>>(orders);
        }

        public async Task<List<Entities.OrderQuality>> GetOrdersQualityAsync()
        {
            using var db = new DataContext();
            var orders = await db.OrderQuality.ToListAsync();
            return Mapper.Map<List<Entities.OrderQuality>>(orders);
        }

        public async Task<IResult> UpdateOrderQualityAsync(Entities.OrderQuality changedOrder)
        {
            using var db = new DataContext();
            var order = await db.OrderQuality.FirstOrDefaultAsync(x => x.ID == changedOrder.ID);
            if (order == null)
            {
                return Results.NotFound();
            }
            else
            {
                order = Mapper.Map<Database.OrderQuality>(changedOrder);
                await db.SaveChangesAsync();
                return Results.Accepted();
            }

        }
    }
}
