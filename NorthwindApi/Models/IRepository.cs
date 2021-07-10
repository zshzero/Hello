using System.Collections.Generic;
using NorthwindApi.Models;

namespace NorthwindApi
{
    public interface IRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetEmployeeById(int EmployeeId);
        IEnumerable<Order> GetOrderById(int orderId);
        IEnumerable<Order> GetAllOrdersByEmployeeId(int EmployeeId);
        IEnumerable<Order> GetOrdersByEmployeeId(int employeeId, int orderId);
    }
}