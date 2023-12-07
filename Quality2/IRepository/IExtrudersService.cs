using Quality2.Entities;
using Quality2.ViewModels;

namespace Quality2.IRepository
{
    public interface IExtrudersService
    {
        public Task<List<Extruder>> GetExtrudersAsync();

        public Task<Extruder> GetExtruderAsync(int id);

        public Task<Extruder> AddExtruderAsync(ExtruderCreateView extruder);

        public Task<Extruder> UpdateExtruderAsync(Extruder newExtruder);
    }
}
