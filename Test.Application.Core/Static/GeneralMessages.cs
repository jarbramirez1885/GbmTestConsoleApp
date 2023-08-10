
namespace Test.Application.Core.Static
{
    public class GeneralMessages
    {
        public readonly static string ERROROPMENU = "Select a valid option";
        public readonly static string BYE = "Are you sure you would like to close the program?";
        public readonly static string CONFIRM = "Press Y to confirm or N to continue";
        public readonly static string END = "End. Press enter for return to the main menu";
        public readonly static string NORECORDS = "No records found";
        public readonly static string SEARCHING = "Please wait, Searching records...";
        public readonly static string CREATINGFILE = "Please wait, creating your file...";
        public readonly static string LOADINGFILE = "Please wait, loading your file...";
        public readonly static string FILENAME = "Write a name for your file: ";
        public readonly static string READYFILE = "Your file is ready! Press enter to return to main menu";
        public readonly static string FILEUPLOADED = "Your file was uploaded! Press enter to return to the main menu";
        public readonly static string[] FILEHEAD =
            {
                "EmployeeID", 
                "NationalIDNumber", 
                "ContactID", 
                "LoginID", 
                "ManagerID",
                "Title",
                "BirthDate",
                "MaritalStatus",
                "Gender",
                "HireDate",
                "SalariedFlag",
                "VacationHours",
                "SickLeaveHours",
                "CurrentFlag",
                "rowguid",
                "ModifiedDate"
            };
    }
}
