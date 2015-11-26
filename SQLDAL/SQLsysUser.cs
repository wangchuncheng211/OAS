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
    public class sysUser : OAS.IDAL.IsysUser
    {
        public void UpdateSysUserSignStateByUserName(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_sysUser set signState=@SignState where userName=@UserName");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@SignState",SqlDbType.Bit,"signState",objSysUser.SignState),
                                      SQLDbHelper.GetParameter("@UserName",SqlDbType.VarChar,20,"userName",objSysUser.UserName)
                                  };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectSysUserByUserNameAndUserPwd(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 1 * from tb_sysUser where userName=@UserName and userPwd=@UserPwd and IsSystemManager=@IsSysManager");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@UserName",SqlDbType.VarChar,20,"userName",objSysUser.UserName),
                                       SQLDbHelper.GetParameter("@UserPwd",SqlDbType.VarChar,50,"userPwd",objSysUser.UserPwd),
                                       SQLDbHelper.GetParameter("@IsSysManager",SqlDbType.Bit,"IsSystemManager",objSysUser.IsSystemManager)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void UpdateSysUserLoginTimeAndSignState(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_sysUser set loginTime=@LoginTime,signState=@SignState where userName=@UserName");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@LoginTime",SqlDbType.DateTime,"loginTime",objSysUser.LoginTime),
                                      SQLDbHelper.GetParameter("@SignState",SqlDbType.Bit,"signState",objSysUser.SignState),
                                      SQLDbHelper.GetParameter("@UserName",SqlDbType.VarChar,20,"userName",objSysUser.UserName)
                                  };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectAllSysUser()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_sysUser");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public DataTable SelectSysUserByUserName(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_sysUser where userName=@UserName");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@UserName",SqlDbType.VarChar,20,"userName",objSysUser.UserName)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void InsertIntoSysUser(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_sysUser (userName, userPwd, loginTime, IsSystemManager) values(@UserName,@UserPwd,'',@IsSysManager)");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@UserName",SqlDbType.VarChar,20,"userName",objSysUser.UserName),
                                      SQLDbHelper.GetParameter("@UserPwd",SqlDbType.VarChar,50,"userPwd",objSysUser.UserPwd),
                                      SQLDbHelper.GetParameter("@IsSysManager",SqlDbType.Bit,"IsSystemManager",objSysUser.IsSystemManager)
                                  };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public void DeleteSysUser(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM tb_sysUser WHERE(userName=@UserName)");
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@UserName",SqlDbType.VarChar,20,"userName",objSysUser.UserName)
                                              };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public bool UpdateSysUserPwdByUserName(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_sysUser set userPwd=@UserPwd where userName=@UserName");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@UserName",SqlDbType.VarChar,20,"userName",objSysUser.UserName),
                                       SQLDbHelper.GetParameter("@UserPwd",SqlDbType.VarChar,50,"userPwd",objSysUser.UserPwd)
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
    }
}
