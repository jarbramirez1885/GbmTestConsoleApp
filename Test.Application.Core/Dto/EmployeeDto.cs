using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.Core.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string NationalIdnumber { get; set; } = null!;
        public int ContactId { get; set; }
        public string LoginId { get; set; } = null!;
        public int? ManagerId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public bool? SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public bool? CurrentFlag { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
