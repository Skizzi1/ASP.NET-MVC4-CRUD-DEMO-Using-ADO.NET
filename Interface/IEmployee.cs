using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Demo.Models;

namespace MVC_Demo.Interface
{
    interface IEmployee
    {
        void Create(Employee e);
        void Delete(Guid id);
        void Edit(Employee e);
        List<Employee> Read();
    }
}
