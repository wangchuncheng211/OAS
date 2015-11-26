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
    public class employee : OAS.IDAL.Iemployee
    {
        public DataTable SelectGoodEmployee()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT name, dept, job, photoPath, qty FROM (SELECT * FROM tb_employee a INNER JOIN (SELECT TOP 10 * FROM (SELECT employeeName, COUNT(late) + COUNT(quit) AS qty FROM tb_sign GROUP BY employeeName) DERIVEDTBL ORDER BY qty) b ON a.name = b.employeeName) DERIVEDTBL ORDER BY qty");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public DataTable SelectAllEmployee()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_employee");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public bool InsertIntoEmployee(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_employee (name,sex,birthday,learnDegree,post,dept,job,tel,address,email,state,photoPath) values(@EmpName,@Sex,@Birthday,@LearnDegree,@Post,@Department,@Job,@Tel,@Address,@Email,@State,@PhotoPath)");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@EmpName",SqlDbType.VarChar,20,"name",emp.Name),
                                       SQLDbHelper.GetParameter("@Sex",SqlDbType.VarChar,10,"sex",emp.Sex),
                                       SQLDbHelper.GetParameter("@Birthday",SqlDbType.SmallDateTime,"birthday",emp.Birthday),
                                       SQLDbHelper.GetParameter("@LearnDegree",SqlDbType.VarChar,50,"learnDegree",emp.LearnDegree),
                                       SQLDbHelper.GetParameter("@Post",SqlDbType.VarChar,50,"post",emp.Post),
                                       SQLDbHelper.GetParameter("@Department",SqlDbType.VarChar,50,"dept",emp.Dept),
                                       SQLDbHelper.GetParameter("@Job",SqlDbType.VarChar,50,"job",emp.Job),
                                       SQLDbHelper.GetParameter("@Tel",SqlDbType.VarChar,50,"tel",emp.Tel),
                                       SQLDbHelper.GetParameter("@Address",SqlDbType.VarChar,50,"address",emp.Address),
                                       SQLDbHelper.GetParameter("@Email",SqlDbType.VarChar,50,"email",emp.Email),
                                       SQLDbHelper.GetParameter("@State",SqlDbType.VarChar,50,"state",emp.State),
                                       SQLDbHelper.GetParameter("@PhotoPath",SqlDbType.VarChar,50,"photoPath",emp.PhotoPath)
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

        public DataTable SelectEmployeeByID(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_employee where ID=@ID");
            SqlParameter[] param = { 
                                        SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",emp.ID)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(),param);
            return dt;
        }

        public bool DeleteEmployeeByID(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_employee where ID=@ID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",emp.ID)
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

        public bool UpdateEmployeeByID(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_employee set name=@EmpName,sex=@Sex,birthday=@Birthday,");
            sb.Append("learnDegree=@LearnDegree,post=@Post,dept=@Department,job=@Job,tel=@Tel,");
            sb.Append("address=@Address,email=@Email,state=@State where ID=@ID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"ID",emp.ID),
                                       SQLDbHelper.GetParameter("@EmpName",SqlDbType.VarChar,20,"name",emp.Name),
                                       SQLDbHelper.GetParameter("@Sex",SqlDbType.VarChar,10,"sex",emp.Sex),
                                       SQLDbHelper.GetParameter("@Birthday",SqlDbType.SmallDateTime,"birthday",emp.Birthday),
                                       SQLDbHelper.GetParameter("@LearnDegree",SqlDbType.VarChar,50,"learnDegree",emp.LearnDegree),
                                       SQLDbHelper.GetParameter("@Post",SqlDbType.VarChar,50,"post",emp.Post),
                                       SQLDbHelper.GetParameter("@Department",SqlDbType.VarChar,50,"dept",emp.Dept),
                                       SQLDbHelper.GetParameter("@Job",SqlDbType.VarChar,50,"job",emp.Job),
                                       SQLDbHelper.GetParameter("@Tel",SqlDbType.VarChar,50,"tel",emp.Tel),
                                       SQLDbHelper.GetParameter("@Address",SqlDbType.VarChar,50,"address",emp.Address),
                                       SQLDbHelper.GetParameter("@Email",SqlDbType.VarChar,50,"email",emp.Email),
                                       SQLDbHelper.GetParameter("@State",SqlDbType.VarChar,50,"state",emp.State)
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

        public DataTable SelectEmployeeByDept(MEmployee emp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_employee where dept=@Dept");
            SqlParameter[] param = { 
                                        SQLDbHelper.GetParameter("@Dept",SqlDbType.VarChar,50,"dept",emp.Dept)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }
    }
}
