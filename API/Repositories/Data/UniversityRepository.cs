using API.Contexts;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class UniversityRepository : GeneralRepository<int, University>
    {
        private readonly MyContexts context;
        public UniversityRepository(MyContexts context) : base (context) // base ---> constraktor dari general revo dimana memilki context
        {
            this.context = context;
        }
        public async Task<IEnumerable<University>> GetUniversityByName(string name)
        {
            return await context.Universities.Where(u => u.Name == name).ToListAsync();
        }
    }
}
