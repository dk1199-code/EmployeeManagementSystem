using EmployeeDetailS.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailS.Core.IEmployeeService
{
    public interface IEmployeeDetailsService
    {
        #region LoginDetails
        public int LoginDetails(AdminLoginDetailsModel adminUser);

        #endregion

        #region ViewEmployeeDetails
        public List<EmployeeDetailsModel> ViewEmployeeDetails();
        #endregion

        #region AddEmployeeDetails
        public void AddEmployeeDetails(EmployeeDetailsModel empDetails);
        #endregion

        #region SelectDepartment

        public List<EmployeeDepartmentModel> SelectDepartment();
        #endregion

        #region DeleteEmployeeDetails
        void DeleteEmployeeDetails(int employeId);

        #endregion

        #region EditEmployeeDetails

        public EmployeeDetailsModel EditEmployeeDetails(int emploId);
        #endregion

    }
}
