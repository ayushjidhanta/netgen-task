
using DALayer.Data;
using DALayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepoLayer
{
    public class EmployeeRepo : IRepo<Employee>
    {
        public readonly AppDbContext _dbcontext;
        public EmployeeRepo(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Employee> Create(Employee emp)
        {
            await _dbcontext.Employees.AddAsync(emp);
            await _dbcontext.SaveChangesAsync();
            return emp;
        }

        public async Task Delete(int id)
        {
            var empToDelete = await GetById(id);

            if (empToDelete == null || empToDelete.EmpId == 0)
            {
                var message = $"Employee Id {id} not found to delete";
                throw new KeyNotFoundException(message);
            }

            _dbcontext.Employees.Remove(empToDelete);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _dbcontext.Employees.ToListAsync();
        }   

        public async Task<Employee> GetById(int id)
        {
            var data = await _dbcontext.Employees.FirstOrDefaultAsync(x => x.EmpId == id);
            if (data == null || data.EmpId <= 0)
            {
                var message = $"Employee Id {id} not found in database.";
                throw new KeyNotFoundException(message);
            }
            return data;
        }

        public async Task<Employee> Update(Employee emp)
        {
            _dbcontext.Employees.Update(emp);
            await _dbcontext.SaveChangesAsync();
            return emp;
        }
    }
}
