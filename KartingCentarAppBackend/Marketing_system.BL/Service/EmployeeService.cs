using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.DA.Contracts;
using Marketing_system.DA.Contracts.Model;

namespace Marketing_system.BL.Service
{
    public class EmployeeService : IEmployeeService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeDTO> CreateEmployee(EmployeeDTO employee)
        {
            var employeeTemp = await _unitOfWork.GetEmployeeRepository().Add(new Employee(employee.Name, employee.Surname, employee.Email, employee.Password, employee.Phone, employee.City, employee.Street, employee.StreetNumber, DateOnly.Parse(employee.Birthday), DateOnly.Parse(employee.EmploymentDate), employee.Status, employee.Type));
            await _unitOfWork.Save();

            var result = new EmployeeDTO
            {
                Id = employeeTemp.Entity.Id,
                Name = employeeTemp.Entity.Name,
                Surname = employeeTemp.Entity.Surname,
                Email = employeeTemp.Entity.Email,
                Password = employeeTemp.Entity.Password,
                Phone = employeeTemp.Entity.Phone,
                City = employeeTemp.Entity.City,
                Street = employeeTemp.Entity.Street,
                StreetNumber = employeeTemp.Entity.StreetNumber,
                Birthday = employeeTemp.Entity.Birthday.ToString(),
                EmploymentDate = employeeTemp.Entity.EmploymentDate.ToString(),
                Status = employeeTemp.Entity.Status,
                Type = employeeTemp.Entity.Type,
            };

            return result;
        }
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employeesTemp = await _unitOfWork.GetEmployeeRepository().GetAll();

            var result = employeesTemp.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Email = e.Email,
                Password = e.Password,
                Phone = e.Phone,
                City = e.City,
                Street = e.Street,
                StreetNumber = e.StreetNumber,
                Birthday = e.Birthday.ToString(),
                EmploymentDate = e.EmploymentDate.ToString(),
                Status = e.Status,
                Type = e.Type,
            }).ToList();

            return result;
        }

        public async Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employee)
        {
            var temp = _unitOfWork.GetEmployeeRepository().Update(new Employee(employee.Id, employee.Name, employee.Surname, employee.Email, employee.Password, employee.Phone, employee.City, employee.Street, employee.StreetNumber, DateOnly.Parse(employee.Birthday), DateOnly.Parse(employee.EmploymentDate), employee.Status, employee.Type));
            await _unitOfWork.Save();
            if(temp != null)
            {
                return employee;
            } else
            {
                return null;
            }
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var employeeTemp = await _unitOfWork.GetEmployeeRepository().GetByIdAsync(id);

            var result = new EmployeeDTO
            {
                Id = employeeTemp.Id,
                Name = employeeTemp.Name,
                Surname = employeeTemp.Surname,
                Email = employeeTemp.Email,
                Password = employeeTemp.Password,
                Phone = employeeTemp.Phone,
                City = employeeTemp.City,
                Street = employeeTemp.Street,
                StreetNumber = employeeTemp.StreetNumber,
                Birthday = employeeTemp.Birthday.ToString(),
                EmploymentDate = employeeTemp.EmploymentDate.ToString(),
                Status = employeeTemp.Status,
                Type = employeeTemp.Type,
            };

            return result;
        }
    }
}
