using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

using OAS.MODEL;
using OAS.BLL;
namespace WebAppOAS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            //在应用程序启动时运行的代码
            Application.Add("online", 0);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            Session.Timeout = 30;

            Application.Lock();                               //锁定Application
            int iNum = Int32.Parse(Application["online"].ToString()) + 1;
            Application.Set("online", iNum);                  //修改对象的值，为自身加1
            Application.UnLock();                             //解锁对象的锁定
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。
            sysUser sysuser = new sysUser();
            MSysUser objsysuser = new MSysUser();
            objsysuser.UserName = Session["loginName"].ToString();
            objsysuser.SignState = false;
            sysuser.UpdateSysUserSignStateByUserName(objsysuser);

            Application.Lock();
            int iNum = Int32.Parse(Application["online"].ToString()) - 1;
            Application.Set("online", iNum);
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码
            sysUser sysuser = new sysUser();
            MSysUser objsysuser = new MSysUser();
            objsysuser.UserName = Session["loginName"].ToString();
            objsysuser.SignState = false;
            sysuser.UpdateSysUserSignStateByUserName(objsysuser);
        }
    }
}