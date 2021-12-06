using System;
using System.Threading.Tasks;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Create(string name);

        Employee FindByName(string name);

        Employee FindById(Guid id);

        void Delete(Guid id);

        Employee Update(Employee entity);
    }
}