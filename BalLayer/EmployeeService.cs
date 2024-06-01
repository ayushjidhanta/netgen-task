using BALayer.Interfaces;
using DALayer.Models;
using RepoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALayer
{
    public class EmployeeService : IService<Employee>
    {
        public readonly IRepo<Employee> _empRepo;
        public EmployeeService(IRepo<Employee> empRepo)
        {
            _empRepo = empRepo;
        }
        public async Task<Employee> Create(Employee emp)
        {
            return await _empRepo.Create(emp);
        }

        public async Task Delete(int id)
        {
            await _empRepo.Delete(id);
        }

        public async Task<Employee> GetById(int id)
        {
            return await _empRepo.GetById(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _empRepo.GetAll();
        }

        public async Task<Employee> Update(int id, Employee emp)
        {
            var empToUpdate = await GetById(id);

            if(empToUpdate == null || empToUpdate.EmpId <= 0)
            {
                throw new KeyNotFoundException($"Employee ID {id} not found");
            }

            empToUpdate.Email = emp.Email;
            empToUpdate.Gender = emp.Gender;
            empToUpdate.PhoneNumber = emp.PhoneNumber;
            empToUpdate.EmpName = emp.EmpName;

            return await _empRepo.Update(empToUpdate);
        }
    }
}
