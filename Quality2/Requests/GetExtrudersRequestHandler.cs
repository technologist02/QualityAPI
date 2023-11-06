using AutoMapper;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Quality2.Entities;

namespace Quality2.Requests
{
    public class GetExtrudersRequest : IRequest<Extruder[]>
    {
        public GetExtrudersRequest() { }
    }

    public class GetExtrudersRequestHandler : IRequestHandler<GetExtrudersRequest, Extruder[]>
    {
        private static readonly IMapper Mapper;

        static GetExtrudersRequestHandler() 
        {
            Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Extruder, Database.Extruder>();
                config.CreateMap<Database.Extruder, Extruder>();
            }).CreateMapper();
        }
        public async ValueTask<Extruder[]> Handle(GetExtrudersRequest request, CancellationToken cancellationToken)
        {
            using var db = new Database.DataContext();
            var dbModel = await db.Extruder.ToListAsync();
            return Mapper.Map<Extruder[]>(dbModel);
        }
    }
}
