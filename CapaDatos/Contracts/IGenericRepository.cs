using System.Collections.Generic;

namespace DataAccess.Contracts
{
    public  interface IGenericRepository<Entity> where Entity : class
    {
        int Create(Entity entity);
        int Update(Entity entity);
        int Delete(int id);
        IEnumerable<Entity> GetAll();
    }
}
