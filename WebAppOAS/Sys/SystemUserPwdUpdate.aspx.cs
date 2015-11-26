using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using OAS.MODEL;
using OAS.BLL;

namespace WebAppOAS.Sys
{
    public partial class SystemUserPwdUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            Label1.Text = Session["loginName"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            sysUser user = new sysUser();
            MSysUser objsysuser = new MSysUser();
            objsysuser.UserName = Session["loginName"].ToString();
            objsysuser.UserPwd = TextBox1.Text.Trim().ToString();
            bool bl = user.UpdateSysUserPwdByUserName(objsysuser);
            if (bl)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('设置新密码成功!');</script>");
                //Response.Write(bc.MessageBox("设置新密码成功！"));
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('设置新密码失败!');</script>");
                //Response.Write(bc.MessageBox("设置新密码失败！"));
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}
