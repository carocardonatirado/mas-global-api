using System;
using MGlobal.Core.Domain.DTO;
using MGlobal.Core.Domain.Entities;

namespace MGlobal.Core.Domain.Contracts
{
    public interface IEmployeeFactory
    {
        EmployeeDTO CreateEmployeeDTO(Employee employee);
    }
}
