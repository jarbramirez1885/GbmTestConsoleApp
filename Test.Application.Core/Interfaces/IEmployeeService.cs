
namespace Test.Application.Core.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Get List Employees
        /// </summary>
        void GetEmployees();

        /// <summary>
        /// Get File csv
        /// </summary>
        void GetFile();

        /// <summary>
        /// Load Records from csv
        /// </summary>
        void LoadRecords();
    }
}
