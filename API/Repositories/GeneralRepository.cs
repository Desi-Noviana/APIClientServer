using API.Contexts;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class GeneralRepository<Key, Entity> : IRepository<Key, Entity> //Buat memanggil task di repository
        where Entity : class
    {
        private readonly MyContexts context;

        public GeneralRepository(MyContexts context) 
        {
            this.context = context;
        }
        public async Task<int> Delete(Key? key)
        {
           
            var entity = await GetById(key); // await async ---> untuk menunggu data diproses selanjutnya
            if (entity is null)
                return 0;

            context.Set<Entity>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entity>> GetAll() // Menandakan bahwa data Asynchronus
        {
            return await context.Set<Entity>().ToListAsync();
        }

        public async Task<Entity?> GetById(Key? key)
        {
            if(key is null)
            
                return null;
            
            return await context.Set<Entity>().FindAsync(key); 
        }

        public async Task<int> Insert(Entity entity)
        {
            await context.Set<Entity>().AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(Entity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
    }
}
