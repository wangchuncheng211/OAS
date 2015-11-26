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
    public class employee :  OAS.IDAL.Iemployee
    {
        public DataTable SelectGoodEmployee()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT name, dept, job, photoPath, qty FROM (SELECT * FROM tb_employee a INNER JOIN (SELECT TOP 10 * FROM (SELECT employeeName, COUNT(late) + COUNT(quit) AS qty FROM tb_sign GROUP BY employeeName) DERIVEDTBL ORDER BY qty) b ON a.name = b.employeeName) DERIVEDTBL ORDER BY qty");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public DataTable SelectAllEmployee()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_employee");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public bool InsertIntoEmployee(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_employee (name,sex,birthday,learnDegree,post,dept,job,tel,address,email,state,photoPath) values(@EmpName,@Sex,@Birthday,@LearnDegree,@Post,@Department,@Job,@Tel,@Address,@Email,@State,@PhotoPath)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@EmpName",OleDbType.VarWChar,20,"name",emp.Name),
                                       OleDbHelper.GetParameter("@Sex",OleDbType.VarWChar,10,"sex",emp.Sex),
                                       OleDbHelper.GetParameter("@Birthday",OleDbType.Date,"birthday",emp.Birthday),
                                       OleDbHelper.GetParameter("@LearnDegree",OleDbType.VarWChar,50,"learnDegree",emp.LearnDegree),
                                       OleDbHelper.GetParameter("@Post",OleDbType.VarWChar,50,"post",emp.Post),
                                       OleDbHelper.GetParameter("@Department",OleDbType.VarWChar,50,"dept",emp.Dept),
                                       OleDbHelper.GetParameter("@Job",OleDbType.VarWChar,50,"job",emp.Job),
                                       OleDbHelper.GetParameter("@Tel",OleDbType.VarWChar,50,"tel",emp.Tel),
                                       OleDbHelper.GetParameter("@Address",OleDbType.VarWChar,50,"address",emp.Address),
                                       OleDbHelper.GetParameter("@Email",OleDbType.VarWChar,50,"email",emp.Email),
                                       OleDbHelper.GetParameter("@State",OleDbType.VarWChar,50,"state",emp.State),
                                       OleDbHelper.GetParameter("@PhotoPath",OleDbType.LongVarWChar,"photoPath",emp.PhotoPath)
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

        public DataTable SelectEmployeeByID(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_employee where ID=@ID");
            OleDbParameter[] param = { 
                                        OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",emp.ID)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public bool DeleteEmployeeByID(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_employee where ID=@ID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",emp.ID)
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

        public bool UpdateEmployeeByID(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_employee set name=@EmpName,sex=@Sex,birthday=@Birthday,");
            sb.Append("learnDegree=@LearnDegree,post=@Post,dept=@Department,job=@Job,tel=@Tel,");
            sb.Append("address=@Address,email=@Email,state=@State where ID=@ID");
            OleDbParameter[] param = {
                                       
                                       OleDbHelper.GetParameter("@EmpName",OleDbType.VarWChar,20,"name",emp.Name),
                                       OleDbHelper.GetParameter("@Sex",OleDbType.VarWChar,10,"sex",emp.Sex),
                                       OleDbHelper.GetParameter("@Birthday",OleDbType.Date,"birthday",emp.Birthday),
                                       OleDbHelper.GetParameter("@LearnDegree",OleDbType.VarWChar,50,"learnDegree",emp.LearnDegree),
                                       OleDbHelper.GetParameter("@Post",OleDbType.VarWChar,50,"post",emp.Post),
                                       OleDbHelper.GetParameter("@Department",OleDbType.VarWChar,50,"dept",emp.Dept),
                                       OleDbHelper.GetParameter("@Job",OleDbType.VarWChar,50,"job",emp.Job),
                                       OleDbHelper.GetParameter("@Tel",OleDbType.VarWChar,50,"tel",emp.Tel),
                                       OleDbHelper.GetParameter("@Address",OleDbType.VarWChar,50,"address",emp.Address),
                                       OleDbHelper.GetParameter("@Email",OleDbType.VarWChar,50,"email",emp.Email),
                                       OleDbHelper.GetParameter("@State",OleDbType.VarWChar,50,"state",emp.State),
                                       OleDbHelper.GetParameter("@ID",OleDbType.Integer,4,"ID",emp.ID)
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

        public DataTable SelectEmployeeByDept(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_employee where dept=@Dept");
            OleDbParameter[] param = { 
                                        OleDbHelper.GetParameter("@Dept",OleDbType.VarWChar,50,"dept",emp.Dept)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }
    }
}
