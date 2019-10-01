using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Unity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MGlobal.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeeController()
        {
            _employeeManager = Startup.UnityLibraryContainer.Resolve<IEmployeeManager>();
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            IEnumerable<EmployeeDTO> employees = await _employeeManager.GetEmployees();
            return (employees.Count() == 0) ? NoContent() : (IActionResult)Ok(employees);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EmployeeDTO employee = await _employeeManager.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
