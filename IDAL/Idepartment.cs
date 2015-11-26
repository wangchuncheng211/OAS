using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface Idepartment
    {
        bool InsertIntoDepartment(MDepartment objdepartment);
        DataTable SelectAllDepartment();
        void DeleteDepartmentByID(MDepartment objdept);
        DataTable SelectDepartmentByID(MDepartment objdept);
        bool UpdateDepartmentByID(MDepartment objdept);
    }
}
