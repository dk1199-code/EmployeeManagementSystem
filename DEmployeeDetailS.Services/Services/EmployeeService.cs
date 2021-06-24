using EmployeeDetailS.Core.IEmployeeReposicery;
using EmployeeDetailS.Core.IEmployeeService;
using EmployeeDetailS.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailS.Services.Services
{
    public class EmployeeService : IEmployeeDetailsService
    {
        readonly IEmployeeDetailsRepositery _iEmployeeDetails;

        public  EmployeeService (IEmployeeDetailsRepositery iEmployeeDetails)
        {
            _iEmployeeDetails = iEmployeeDetails;
        }

        #region LoginDetails
        public int LoginDetails(AdminLoginDetailsModel adminUser)
        {
            return _iEmployeeDetails.LoginDetails(adminUser);
        }
        #endregion

        #region ViewEmployeeDetails

        public List<EmployeeDetailsModel> ViewEmployeeDetails()
        {
            return _iEmployeeDetails.ViewEmployeeDetails();
        }
        #endregion

        #region AddEmployeeDetails
        public void AddEmployeeDetails(EmployeeDetailsModel empDetails)
        {
            _iEmployeeDetails.AddEmployeeDetails(empDetails);
        }
        #endregion

        #region SelectDepartment

        public List<EmployeeDepartmentModel> SelectDepartment()
        {
            return _iEmployeeDetails.SelectDepartment();    
        }
        #endregion

        #region DeleteEmployeeDetails
        public void DeleteEmployeeDetails(int employeId)
        {
            _iEmployeeDetails.DeleteEmployeeDetails(employeId);
        }

        #endregion

        #region EditEmployeeDetails

        public EmployeeDetailsModel EditEmployeeDetails(int emploId)
        {
            return _iEmployeeDetails.EditEmployeeDetails(emploId);
        }
        #endregion
    }
}
