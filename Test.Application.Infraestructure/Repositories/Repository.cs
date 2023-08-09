using Console.Infrastructure.Console.Core.Entities;
using Console.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;
using static System.Net.WebRequestMethods;

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

        public void GetFile()
        {
            try
            {
                List<Employee> employee = new();
                System.Console.WriteLine(GeneralMessages.SEARCHING);

                employee = _contextDb.Employees.ToList();

                string file = @"C:\Users\jarbr\Downloads\test.csv";
                string separator = ";";
                StringBuilder output = new StringBuilder();
                string[] headings = { "StudentID", "First Name", "Last Name", "Date Of Birth" };

                output.AppendLine(string.Join(separator, headings));

                foreach (var item in employee)
                {
                    string[] empData = { 
                        item.EmployeeId.ToString(),
                            item.NationalIdnumber.ToString() ,
                            item.ContactId.ToString() ,
                            item.LoginId.ToString() ,
                            item.ManagerId.ToString() ,
                            item.Title.ToString() ,
                            item.BirthDate.ToString("dd/MM/yyyy") ,
                            item.MaritalStatus.ToString() ,
                            item.Gender.ToString() ,
                            item.HireDate.ToString() ,
                            item.SalariedFlag.ToString() ,
                            item.VacationHours.ToString() ,
                            item.SickLeaveHours.ToString() ,
                            item.CurrentFlag.ToString() ,
                            item.Rowguid.ToString() ,
                            item.ModifiedDate.ToString()
                };
                    


                    output.AppendLine(string.Join(separator, empData));
                }

                System.IO.File.AppendAllText(file, output.ToString());

                System.Console.WriteLine("File ready");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
