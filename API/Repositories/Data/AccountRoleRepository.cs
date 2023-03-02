using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<int, AccountRole>
    {
        private readonly MyContexts context;
        public AccountRoleRepository(MyContexts context) : base(context) // base ---> constraktor dari general revo dimana memilki context
        {
            this.context = context;
        }
    }
}
