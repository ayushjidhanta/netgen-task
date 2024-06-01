
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer
{
    public interface IRepo<Entity>
    {
        Task<IEnumerable<Entity>> GetAll();
        Task<Entity> GetById(int id);
        Task<Entity> Create(Entity entity);
        Task<Entity> Update(Entity entity);
        Task Delete(int id);

    }
}
