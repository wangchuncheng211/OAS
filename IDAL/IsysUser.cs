using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface IsysUser
    {
        void UpdateSysUserSignStateByUserName(MSysUser objSysUser);
        DataTable SelectSysUserByUserNameAndUserPwd(MSysUser objSysUser);
        void UpdateSysUserLoginTimeAndSignState(MSysUser objSysUser);
        DataTable SelectAllSysUser();
        DataTable SelectSysUserByUserName(MSysUser objSysUser);
        void InsertIntoSysUser(MSysUser objSysUser);
        void DeleteSysUser(MSysUser objSysUser);
        bool UpdateSysUserPwdByUserName(MSysUser objSysUser);
    }
}
