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
    public partial class SystemUser : System.Web.UI.Page
    {
        employee emp = new employee();
        sysUser user = new sysUser();
        MSysUser objsysuser = new MSysUser();
        bool SelectRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                //绑定职员姓名
                dlEmployee.DataSource = emp.SelectAllEmployee();
                dlEmployee.DataTextField = "name";
                dlEmployee.DataValueField = "name";
                dlEmployee.DataBind();
                //绑定系统操作员姓名
                DataTable dt = user.SelectAllSysUser();
                DataRow[] row = dt.Select();
                foreach (DataRow rs in row)  //将检索到的数据逐一,循环添加到Listbox1中
                {
                    ListBox1.Items.Add(new ListItem(rs["userName"].ToString(), rs["userName"].ToString(), true));
                }
            }
        }
        protected void RadioButtonManager_CheckedChanged(object sender, EventArgs e)
        {
            SelectRole = true;
        }
        protected void RadioButtonUser_CheckedChanged(object sender, EventArgs e)
        {
            SelectRole = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //判断该系统用户名是否存在,如果存在将不允许创建,否则设置系统用户
            objsysuser.UserName = dlEmployee.Text.ToString();
            DataTable dt = user.SelectSysUserByUserName(objsysuser);
            if (dt.Rows.Count > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该用户已经被设置为系统用户!');</script>");
                return;
            }
            else
            {
                //添加系统用户
                objsysuser.UserPwd = TextBox1.Text.Trim().ToString();
                objsysuser.IsSystemManager = SelectRole;
                user.InsertIntoSysUser(objsysuser);
                ListBox1.DataBind();
            }

            Response.Redirect("SystemUser.aspx");
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ListBox1.Text == "")
                return;
            //删除系统用户,当前用户不能删除
            if (ListBox1.SelectedItem.Text.ToUpper() == Session["loginName"].ToString().ToUpper())
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('当前使用的用户不能删除!');</script>");
            }
            else
            {
                //删除系统操作员后,重新定向到本页
                objsysuser.UserName = ListBox1.SelectedItem.Text.ToString();
                user.DeleteSysUser(objsysuser);
                Response.Redirect("SystemUser.aspx");
            }
        }
    }
}
