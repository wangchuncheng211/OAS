using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface Iemployee
    {
        DataTable SelectGoodEmployee();
        DataTable SelectAllEmployee();
        bool InsertIntoEmployee(MEmployee emp);
        DataTable SelectEmployeeByID(MEmployee emp);
        bool DeleteEmployeeByID(MEmployee emp);
        bool UpdateEmployeeByID(MEmployee emp);
        DataTable SelectEmployeeByDept(MEmployee emp);
    }
}
