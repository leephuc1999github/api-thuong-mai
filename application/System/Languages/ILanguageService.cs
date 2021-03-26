using System.Collections.Generic;
using System.Threading.Tasks;
using view_model.Common;
using view_model.System.Languages;

namespace application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageVm>>> GetAll();
    }
}
