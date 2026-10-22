
using EMP_record_management.Models;
using System.Collections.Generic;

namespace EMP_record_management.Interfaces
{
    internal interface IEmployee
    {
        void save(List<Employee> employees, string filePath);

        List<Employee> restore(string filePath);
    }
}
