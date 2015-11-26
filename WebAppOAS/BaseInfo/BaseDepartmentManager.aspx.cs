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
    public partial class BaseDepartmentManager : System.Web.UI.Page
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
            
            GridView1.DataSource = dept.SelectAllDepartment();
            GridView1.DataKeyNames = new String[] { "ID" };
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                objdept.ID = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
                DataTable dtDept = dept.SelectDepartmentByID(objdept);
                employee emp = new employee();
                MEmployee objemp = new MEmployee();
                objemp.Dept = dtDept.Rows[0]["name"].ToString();
                DataTable dtEmp = emp.SelectEmployeeByDept(objemp);
                if (dtEmp.Rows.Count > 0)
                {
                    string myscript = @"alert('此部门内尚有员工，不能删除！');";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myscript", myscript, true);
                }
                else
                {
                    dept.DeleteDepartmentByID(objdept);
                }
                GridView1.DataSource = dept.SelectAllDepartment();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
