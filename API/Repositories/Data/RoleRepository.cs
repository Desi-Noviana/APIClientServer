using API.Contexts;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<int, Role>
    {
        private readonly MyContexts context;
        public RoleRepository(MyContexts context) : base(context) // base ---> constraktor dari general revo dimana memilki context
        {
            this.context = context;
        }
    }
}

