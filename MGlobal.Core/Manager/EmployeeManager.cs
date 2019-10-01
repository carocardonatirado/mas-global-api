using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.DTO;
using MGlobal.Core.Domain.Entities;
using MGlobal.Core.Factory;

namespace MGlobal.Core.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeClientService _employeeClientService;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeManager(IEmployeeClientService employeeClientService, IEmployeeFactory employeeFactory)
        {
            _employeeClientService = employeeClientService;
            _employeeFactory = employeeFactory;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            ICollection<Employee> employees = await _employeeClientService.GetEmployees();
            return employees.Select(employee => _employeeFactory.CreateEmployeeDTO(employee));
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            return _employeeFactory.CreateEmployeeDTO(await _employeeClientService.GetEmployee(id));
        }
    }
}
