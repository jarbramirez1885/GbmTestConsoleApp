using Console.Infrastructure.Console.Core.Entities;
using Console.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;

namespace Test.Application.Infrastructure.Repositories
{
    public class Repository: IRepository
    {
        public readonly AdventureWorksContext _contextDb;

        public Repository(AdventureWorksContext contextDb)
        {
            _contextDb = contextDb;
        }

        public Task<List<Employee>> GetEmployees()
        {
            try
            {
                List<Employee> employee = new();
                System.Console.WriteLine(GeneralMessages.SEARCHING);

                employee = _contextDb.Employees.ToList();
                return Task.FromResult(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
