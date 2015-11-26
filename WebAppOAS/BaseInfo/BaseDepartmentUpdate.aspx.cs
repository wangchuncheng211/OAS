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
    public partial class BaseDepartmentUpdate : System.Web.UI.Page
    {
        department dept = new department();
        MDepartment objdept = new MDepartment();

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
                objdept.ID = Convert.ToInt32(Request.QueryString["id"]);
                DataTable dt = dept.SelectDepartmentByID(objdept);
             
                txtName.Text = dt.Rows[0][1].ToString();
                txtContent.Text = dt.Rows[0][2].ToString();
            }

        }

        protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            objdept.Name = txtName.Text.Trim().ToString();
            objdept.Duty_description = txtContent.Text.Trim().ToString();
            objdept.ID = Convert.ToInt32(Request.QueryString["id"]);
            bool bl = dept.UpdateDepartmentByID(objdept);
            if (bl)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('部门基本信息修改成功!');</script>");
                //Response.Write("<script language='javascript'>this.parent.MainFrame.location.href='BaseDepartmentManager.aspx'</script>");
                Response.Redirect("~/BaseInfo/BaseDepartmentManager.aspx");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('部门基本信息修改失败!');</script>");
            }
        }
        protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Write("<script language='javascript'>this.parent.MainFrame.location.href='BaseDepartmentManager.aspx'</script>");
            Response.Redirect("~/BaseInfo/BaseDepartmentManager.aspx");
        }
    }
}
