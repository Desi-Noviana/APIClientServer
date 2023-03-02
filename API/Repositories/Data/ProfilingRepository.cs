using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class ProfilingRepository : GeneralRepository<int, Profilling>
    {
        private readonly MyContexts context;
        public ProfilingRepository(MyContexts context) : base(context) // base ---> constraktor dari general revo dimana memilki context
        {
            this.context = context;
        }
    }
}
