using System;
using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.DTO;
using MGlobal.Core.Domain.Entities;
using MGlobal.Core.Utils.Constants;

namespace MGlobal.Core.Factory
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeDTO CreateEmployeeDTO(Employee employee)
        {
            EmployeeDTO result = null;

            if (employee != null)
            {
                switch (employee.ContractTypeName)
                {
                    case ContractTypeConst.HourlySalaryEmployee:
                        result = EmployeeDTO.NewHourlyEmployee(employee.Id, employee.Name, employee.ContractTypeName, employee.RoleName, employee.HourlySalary);
                        break;

                    case ContractTypeConst.MonthlySalaryEmployee:
                        result = EmployeeDTO.NewMonthlyEmployee(employee.Id, employee.Name, employee.ContractTypeName, employee.RoleName, employee.HourlySalary);
                        break;
                }
            }

            return result;
        }
    }
}
