using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MGlobal.Core.Domain.Entities;

namespace MGlobal.Core.Domain.Contracts
{
    public interface IEmployeeClientService
    {
        Task<Employee> GetEmployee(int id);
        Task<ICollection<Employee>> GetEmployees();
    }
}
