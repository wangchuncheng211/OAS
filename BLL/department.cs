using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.IDAL;
using OAS.DALFactory;
using System.Data;

namespace OAS.BLL
{
    public class department
    {
        private static readonly Idepartment dept = DataAccess.Createdepartment();

        public bool InsertIntoDepartment(MDepartment objdepartment)
        {
            return dept.InsertIntoDepartment(objdepartment);
        }

        public DataTable SelectAllDepartment()
        {
            return dept.SelectAllDepartment();
        }

        public void DeleteDepartmentByID(MDepartment objdept)
        {
            dept.DeleteDepartmentByID(objdept);
        }

        public DataTable SelectDepartmentByID(MDepartment objdept)
        {
            return dept.SelectDepartmentByID(objdept);
        }

        public bool UpdateDepartmentByID(MDepartment objdept)
        {
            return dept.UpdateDepartmentByID(objdept);
        }
    }
}
