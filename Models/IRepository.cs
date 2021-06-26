using System.Collections.Generic;
using NorthwindApi.Models;

namespace NorthwindApi
{
    public interface IRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}