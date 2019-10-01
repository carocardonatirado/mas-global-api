using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MGlobal.Core.Domain.DTO;

namespace MGlobal.Core.Domain.Contracts
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployeeById(int id);
    }
}
