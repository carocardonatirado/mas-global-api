namespace MGlobal.Core.Domain.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ContractType { get; private set; }
        public string RoleName { get; private set; }
        public decimal Salary { get; private set; }
        public decimal AnnualSalary { get; private set; }

        public EmployeeDTO(int id, string name, string contractType, string roleName, decimal salary, decimal annualSalary)
        {
            Id = id;
            Name = name;
            ContractType = contractType;
            RoleName = roleName;
            Salary = salary;
            AnnualSalary = annualSalary;
        }

        public static EmployeeDTO NewHourlyEmployee(int id, string name, string contractType, string roleName, decimal salary)
        {
            return new EmployeeDTO(id, name, contractType, roleName, salary, 120 * salary * 12);
        }

        public static EmployeeDTO NewMonthlyEmployee(int id, string name, string contractType, string roleName, decimal salary)
        {
            return new EmployeeDTO(id, name, contractType, roleName, salary, salary * 12);
        }
    }
}
