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

using System.IO;
using OAS.MODEL;
using OAS.BLL;

namespace WebAppOAS.BaseInfo
{
    public partial class BaseEmployeeManager : System.Web.UI.Page
    {
        employee emp = new employee();
        MEmployee objemp = new MEmployee();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }

            GridView1.DataSource = emp.SelectAllEmployee();
            GridView1.DataKeyNames = new String[] { "id" };
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //获取要清除相片文件的名称（服务器）
            objemp.ID = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
            DataTable dt = emp.SelectEmployeeByID(objemp);
            DataRow[] row = dt.Select();

            //清除数据
            objemp.ID = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
            bool bl = emp.DeleteEmployeeByID(objemp);
            if (bl)
            {
                GridView1.DataSource = emp.SelectAllEmployee();
                GridView1.DataKeyNames = new String[] { "id" };
                GridView1.DataBind();
                //开始删除文件
                foreach (DataRow rs in row)  //将检索到的数据逐一,循环添加到Listbox1中
                {
                    try
                    {
                        FileInfo file = new FileInfo(Server.MapPath(rs["photoPath"].ToString()));
                        file.Delete();
                    }
                    catch { }
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('本数据与其他数据表存在关系暂时不能清除!');</script>");
                //Response.Write(bc.MessageBox("本数据与其他数据表存在关系暂时不能清除!"));
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataKeyNames = new String[] { "id" };
            GridView1.DataBind();
        }
    }
}
