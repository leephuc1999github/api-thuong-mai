using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using view_model.System.Roles;

namespace application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}
