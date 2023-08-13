using DataAccess.Entities;

namespace DataAccess.Contracts
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
      Employee GetEmployeeById(int id);
    }
}
