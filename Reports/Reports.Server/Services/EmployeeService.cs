using System;
using Reports.DAL.Entities;
using Reports.Server.Controllers;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Employee Create(string name)
        {
            return new Employee(Guid.NewGuid(), name);
        }

        public Employee FindByName(string name)
        {
            if (name.Equals("Aboba", StringComparison.InvariantCultureIgnoreCase))
            {
                return new Employee(Guid.NewGuid(), name);
            }

            return null;
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