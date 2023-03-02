using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<string, Employee>
    {
        private readonly MyContexts context;
        public EmployeeRepository(MyContexts context) : base(context) // base ---> constraktor dari general revo dimana memilki context
        {
            this.context = context;
        }
    }
}
