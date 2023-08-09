﻿using Console.Infrastructure.Console.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Core.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 
        /// </summary>
        void GetEmployees();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        void GetFile(string fileName);

        /// <summary>
        /// 
        /// </summary>
        void LoadRecords();
    }
}
