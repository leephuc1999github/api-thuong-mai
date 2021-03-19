using api.Models;
using library.Interfaces.Base;
using library.Models.Base;
using System.Threading.Tasks;

namespace library.Interfaces
{
    public interface IHopDongRepository : IRepository<HopDong>
    {
        public Task<DataManagerResponse> GetHopDongs(int skip = 0, int top = 100, string q = null, string includes = null);
    }
}
