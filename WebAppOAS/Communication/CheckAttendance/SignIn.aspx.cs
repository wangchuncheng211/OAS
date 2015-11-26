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

namespace WebAppOAS.Communication.CheckAttendance
{
    public partial class SignIn : System.Web.UI.Page
    {
        static string up;
        static string down;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            lblSTime.Text = DateTime.Now.ToString("HH:mm:ss");   //注意大小写
            lblXTime.Text = DateTime.Now.ToString("HH:mm:ss");

            signState signstate = new signState();

            DataTable dt = signstate.SelectAllSignState();
            DataRow[] row = dt.Select("SignStateID=1");
            foreach (DataRow rs in row)
            {
                Label1.Text = "上班时间：" + Convert.ToDateTime(rs["time"]).ToString("HH:mm:ss");
                up = Convert.ToDateTime(rs["time"]).ToString("HH:mm:ss");
            }
            DataRow[] rw = dt.Select("SignStateID=2");
            foreach (DataRow rs1 in rw)
            {
                Label2.Text = "下班时间：" + Convert.ToDateTime(rs1["time"]).ToString("HH:mm:ss");
                down = Convert.ToDateTime(rs1["time"]).ToString("HH:mm:ss");
            }
            if (Request.QueryString["id"].ToString() == "1")
                btnSignOut.Enabled = false;
            else
                btnSignIn.Enabled = false;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            sign signs = new sign();
            MSign objsign = new MSign();
            //上班进行考勤设置
            if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")), Convert.ToDateTime(up)) <= 0)
            {
                objsign.Datetime = DateTime.Now;
                objsign.EmployeeName = Session["loginName"].ToString();
                objsign.Late = false;
                objsign.Quit = false;
                signs.InsertIntoSign(objsign);
            }
            else
            {
                objsign.Datetime = DateTime.Now;
                objsign.EmployeeName = Session["loginName"].ToString();
                objsign.Late = true;
                objsign.Quit = false;
                signs.InsertIntoSign(objsign);
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('签到成功!');</script>");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            sign signs = new sign();
            MSign objsign = new MSign();
            //下班进行考勤设置
            if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("hh:mm:ss")), Convert.ToDateTime(down)) >= 0)
            {
                objsign.Datetime = DateTime.Now;
                objsign.EmployeeName = Session["loginName"].ToString();
                objsign.Late = false;
                objsign.Quit = false;
                signs.InsertIntoSign(objsign);
            }
            else
            {
                objsign.Datetime = DateTime.Now;
                objsign.EmployeeName = Session["loginName"].ToString();
                objsign.Late = false;
                objsign.Quit = true;
                signs.InsertIntoSign(objsign);
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('签退成功!');</script>");
        }
    }
}
