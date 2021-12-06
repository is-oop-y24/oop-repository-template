using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reports.DAL.Entities;
using Reports.Server.Controllers;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private const string dbPath = "employees.json";
        private readonly ReportsDatabaseContext _context;

        public EmployeeService(ReportsDatabaseContext context) {
            _context = context;
        }

        public async Task<Employee> Create(string name)
        {
            var employee = new Employee(Guid.NewGuid(), name);
            var employeeFromDb = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public Employee FindByName(string name)
        {
            return JsonConvert.DeserializeObject<Employee[]>(File.ReadAllText(dbPath, Encoding.UTF8))
                .FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        public Employee FindById(Guid id)
        {
            Guid fakeGuid = Guid.Parse("ac8ac3ce-f738-4cd6-b131-1aa0e16eaadc");
            if (id == fakeGuid)
            {
                return new Employee(fakeGuid, "Abobus");
            }

            return null;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}