using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using API.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class EmployeesRepository: IEmployeesRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public EmployeesRepository(DataContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<Employee>> GetEmployees(Filter filter)
        {
            return await context.Employees
                .Include(e => e.Items)
                .Skip(filter.PageIndex * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await context.Employees
                .Include(e => e.Items)
                .SingleOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                throw new Exception("Employee does not exist.");

            return employee;
        }

        public async Task<int> GetEmployeesCount() 
        {
            return await context.Employees.CountAsync();
        }

        public async Task<Employee> CreateEmployee(EmployeeDto dto)
        {
            var employee = mapper.Map<EmployeeDto, Employee>(dto);
            await context.Employees.AddAsync(employee);

            if (await context.SaveChangesAsync() > 0)
                return employee;

            return null;
        }

        public async Task<bool> UpdateEmployee(int id, EmployeeDto dto)
        {
            var employee = await GetEmployee(id);
            mapper.Map<EmployeeDto, Employee>(dto, employee);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await GetEmployee(id);
            context.Employees.Remove(employee);

            return await context.SaveChangesAsync() > 0;
        }
    }
}