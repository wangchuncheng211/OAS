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
    public class sysUser
    {
        private static readonly IsysUser user = DataAccess.CreatesysUser();

        public void UpdateSysUserSignStateByUserName(MSysUser objSysUser)
        {
            user.UpdateSysUserSignStateByUserName(objSysUser);
        }

        public DataTable SelectSysUserByUserNameAndUserPwd(MSysUser objSysUser)
        {
            return user.SelectSysUserByUserNameAndUserPwd(objSysUser);
        }

        public void UpdateSysUserLoginTimeAndSignState(MSysUser objSysUser)
        {
            user.UpdateSysUserLoginTimeAndSignState(objSysUser);
        }

        public DataTable SelectAllSysUser()
        {
            return user.SelectAllSysUser();
        }

        public DataTable SelectSysUserByUserName(MSysUser objSysUser)
        {
            return user.SelectSysUserByUserName(objSysUser);
        }

        public void InsertIntoSysUser(MSysUser objSysUser)
        {
            user.InsertIntoSysUser(objSysUser);
        }

        public void DeleteSysUser(MSysUser objSysUser)
        {
            user.DeleteSysUser(objSysUser);
        }

        public bool UpdateSysUserPwdByUserName(MSysUser objSysUser)
        {
            return user.UpdateSysUserPwdByUserName(objSysUser);
        }
    }
}
