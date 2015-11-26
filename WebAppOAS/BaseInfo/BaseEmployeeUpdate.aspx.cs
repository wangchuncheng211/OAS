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

namespace WebAppOAS.BaseInfo
{
    public partial class BaseEmployeeUpdate : System.Web.UI.Page
    {
        employee emp = new employee();
        MEmployee objemp = new MEmployee();
        department dept = new department();
        MDepartment objdept = new MDepartment();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {

                Response.Redirect("~/Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                //将部门名称绑定到下拉列表框中
                dlDepartment.DataSource = dept.SelectAllDepartment();
                dlDepartment.DataBind();

                objemp.ID = Convert.ToInt32(Request.QueryString["id"]);
                DataTable dt = emp.SelectEmployeeByID(objemp);

                txtName.Text = dt.Rows[0]["name"].ToString();
                dlSex.Text = dt.Rows[0]["sex"].ToString();
                txtBirthday.Text = dt.Rows[0]["birthday"].ToString();
                txtAddress.Text = dt.Rows[0]["address"].ToString();
                txtLearn.Text = dt.Rows[0]["learnDegree"].ToString();
                txtPost.Text = dt.Rows[0]["post"].ToString();
                txtTel.Text = dt.Rows[0]["tel"].ToString();
                txtEmail.Text = dt.Rows[0]["email"].ToString();
                dlDepartment.Text = dt.Rows[0]["dept"].ToString();
                dlJob.Text = dt.Rows[0]["job"].ToString();
                dlState.Text = dt.Rows[0]["state"].ToString();
            }

        }
        protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            objemp.Name = txtName.Text.Trim().ToString();
            objemp.Sex = dlSex.Text.ToString();
            objemp.Birthday = Convert.ToDateTime(txtBirthday.Text.Trim());
            objemp.LearnDegree = txtLearn.Text.Trim().ToString();
            objemp.Post = txtPost.Text.Trim().ToString();
            objemp.Dept = dlDepartment.Text.ToString();
            objemp.Job = dlJob.Text.ToString();
            objemp.Tel = txtTel.Text.Trim().ToString();
            objemp.Address = txtAddress.Text.Trim().ToString();
            objemp.Email = txtEmail.Text.Trim().ToString();
            objemp.State = dlState.Text.ToString();
            bool bl = emp.UpdateEmployeeByID(objemp);
        
            if (bl)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('员工基本信息修改成功!');</script>");

                Response.Redirect("~/BaseInfo/BaseEmployeeManager.aspx");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('员工基本信息修改失败!');</script>");
            }
        }
        protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("~/BaseInfo/BaseEmployeeManager.aspx");
        }
    }
}
