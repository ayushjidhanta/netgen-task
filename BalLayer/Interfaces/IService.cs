
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer.Interfaces
{
    public interface IService<Entity>
    {
        Task<IEnumerable<Entity>> GetAll();
        Task<Entity> GetById(int id);
        Task<Entity> Create(Entity entity);
        Task<Entity> Update(int id, Entity entity);
        Task Delete(int id);

    }
}
