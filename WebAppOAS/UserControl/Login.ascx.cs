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
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Attributes.Add("onclick", "this.form.target='_blank'");
        }

        protected void btnCandel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPwd.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                HttpCookie cookie = Request.Cookies["CheckCode"];
                if (string.Compare(cookie.Value, Validator.Text.Trim().ToString(), true) != 0)
                {
                    string myscript = @"alert('验证码输入错误，请重新输入验证码！！！');window.location.href='Default.aspx';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", myscript, true);
                    return;
                }

                if (txtPwd.Text == "" && txtName.Text == "")
                {
                    string myscript = @"alert('用户名称和密码不能为空！');window.location.href='Default.aspx';";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", myscript, true);
                    return;
                }

                sysUser user = new sysUser();
                MSysUser objsysuser = new MSysUser();
                objsysuser.UserName = txtName.Text.Trim();
                objsysuser.UserPwd = txtPwd.Text.Trim();

                if (rdoBtnAdmin.Checked)   //系统管理员登录
                {
                    objsysuser.IsSystemManager = true;
                    DataTable dt = user.SelectSysUserByUserNameAndUserPwd(objsysuser);
                    if (dt.Rows.Count > 0)
                    {
                        //登录成功后，设置登录时间和标识
                        objsysuser.SignState = true;
                        objsysuser.LoginTime = DateTime.Now;
                        user.UpdateSysUserLoginTimeAndSignState(objsysuser);
                        //存储登录用户名称
                        Session["loginName"] = objsysuser.UserName;
                        //存储登录用户身份
                        Session["IsSysManager"] = true;
                        //登录成功后，进入系统主页
                        Response.Redirect("~/SystemDefault.aspx");
                    }
                    else
                    {
                        string myscript = @"alert('用户名或密码错误！');window.location.href='Default.aspx';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", myscript, true);
                    }
                }
                else　　//普通操作职员
                {
                    objsysuser.IsSystemManager = false;
                    DataTable dt = user.SelectSysUserByUserNameAndUserPwd(objsysuser);
                    if (dt.Rows.Count > 0)
                    {
                        //登录成功后，设置登录时间和标识
                        objsysuser.SignState = true;
                        objsysuser.LoginTime = DateTime.Now;
                        user.UpdateSysUserLoginTimeAndSignState(objsysuser);
                        //存储登录用户名称
                        Session["loginName"] = objsysuser.UserName;
                        //存储登录用户身份
                        Session["IsSysManager"] = false;
                        //登录成功后，进入系统主页
                        Response.Redirect("~/SystemDefault.aspx");
                    }
                    else
                    {
                        string myscript = @"alert('用户名或密码错误！');window.location.href='Default.aspx';";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", myscript, true);
                    }
                }
            }
        }
    }
}