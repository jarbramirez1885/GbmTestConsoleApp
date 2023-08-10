using Console.Infrastructure.Console.Core.Entities;
using Console.Infrastructure.Context;
using System.Text;
using Test.Application.Core.Interfaces;
using Test.Application.Core.Static;

namespace Test.Application.Infrastructure.Repositories
{
    public class Repository : IRepository
    {
        public readonly AdventureWorksContext _contextDb;

        #region Construct
        public Repository(AdventureWorksContext contextDb)
        {
            _contextDb = contextDb;
        }
        #endregion


        #region Public methods
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
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex.Message + ": " + ex.InnerException);
                System.Console.ReadLine();
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
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex.Message + ": " + ex.InnerException);
                System.Console.ReadLine();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Load Records from file type csv ; delimited
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void LoadRecords()
        {
            try
            {
                string fileLocation = @"C:\Users\jarbr\Downloads\EmployeesToLoad.csv";
                StreamReader file = new(fileLocation);
                string separador = ";";
                string line;

                file.ReadLine();

                System.Console.WriteLine(fileLocation);

                while ((line = file.ReadLine()) != null)
                {
                    string[] row = line.Split(separador);
                    Employee employeeObj = EmployeeObject(row);
                    _contextDb.Employees.Add(employeeObj);
                    _contextDb.SaveChanges();
                }

                System.Console.WriteLine(GeneralMessages.FILEUPLOADED);
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine(ex.Message + ": " + ex.InnerException);
                System.Console.ReadLine();
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Private methods
        private static Employee EmployeeObject(string[] row)
        {
            Employee employee = new()
            {
                NationalIdnumber = row[0],
                ContactId = Convert.ToInt32(row[1]),
                LoginId = row[2],
                ManagerId = Convert.ToInt32(row[3]),
                Title = row[4],
                BirthDate = Convert.ToDateTime(row[5]),
                MaritalStatus = row[6],
                Gender = row[7],
                HireDate = Convert.ToDateTime(row[8]),
                SalariedFlag = Convert.ToBoolean(row[9]),
                VacationHours = Convert.ToInt16(row[10]),
                SickLeaveHours = Convert.ToInt16(row[11]),
                CurrentFlag = Convert.ToBoolean(row[12]),
                Rowguid = System.Guid.NewGuid(),
                ModifiedDate = Convert.ToDateTime(row[13])
            };

            return employee;
        }

        #endregion
    }
}
