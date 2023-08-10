using Console.Infrastructure.Console.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Core.Interfaces
{
    public interface IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<Employee>> GetEmployees();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        void GetFile();

        /// <summary>
        /// 
        /// </summary>
        void LoadRecords();
    }
}
