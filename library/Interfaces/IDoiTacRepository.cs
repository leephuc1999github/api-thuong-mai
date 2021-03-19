using library.Interfaces.Base;
using library.Models;
using library.Models.Base;
using System.Threading.Tasks;

namespace library.Interfaces
{
    public interface IDoiTacRepository : IRepository<DoiTac> 
    {
        public Task<DataManagerResponse> Gets(int skip = 0, int top = 100, string q = null, string includes = null , string orderBys = null);
    }
}
