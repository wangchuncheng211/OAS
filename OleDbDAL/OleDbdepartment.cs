using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.DBUtility;
using System.Data;
using System.Data.OleDb;

namespace OAS.OleDbDAL
{
    public class department : OAS.IDAL.Idepartment
    {
        public bool InsertIntoDepartment(MDepartment objdepartment)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_department (name,duty_description) values(@DeptName,@Duty)");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@DeptName",OleDbType.VarWChar,50,"name",objdepartment.Name),
                                      OleDbHelper.GetParameter("@Duty",OleDbType.LongVarWChar,"duty_description",objdepartment.Duty_description)
                                  };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
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
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public void DeleteDepartmentByID(MDepartment objdept)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_department where ID=@ID");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objdept.ID)
                                  };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectDepartmentByID(MDepartment objdept)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_department where ID=@ID");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objdept.ID)
                                  };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public bool UpdateDepartmentByID(MDepartment objdept)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_department set Name=@DeptName,duty_description=@Duty where ID=@ID");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@DeptName",OleDbType.VarWChar,50,"name",objdept.Name),
                                      OleDbHelper.GetParameter("@Duty",OleDbType.LongVarWChar,"duty_description",objdept.Duty_description),
                                      OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",objdept.ID)
                                  };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
