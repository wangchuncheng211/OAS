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

namespace WebAppOAS.UserControl
{
    public partial class OnlineUser : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                Response.Write("<script>alert('请登录后再进入系统!');</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            lblUser.Text = "在线职员：" + Session["loginName"].ToString();
        }
        protected void imgBtnLogonOut_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["loginName"] != null)
            {
                sysUser user = new sysUser();
                MSysUser objsysuser = new MSysUser();
                objsysuser.UserName = Session["loginName"].ToString();
                user.UpdateSysUserSignStateByUserName(objsysuser);
            }
            Session["loginName"] = null;
            Response.Redirect("~/Default.aspx");
        }
    }
}