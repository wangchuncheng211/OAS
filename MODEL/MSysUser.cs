using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MSysUser
    {
        private int id;
        /// <summary>
        /// 系统用户id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string userName;
        /// <summary>
        /// 系统用户名字
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string userPwd;
        /// <summary>
        /// 系统用户密码
        /// </summary>
        public string UserPwd
        {
            get { return userPwd; }
            set { userPwd = value; }
        }

        private DateTime loginTime;
        /// <summary>
        /// 系统用户登录时间
        /// </summary>
        public DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }

        private bool isSystemManager;
        /// <summary>
        /// 系统用户是否是管理员
        /// </summary>
        public bool IsSystemManager
        {
            get { return isSystemManager; }
            set { isSystemManager = value; }
        }

        private bool signState;
        /// <summary>
        /// 系统用户是否在线
        /// </summary>
        public bool SignState
        {
            get { return signState; }
            set { signState = value; }
        }
    }
}
