using System.Collections.Generic;
using NorthwindApi.Models;
using System.Threading.Tasks;
using System.Threading;

namespace NorthwindApi
{
    public interface IRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees(CancellationToken token);
        Task<IEnumerable<Employee>> GetEmployeeById(int EmployeeId, CancellationToken token);
        Task<IEnumerable<Order>> GetOrderById(int orderId, CancellationToken token);
        Task<IEnumerable<Order>> GetAllOrdersByEmployeeId(int EmployeeId);
        IEnumerable<Order> GetOrdersByEmployeeId(int employeeId, int orderId);
    }
}