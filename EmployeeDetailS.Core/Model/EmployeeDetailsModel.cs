using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeDetailS.Core.Model
{
    public class EmployeeDetailsModel
    {
        public int EmploId  { get; set; }
        //[Required]
        public string EmployeeFullName { get; set; }
        //[Required]
        public string EmployeeUsername { get; set; }
        //[Required]
        public string EmployeeEmail { get; set; }
        //[Required]
        public int EmployeeDepartment { get; set; }
        public string DepartmentEmp { get; set; }
        //[Required]
        public string EmployeeMarticule { get; set; }
        //[Required]
        public string EmplouyeeAddress { get; set; }
        //[Required]
        public long EmployeePhoneNumber { get; set; }
        //[Required]
        public string EmployeeGender { get; set; }

    }
}
