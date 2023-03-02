using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repositories.Interface;
public interface IRepository<Key,Entity> where Entity :class
{
    //Menggunakan Asynchronus cukup dengan menambahkan Task
    Task<IEnumerable<Entity>> GetAll(); //fungsi dari GetAll untuk menampilkan saja > IEnumerable hanya bisa untuk read/View
    Task <Entity?> GetById(Key? key);
    Task <int> Insert(Entity entity);
    Task <int>  Update(Entity entity);
    Task <int>  Delete(Key key);
}
