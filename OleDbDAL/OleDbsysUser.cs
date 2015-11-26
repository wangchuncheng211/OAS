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
    public class sysUser : OAS.IDAL.IsysUser
    {
        public void UpdateSysUserSignStateByUserName(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_sysUser set signState=@SignState where userName=@UserName");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@SignState",OleDbType.Boolean,"signState",objSysUser.SignState),
                                      OleDbHelper.GetParameter("@UserName",OleDbType.VarWChar,20,"userName",objSysUser.UserName)
                                  };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectSysUserByUserNameAndUserPwd(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 1 * from tb_sysUser where userName=@UserName and userPwd=@UserPwd and IsSystemManager=@IsSysManager");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@UserName",OleDbType.VarWChar,20,"userName",objSysUser.UserName),
                                       OleDbHelper.GetParameter("@UserPwd",OleDbType.VarWChar,50,"userPwd",objSysUser.UserPwd),
                                       OleDbHelper.GetParameter("@IsSysManager",OleDbType.Boolean,"IsSystemManager",objSysUser.IsSystemManager)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void UpdateSysUserLoginTimeAndSignState(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_sysUser set loginTime=@LoginTime,signState=@SignState where userName=@UserName");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@LoginTime",OleDbType.Date,"loginTime",objSysUser.LoginTime),
                                      OleDbHelper.GetParameter("@SignState",OleDbType.Boolean,"signState",objSysUser.SignState),
                                      OleDbHelper.GetParameter("@UserName",OleDbType.VarWChar,20,"userName",objSysUser.UserName)
                                  };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectAllSysUser()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_sysUser");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public DataTable SelectSysUserByUserName(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_sysUser where userName=@UserName");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@UserName",OleDbType.VarWChar,20,"userName",objSysUser.UserName)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void InsertIntoSysUser(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_sysUser (userName, userPwd, IsSystemManager) values(@UserName,@UserPwd,@IsSysManager)");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@UserName",OleDbType.VarWChar,20,"userName",objSysUser.UserName),
                                      OleDbHelper.GetParameter("@UserPwd",OleDbType.VarWChar,50,"userPwd",objSysUser.UserPwd),
                                      OleDbHelper.GetParameter("@IsSysManager",OleDbType.Boolean,"IsSystemManager",objSysUser.IsSystemManager)
                                  };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public void DeleteSysUser(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM tb_sysUser WHERE(userName=@UserName)");
            OleDbParameter[] param ={
                                      OleDbHelper.GetParameter("@UserName",OleDbType.VarWChar,20,"userName",objSysUser.UserName)
                                              };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public bool UpdateSysUserPwdByUserName(MSysUser objSysUser)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_sysUser set userPwd=@UserPwd where userName=@UserName");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@UserName",OleDbType.VarWChar,20,"userName",objSysUser.UserName),
                                       OleDbHelper.GetParameter("@UserPwd",OleDbType.VarWChar,50,"userPwd",objSysUser.UserPwd)
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
