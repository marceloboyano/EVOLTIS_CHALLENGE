using DataAccess.Contracts;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;



namespace DataAccess.Repositories
{
    public class EmployeeRepository : MasterRepository, IEmployeeRepository
    {
        private string _selectAll;
        private string _insert;
        private string _update;
        private string _delete;
        private string _getById;
       

        public EmployeeRepository()
        {
            _selectAll = "select * from Employee";
            _insert = "insert into Employee values (@name,@lastName,@email,@salary)";
            _update = "update Employee set Name = @name,LastName = @lastName,Email = @email,Salary = @salary where Id = @id";
            _delete = "delete from Employee where Id = @id";
            _getById = "select * from Employee where Id = @id";
          
        }
        public int Create(Employee entity)
        {
            parameters = new List<SqlParameter>();           
            parameters.Add(new SqlParameter("@name", entity.Name));
            parameters.Add(new SqlParameter("@lastName", entity.LastName));
            parameters.Add(new SqlParameter("@email", entity.Email));
            parameters.Add(new SqlParameter("@salary", entity.Salary));
            return ExecuteNonQuery(_insert);

        }

        public int Update(Employee entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", entity.Id));
            parameters.Add(new SqlParameter("@name", entity.Name));
            parameters.Add(new SqlParameter("@lastName", entity.LastName));
            parameters.Add(new SqlParameter("@email", entity.Email));
            parameters.Add(new SqlParameter("@salary", entity.Salary));
            return ExecuteNonQuery(_update);
        }
        public int Delete(int id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));          
            return ExecuteNonQuery(_delete);
        }

        public IEnumerable<Employee> GetAll()
        {
            var tableResult = ExecuteReader(_selectAll);
            var listEmployees = new List<Employee>();
            foreach (DataRow item in tableResult.Rows)
            {
                listEmployees.Add(new Employee
                {
                    Id = Convert.ToInt32(item["ID"]),
                    Name = item["Name"].ToString(),
                    LastName = item["LastName"].ToString(),
                    Email = item["Email"].ToString(),
                    Salary =Convert.ToDecimal( item["Salary"]),
                });
            }
            return listEmployees;
        }

        public Employee GetEmployeeById(int id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));

            var tableResult = ExecuteReader(_getById);
            if (tableResult.Rows.Count > 0)
            {
                var item = tableResult.Rows[0]; 

                return new Employee
                {
                    Id = Convert.ToInt32(item["ID"]),
                    Name = item["Name"].ToString(),
                    LastName = item["LastName"].ToString(),
                    Email = item["Email"].ToString(),
                    Salary = Convert.ToDecimal(item["Salary"]),
                };
            }
            else
            {
               
               throw new Exception("Empleado no encontrado");
            }
        }
    }
}
