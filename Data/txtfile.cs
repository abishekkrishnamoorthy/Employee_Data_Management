
using System;
using System.IO;
using System.Collections.Generic;
using EMP_record_management.Models;

namespace EMP_record_management.Storage
{
    internal class txtfile : EmployeeStorageBase
    {
        public override void save(
            List<Employee> employees, string filePath)
        {
            ValidatePath(filePath, ".txt", false);

            using StreamWriter writer = new StreamWriter(filePath);

            foreach (Employee employee in employees)
            {
                writer.WriteLine(
                    $"{employee.Name}|{employee.Age}|{employee.Salary}");
            }
        }

        public override List<Employee> restore(string filePath)
        {
            ValidatePath(filePath, ".txt", true);

            List<Employee> employees = new List<Employee>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] data = line.Split('|');

                if (data.Length != 3 ||
                    !int.TryParse(data[1], out int age) ||
                    !decimal.TryParse(
                        data[2],
                        System.Globalization.NumberStyles.Number,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out decimal salary))
                {
                    throw new FormatException(
                        "Invalid employee data in TXT file.");
                }

                employees.Add(new Employee
                {
                    Name = data[0],
                    Age = age,
                    Salary = salary
                });
            }

            return employees;
        }
    }
}
