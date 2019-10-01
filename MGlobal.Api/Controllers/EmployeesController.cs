using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MGlobal.Core.Domain.Contracts;
using MGlobal.Core.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Unity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MGlobal.Api.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController()
        {
            _employeeManager = Startup.UnityLibraryContainer.Resolve<IEmployeeManager>();
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<EmployeeDTO> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync("employee");
                if (responseTask.IsSuccessStatusCode)
                {
                    employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(await responseTask.Content.ReadAsStringAsync());
                }
                else
                {
                    employees = Enumerable.Empty<EmployeeDTO>();
                    ModelState.AddModelError(string.Empty, "Something wrong was happend. Please contact administrator.");
                }
            }

            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            EmployeeDTO employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                var responseTask = await client.GetAsync($"employee/{id}");
                if (responseTask.IsSuccessStatusCode)
                {
                    employee = JsonConvert.DeserializeObject<EmployeeDTO>(await responseTask.Content.ReadAsStringAsync());
                }
                else
                {
                    employee = default(EmployeeDTO);
                    ModelState.AddModelError(string.Empty, "Something wrong was happend. Please contact administrator.");
                }
            }

            return View(employee);
        }
    }
}
