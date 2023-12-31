﻿using Console.Infrastructure.Console.Core.Entities;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;

namespace Test.Application.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region Properties
        private readonly IRepository _repository;
        #endregion

        #region Construct
        public EmployeeService(IRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public methods
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

                    System.Console.WriteLine(result.Count + " records" + " \n");
                }
                else
                {
                    System.Console.WriteLine(GeneralMessages.NORECORDS);
                }

                System.Console.WriteLine(GeneralMessages.END);
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex.Message + ": " + ex.InnerException);
                System.Console.ReadLine();
            }
        }

        /// <summary>
        /// Get File with all records
        /// </summary>
        public void GetFile()
        {
            try
            {
                _repository.GetFile();
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex.Message + ": " + ex.InnerException);
                System.Console.ReadLine();
            }
        }

        /// <summary>
        /// Load Records from csv
        /// </summary>
        public void LoadRecords()
        {
            try
            {
                _repository.LoadRecords();
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex.Message + ": " + ex.InnerException);
                System.Console.ReadLine();
            }
        }
        #endregion
    }
}
