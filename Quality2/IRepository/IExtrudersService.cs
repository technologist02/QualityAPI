using Quality2.Entities;
using Quality2.ViewModels;

namespace Quality2.IRepository
{
    public interface IExtrudersService
    {
        public Task<List<Extruder>> GetExtrudersAsync();

        public Task<Extruder> GetExtruderAsync(int id);

        public Task AddExtruderAsync(ExtruderCreateView extruder);

        public Task UpdateExtruderAsync(Extruder newExtruder);
    }
}
