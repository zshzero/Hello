using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Northwind.Models;
using NorthwindApi.Models;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Data;
using Dapper;

namespace NorthwindApi
{
    public class Repository : IRepository
    {
        private readonly NorthwindContext ctx;
        private readonly ILogger logger;
        private readonly IDbConnection Connection;

        public Repository(NorthwindContext ctx, ILogger<Repository> logger, IDbConnection dapperConnection)
        {
            this.ctx = ctx;
            this.logger = logger;
            this.Connection = dapperConnection;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(CancellationToken token)
        {
            try {
                Thread.Sleep(10000);
                return await (ctx.employees.FromSqlRaw("SELECT * FROM sp_getallemployees();").ToListAsync(token));
                // procedures can only return a single result row, yet, when created with INOUT parameters
                // https://stackoverflow.com/questions/58507979/how-to-get-result-set-from-postgresql-stored-procedure/58513796#58513796
                // https://dba.stackexchange.com/questions/118418/when-to-use-stored-procedure-user-defined-function/118419#118419
            }
            catch (OperationCanceledException ex) {
                // https://stackoverflow.com/questions/13040428/difference-between-operationcanceledexception-and-taskcanceledexception
                System.Console.WriteLine(ex.Message);
                return null;
                // Suppress error log - waiting for ef to resolve the issue
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeeById(int EmployeeId, CancellationToken token)
        {
            try
            {
                return await ctx.employees.Where(e => e.employee_id.Equals(EmployeeId))
                                .ToListAsync(token);
            }
            catch (OperationCanceledException ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        public async Task<IEnumerable<Order>> GetOrderById(int orderId, CancellationToken token)
        {
            string sql = "SELECT * FROM Orders where order_id = @OrderId";
            try
            {
                return await Connection.QueryAsync<Order>(new CommandDefinition(sql, new { OrderId = orderId }, cancellationToken: token))
                                    .ConfigureAwait(false);
                // https://medium.com/bynder-tech/c-why-you-should-use-configureawait-false-in-your-library-code-d7837dce3d7f
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
             
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