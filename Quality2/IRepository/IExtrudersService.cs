using Quality2.Entities;

namespace Quality2.IRepository
{
    public interface IExtrudersService
    {
        public Task<List<Extruder>> GetExtrudersAsync();

        public Task<Extruder> GetExtruderAsync(int id);

        public Task AddExtruderAsync(Extruder extruder);
    }
}
