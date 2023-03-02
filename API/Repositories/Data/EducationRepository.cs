using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class EducationRepository : GeneralRepository<int, Education>
    {
        private readonly MyContexts context;
        public EducationRepository(MyContexts context) : base(context) // base ---> constraktor dari general revo dimana memilki context
        {
            this.context = context;
        }
    }

}
