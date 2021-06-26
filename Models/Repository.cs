using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Northwind.Models;
using NorthwindApi.Models;

namespace NorthwindApi
{
    public class Repository : IRepository
    {
        private readonly NorthwindContext ctx;
        private readonly ILogger logger;

        public Repository(NorthwindContext ctx, ILogger<Repository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
                return ctx.employees.OrderBy(e => e.employee_id)
                                    .ToList();
        }
    }
}