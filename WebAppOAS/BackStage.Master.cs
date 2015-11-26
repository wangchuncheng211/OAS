using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OAS.MODEL;
using OAS.BLL;

namespace WebAppOAS
{
    public partial class BackStage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //为管理员和普通职员分配不同界面
            sysUser user = new sysUser();
            MSysUser objsysuser = new MSysUser();
            objsysuser.UserName = Session["loginName"].ToString();
            DataTable dt = user.SelectSysUserByUserName(objsysuser);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(Session["IsSysManager"]))
                {
                    AdminNav1.Visible = true;
                    UserNav1.Visible = false;
                }
                else
                {
                    AdminNav1.Visible = false;
                    UserNav1.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}
