using DALayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.DTOs
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }

        public EmployeeResponseDto(Employee employee)
        {
            EmployeeId = employee.EmpId;
            EmployeeName = employee.EmpName;
            Email = employee.Email;
            Gender = employee.Gender;
            PhoneNumber = employee.PhoneNumber;
        }
    }
}
