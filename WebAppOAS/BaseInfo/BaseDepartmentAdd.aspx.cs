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
    public partial class BaseDepartmentAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            department dept = new department();
            MDepartment objdept = new MDepartment();
            objdept.Name = txtName.Text.Trim().ToString();
            objdept.Duty_description = txtContent.Text.Trim().ToString();
            bool bl = dept.InsertIntoDepartment(objdept);
            if (bl)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('新建部门成功!');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('新建部门失败!');</script>");
            }
        }
        protected void imgBtnClear_Click(object sender, ImageClickEventArgs e)
        {
            txtName.Text = "";
            txtContent.Text = "";
        }
    }
}
