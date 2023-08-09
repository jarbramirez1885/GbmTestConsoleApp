using Console.Infrastructure.Console.Core.Entities;
using Console.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Core.Dto;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;

namespace Test.Application.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        public readonly AdventureWorksContext _contextDb;

        public Repository(AdventureWorksContext contextDb)
        {
            _contextDb = contextDb;
        }

        /// <summary>
        /// Get List of Employees
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Get a File with all records
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="Exception"></exception>
        public void GetFile(string fileName)
        {
            try
            {
                List<Employee> employees = new();

                System.Console.WriteLine(GeneralMessages.SEARCHING);

                employees = _contextDb.Employees.ToList();
                string fechaHora = System.DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                string file = @"C:\Users\jarbr\Downloads\" + fileName + "_" + fechaHora + ".csv";
                string separator = ";";
                StringBuilder output = new();
                string[] headings = GeneralMessages.FILEHEAD;

                output.AppendLine(string.Join(separator, headings));

                foreach (var employee in employees)
                {
                    string[] empData =
                        {
                            employee.EmployeeId.ToString(),
                            employee.NationalIdnumber.ToString() ,
                            employee.ContactId.ToString() ,
                            employee.LoginId.ToString() ,
                            employee.ManagerId.ToString() ,
                            employee.Title.ToString() ,
                            employee.BirthDate.ToString("dd/MM/yyyy") ,
                            employee.MaritalStatus.ToString() ,
                            employee.Gender.ToString() ,
                            employee.HireDate.ToString() ,
                            employee.SalariedFlag.ToString() ,
                            employee.VacationHours.ToString() ,
                            employee.SickLeaveHours.ToString() ,
                            employee.CurrentFlag.ToString() ,
                            employee.Rowguid.ToString() ,
                            employee.ModifiedDate.ToString()
                    };

                    output.AppendLine(string.Join(separator, empData));
                }

                System.IO.File.AppendAllText(file, output.ToString());

                System.Console.WriteLine(GeneralMessages.READYFILE);
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void LoadRecords()
        {
            try
            {
                string fileLocation = @"C:\Users\jarbr\Downloads\EmployeesToLoad.csv";
                StreamReader file = new(fileLocation);
                string separador = ";";
                string line;

                file.ReadLine();

                while ((line = file.ReadLine()) != null)
                {
                    string[] row = line.Split(separador);
                    Employee employeeObj = EmployeeObject(row);
                    _contextDb.Employees.Add(employeeObj);
                    _contextDb.SaveChanges();
                }

                System.Console.WriteLine("Your file was uploaded! Press enter to return to the main menu");
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static Employee EmployeeObject(string[] row)
        {
            Employee employee = new()
            {
                EmployeeId = Convert.ToInt32(row[0]),
                NationalIdnumber = row[1],
                ContactId = Convert.ToInt32(row[2]),
                LoginId = row[3],
                ManagerId = Convert.ToInt32(row[4]),
                Title = row[5],
                BirthDate = Convert.ToDateTime(row[6]),
                MaritalStatus = row[7],
                Gender = row[8],
                HireDate = Convert.ToDateTime(row[9]),
                SalariedFlag = Convert.ToBoolean(row[10]),
                VacationHours = Convert.ToInt32(row[11]),
                SickLeaveHours = Convert.ToInt32(row[12]),
                CurrentFlag = Convert.ToBoolean(row[13]),
                Rowguid = System.Guid.NewGuid(),
                ModifiedDate = Convert.ToDateTime(row[15])
            };

            return employee;
        }
    }
}
