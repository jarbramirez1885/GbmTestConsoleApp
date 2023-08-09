using Console.Infrastructure.Console.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;

namespace Test.Application.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get List of Employees
        /// </summary>
        public void GetEmployees()
        {
            try
            {
                List<Employee> result = _repository.GetEmployees().Result;

                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        System.Console.WriteLine(
                            "EmployeeId: " + item.EmployeeId +
                            " | NationalIdnumber: " + item.NationalIdnumber +
                            " | ContactId: " + item.ContactId +
                            " | LoginId: " + item.LoginId +
                            " | ManagerId: " + item.ManagerId +
                            " | Title: " + item.Title +
                            " | BirthDate: " + item.BirthDate.ToString("dd/MM/yyyy") +
                            " | MaritalStatus: " + item.MaritalStatus +
                            " | Gender: " + item.Gender +
                            " | HireDate: " + item.HireDate +
                            " | SalariedFlag: " + item.SalariedFlag +
                            " | VacationHours: " + item.VacationHours +
                            " | SickLeaveHours: " + item.SickLeaveHours +
                            " | CurrentFlag: " + item.CurrentFlag +
                            " | CurrentFlag: " + item.Rowguid +
                            " | CurrentFlag: " + item.ModifiedDate + " \n");
                    }
                }
                else
                {
                    System.Console.WriteLine(GeneralMessages.NORECORDS);
                }

                System.Console.WriteLine(GeneralMessages.END);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Get File with all records
        /// </summary>
        /// <param name="fileName"></param>
        public void GetFile(string fileName)
        {
            try
            {
                _repository.GetFile(fileName);
            }
            catch (Exception ex)
            {

                System.Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadRecords()
        {
            try
            {
                _repository.LoadRecords();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
