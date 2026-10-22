
using System.Collections.Generic;
using EMP_record_management.Models;

namespace EMP_record_management.Services
{
    internal class EmployeeManager
    {
        private readonly List<Employee> employees = new List<Employee>();

        private readonly EmployeeService employeeService =
            new EmployeeService();

        public IReadOnlyList<Employee> Employees => employees;

        // Add sample employee records
        public void Init()
        {
            employees.Clear();

            employees.Add(new Employee
            {
                Name = "Arun",
                Age = 25,
                Salary = 25000m
            });

            employees.Add(new Employee
            {
                Name = "Priya",
                Age = 24,
                Salary = 30000m
            });
        }

        // Add a new employee
        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        // Save employee records to a file
        public void Save(string filePath, string format)
        {
            employeeService.SaveEmployees(
                employees, filePath, format);
        }

        // Restore employee records from a file
        public void Restore(string filePath)
        {
            List<Employee> restoredEmployees =
                employeeService.RestoreEmployees(filePath);

            employees.Clear();
            employees.AddRange(restoredEmployees);
        }
        public void Clear()
        {
            employees.Clear();
        }
    }
}
