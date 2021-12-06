using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/tasks")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ReportsDatabaseContext _context;

        public TasksController(ReportsDatabaseContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequestModel requestModel)
        {
            var employeeId = User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var employee = await _context.Employees.SingleAsync(x => x.Id == Guid.Parse(employeeId));
            var task = await _context.Tasks.AddAsync(new TaskModel
            {
                Id = Guid.NewGuid(),
                AssignedEmployee = employee
            });
            await _context.SaveChangesAsync();

            return this.Ok(task.Entity);
        }
    }

    public class CreateTaskRequestModel
    {
        public string Name { get; set; }
        public int Priority { get; set; }
    }
}