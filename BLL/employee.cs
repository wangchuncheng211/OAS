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
    public class employee
    {
        private static readonly Iemployee emp = DataAccess.Createemployee();

        public DataTable SelectGoodEmployee()
        {
            return emp.SelectGoodEmployee();
        }

        public DataTable SelectAllEmployee()
        {
            return emp.SelectAllEmployee();
        }

        public bool InsertIntoEmployee(MEmployee emplye)
        {
            return emp.InsertIntoEmployee(emplye);
        }

        public DataTable SelectEmployeeByID(MEmployee emplye)
        {
            return emp.SelectEmployeeByID(emplye);
        }

        public bool DeleteEmployeeByID(MEmployee emplye)
        {
            return emp.DeleteEmployeeByID(emplye);
        }

        public bool UpdateEmployeeByID(MEmployee emplye)
        {
            return emp.UpdateEmployeeByID(emplye);
        }

        public DataTable SelectEmployeeByDept(MEmployee emplye)
        {
            return emp.SelectEmployeeByDept(emplye);
        }
    }
}
