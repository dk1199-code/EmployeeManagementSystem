using EmployeeDetailS.Core.IEmployeeReposicery;
using EmployeeDetailS.Core.Model;
using EmployeeDetailS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeDetailS.Resources.Repositery
{
    public class EmployeeRepositery : IEmployeeDetailsRepositery
    {
        #region LoginDetails
        public int LoginDetails(AdminLoginDetailsModel adminUser)
        {
            int loginCheck = 0;
            if (adminUser != null)
            {
                
                EmployeemanagementsystemEntity entity = new EmployeemanagementsystemEntity();
                var adminLogin = entity.LoginDetails.Where(x => x.User_Name == adminUser.AdminUserName && x.Password == adminUser.AdminPassword).Count();
                if(adminLogin >0 )
                {
                    loginCheck= loginCheck+1;
                }
                else
                {
                    loginCheck = 0;
                }
            }
            return loginCheck;
        }

        #endregion

        #region ViewEmployeeDetails

        public List<EmployeeDetailsModel> ViewEmployeeDetails()
        {
            List<EmployeeDetailsModel> empDetails =new  List<EmployeeDetailsModel>();
            using (var entity = new EmployeemanagementsystemEntity())
            {
                 empDetails = (from Emp in entity.EmployeeDetails
                            join Dept in entity.DepartmentDetails
                            on Emp.Department equals Dept.Department_Id
                            where Emp.Is_Deleted == false && Dept.Is_Deleted == false
                            select new EmployeeDetailsModel
                            {
                                EmploId = Emp.Employee_Id,
                                EmployeeFullName =Emp.FullName,
                                EmployeeUsername = Emp.Username,
                                EmployeeEmail = Emp.Email,
                                DepartmentEmp = Dept.Department_Name,
                                EmployeeMarticule = Emp.Marticule,
                                EmplouyeeAddress = Emp.Address,
                                EmployeePhoneNumber = Emp.PhoneNumber,
                                EmployeeGender = Emp.Gender
                            }).ToList();

                //if(empDatadb != null)
                //{
                //    foreach( var dbEmpDetails in empDatadb)
                //    {
                //        EmployeeDetailsModel empDetail = new EmployeeDetailsModel();
                //        empDetail.EmploId = dbEmpDetails.Employe_Id;
                //        empDetail.EmployeeFullName = dbEmpDetails.Employe_FullName;
                //        empDetail.EmployeeUsername = dbEmpDetails.Employe_Username;
                //        empDetail.EmployeeEmail = dbEmpDetails.Email;
                //        empDetail.DepartmentEmp = dbEmpDetails.Departments;
                //        empDetail.EmployeeMarticule = dbEmpDetails.Employe_Martic;
                //        empDetail.EmplouyeeAddress = dbEmpDetails.Employe_Address;
                //        empDetail.EmployeePhoneNumber = dbEmpDetails.Employe_PhNumber;
                //        empDetail.EmployeeGender = dbEmpDetails.Gender;
                //        empDetails.Add(empDetail);
                //    }

                //}
            }
                return empDetails;
        }
        #endregion

        #region Add & Update EmployeeDetails
        public void AddEmployeeDetails(EmployeeDetailsModel empDetails)
        {
            if(empDetails != null)
            {
                EmployeeDetails employeeDetail = new EmployeeDetails();
                if (empDetails.EmploId ==0)
                {
                    using (var entity = new EmployeemanagementsystemEntity())
                    {
                        employeeDetail.FullName = empDetails.EmployeeFullName;
                        employeeDetail.Username = empDetails.EmployeeUsername;
                        employeeDetail.Email = empDetails.EmployeeEmail;
                        employeeDetail.Department = empDetails.EmployeeDepartment;
                        employeeDetail.Marticule = empDetails.EmployeeMarticule;
                        employeeDetail.Address = empDetails.EmplouyeeAddress;
                        employeeDetail.PhoneNumber = empDetails.EmployeePhoneNumber;
                        employeeDetail.Gender = empDetails.EmployeeGender;
                        entity.EmployeeDetails.Add(employeeDetail);
                        entity.SaveChanges();
                    }

                }
                else
                {
                    using (var entity = new EmployeemanagementsystemEntity())
                    {
                        var employData = entity.EmployeeDetails.Where(x =>x.Employee_Id == empDetails.EmploId && x.Is_Deleted == false).SingleOrDefault();
                        if (employData != null)
                        {
                            employData.FullName = empDetails.EmployeeFullName;
                            employData.Username = empDetails.EmployeeUsername;
                            employData.Email = empDetails.EmployeeEmail;
                            employData.Marticule = empDetails.EmployeeMarticule;
                            employData.Address = empDetails.EmplouyeeAddress;
                            employData.PhoneNumber = empDetails.EmployeePhoneNumber;
                            employData.Gender = empDetails.EmployeeGender;
                            employData.Department = empDetails.EmployeeDepartment;
                            employData.Updated_Time_Stamp = DateTime.Now;
                            entity.SaveChanges();
                        }

                    }

                }
                
            }
        }
        #endregion

        #region SelectDepartment

        public List<EmployeeDepartmentModel> SelectDepartment()
        {
            List<EmployeeDepartmentModel> departmentList = new List<EmployeeDepartmentModel>();
            using (var entity = new EmployeemanagementsystemEntity())
            {
                var empDepartment = entity.DepartmentDetails.Where(x => x.Is_Deleted == false).ToList();
                if(empDepartment != null)
                {
                    foreach(var empDepart in empDepartment)
                    {
                        EmployeeDepartmentModel department = new EmployeeDepartmentModel();
                        department.DepartmentId = empDepart.Department_Id;
                        department.DepartmentName = empDepart.Department_Name;
                        departmentList.Add(department);
                    }
                }
            }
                return departmentList;
        }
        #endregion

        #region DeleteEmployeeDetails
       public  void DeleteEmployeeDetails(int employeId)
        {
            if (employeId != 0)
            {
                using (var entity = new EmployeemanagementsystemEntity())
                {
                    var employData = entity.EmployeeDetails.Where(x =>x.Employee_Id==employeId && x.Is_Deleted == false).SingleOrDefault();
                    if(employData != null)
                    {
                        employData.Is_Deleted = true;
                        employData.Updated_Time_Stamp = DateTime.Now;
                        entity.SaveChanges();
                    }

                }

            }
        }

        #endregion

        #region EditEmployeeDetails

        public EmployeeDetailsModel EditEmployeeDetails( int emploId)
        {
            EmployeeDetailsModel empDetail = new EmployeeDetailsModel();
            using (var entity = new EmployeemanagementsystemEntity())
            {
                 empDetail = (from Emp in entity.EmployeeDetails
                            join Dept in entity.DepartmentDetails
                            on Emp.Department equals Dept.Department_Id
                            where Emp.Is_Deleted == false && Dept.Is_Deleted == false && Emp.Employee_Id == emploId
                            select new EmployeeDetailsModel
                            {
                                EmploId = Emp.Employee_Id,
                                EmployeeFullName = Emp.FullName,
                                EmployeeUsername = Emp.Username,
                                EmployeeEmail = Emp.Email,
                                EmployeeDepartment = Emp.Department,
                                EmployeeMarticule = Emp.Marticule,
                                EmplouyeeAddress = Emp.Address,
                                EmployeePhoneNumber = Emp.PhoneNumber,
                                EmployeeGender = Emp.Gender
                            }).SingleOrDefault();
                //var empDatadb = query.ToList();

                //if (empDatadb != null)
                //{
                //    foreach (var dbEmpDetails in empDatadb)
                //    {
                        
                //        empDetail.EmploId = dbEmpDetails.Employe_Id;
                //        empDetail.EmployeeFullName = dbEmpDetails.Employe_FullName;
                //        empDetail.EmployeeUsername = dbEmpDetails.Employe_Username;
                //        empDetail.EmployeeEmail = dbEmpDetails.Email;
                //        empDetail.EmployeeDepartment = dbEmpDetails.Departments;
                //        empDetail.EmployeeMarticule = dbEmpDetails.Employe_Martic;
                //        empDetail.EmplouyeeAddress = dbEmpDetails.Employe_Address;
                //        empDetail.EmployeePhoneNumber = dbEmpDetails.Employe_PhNumber;
                //        empDetail.EmployeeGender = dbEmpDetails.Gender;
                //    }
                //    return empDetail;

                //}
            }
            return empDetail;
            
        }
        #endregion

        #region FileUpload
        public  void FileUpload(FilesModel filEs )
        {
            if (filEs.FilE != null)
            {
                Files uploaDfilE = new Files();
                using (var entity = new EmployeemanagementsystemEntity())
                {
                    uploaDfilE.File_Name = filEs.filesname; 
                    uploaDfilE.Upload_File = filEs.UploadFile;
                    entity.Files.Add(uploaDfilE);
                    entity.SaveChanges();

                }
            }
        }
        #endregion

        #region ViewFiles

        public List<FilesModel> GetFile()
        {
            List<FilesModel> fileDetails = new List<FilesModel>();

            using (var entity = new EmployeemanagementsystemEntity())
            {
                fileDetails = (from file in entity.Files
                               where file.Is_Deleted == false
                               select new FilesModel
                               {
                                   FileID = file.File_ID,
                                   filesname = file.File_Name,
                                   UploadFile = file.Upload_File
                               }).ToList();
            }

                return fileDetails;
        }

        #endregion

        #region Deletefile

        public void DeleteFile(int Id)
        {
            if (Id != 0)
            {
                using (var entity = new EmployeemanagementsystemEntity())
                {
                    var FileData = entity.Files.Where(x => x.File_ID == Id && x.Is_Deleted == false).SingleOrDefault();
                    if (FileData != null)
                    {
                        FileData.Is_Deleted = true;
                        FileData.Updated_Time_Stamp = DateTime.Now;
                        entity.SaveChanges();
                    }

                }

            }

        }
        #endregion

    }
}
