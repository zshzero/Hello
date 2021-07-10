using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return ctx.employees.FromSqlRaw("SELECT * FROM sp_getallemployees();");

            // procedures can only return a single result row, yet, when created with INOUT parameters
            // https://stackoverflow.com/questions/58507979/how-to-get-result-set-from-postgresql-stored-procedure/58513796#58513796
            // https://dba.stackexchange.com/questions/118418/when-to-use-stored-procedure-user-defined-function/118419#118419
        }

        public IEnumerable<Employee> GetEmployeeById(int EmployeeId)
        {
            return ctx.employees.Where(e => e.employee_id.Equals(EmployeeId))
                                .ToList();
        }

        public IEnumerable<Order> GetOrderById(int orderId)
        {
             return ctx.orders.Where(o => o.order_id.Equals(orderId))
                                .ToList();
        }

        public IEnumerable<Order> GetAllOrdersByEmployeeId(int EmployeeId   )
        {
            return ctx.orders.Where(o => o.employee_id.Equals(EmployeeId))
                                                .ToList();
        }

        public IEnumerable<Order> GetOrdersByEmployeeId(int EmployeeId, int orderId)
        {
            List<Order> OrdersByEmployee = ctx.orders.Where(o => o.employee_id.Equals(EmployeeId))
                                                .ToList();
            return OrdersByEmployee.Where(o => o.order_id.Equals(orderId));
        }
    }
}