using DataAccess.Contracts;
using DataAccess.Entities;
using DataAccess.Repositories;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class EmployeeModel
    {
        private IEmployeeRepository employeeRepository;
        private List<EmployeeModel> listEmployees;

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras.")]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "El apellido es requerido.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras.")]
        [StringLength(maximumLength:100, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El email es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese una dirección de correo electrónico válida.")]    
        public string Email { get; set; }
        [Required(ErrorMessage = "El salario es requerido.")]
        [RegularExpression(@"^\d{1,8}([,.]\d{1,2})?$", ErrorMessage = "Ingrese un salario válido, solo se permite 2 decimales y 10 digitos en total.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ingrese un salario válido.")]
        public decimal Salary { get; set; }


        public EntityState State { private get; set; }

        public EmployeeModel()
        {
            employeeRepository = new EmployeeRepository();
        }
        public string SaveChanges()
        {
            string message = null;
            try
            {
                var employeeDataModel = new Employee();
                employeeDataModel.Id = Id;
                employeeDataModel.Name = Name;
                employeeDataModel.LastName = LastName;
                employeeDataModel.Email = Email;
                employeeDataModel.Salary = Salary;

                switch (State)
                {
                    case EntityState.Added:
                        employeeRepository.Create(employeeDataModel);
                        message = "Empleado agregado correctamente.";
                        break;
                    case EntityState.Deleted:
                        employeeRepository.Delete(Id);
                        message = "Empleado eliminado correctamente.";
                        break;
                    case EntityState.Modified:
                        employeeRepository.Update(employeeDataModel);
                        message = "Empleado actualizado correctamente.";
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                message= ex.ToString();
                
            }
            return message;
        }

        public List<EmployeeModel> GetAll()
        {
            var employeeDataModel = employeeRepository.GetAll();
            listEmployees =  new List<EmployeeModel>();
            foreach (Employee item in employeeDataModel)
            {
                listEmployees.Add(new EmployeeModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    LastName = item.LastName,
                    Email = item.Email, 
                    Salary = item.Salary,
                });
            }
            return listEmployees;
        }

        public List<EmployeeModel> GetEmployeeByName(string name)
        {         
            return listEmployees.FindAll(e => e.Name.ToLower().Contains(name.ToLower()));
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            var employee = employeeRepository.GetEmployeeById(id);

            if (employee != null)
            {
                return new EmployeeModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Salary = employee.Salary,
                };
            }
            else
            {
                throw new Exception("Empleado no encontrado");
            }
        }

    }
}
