using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace OAS.SQLDAL
{
    public class department : OAS.IDAL.Idepartment
    {
        public bool InsertIntoDepartment(MDepartment objdepartment)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_department (name,duty_description) values(@DeptName,@Duty)");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@DeptName",SqlDbType.VarChar,50,"name",objdepartment.Name),
                                      SQLDbHelper.GetParameter("@Duty",SqlDbType.Text,"duty_description",objdepartment.Duty_description)
                                  };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectAllDepartment()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_department");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public void DeleteDepartmentByID(MDepartment objdept)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_department where ID=@ID");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objdept.ID)
                                  };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectDepartmentByID(MDepartment objdept)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_department where ID=@ID");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objdept.ID)
                                  };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(),param);
            return dt;
        }

        public bool UpdateDepartmentByID(MDepartment objdept)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_department set Name=@DeptName,duty_description=@Duty where ID=@ID");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@DeptName",SqlDbType.VarChar,50,"name",objdept.Name),
                                      SQLDbHelper.GetParameter("@Duty",SqlDbType.Text,"duty_description",objdept.Duty_description),
                                      SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objdept.ID)
                                  };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public int CheckDeptEmpNumByDeptID(MDepartment objdept)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("SELECT count(emp.ID) FROM   tb_employee emp LEFT JOIN tb_department dept ON emp.dept = dept.name   WHRER dept.ID=@ID");
        //    SqlParameter[] param ={
        //                              SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",objdept.ID)
        //                          };
        //    int emp_count = SQLDbHelper.ExecuteSql(sb.ToString(),param);
        //    return emp_count;
        //}
    }
}

