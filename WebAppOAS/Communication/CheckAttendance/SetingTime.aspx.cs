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
    public partial class SetingTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            signState signstate = new signState();
            MSignState objsignstate = new MSignState();
            bool blS;
            bool blX;
            DataTable dt = signstate.SelectAllSignState();
            if (dt.Rows.Count > 0)
            {
                objsignstate.ID = 1;
                objsignstate.Time = Convert.ToDateTime(TextBox1.Text.Trim());
                blS = signstate.UpdateSignStateByID(objsignstate);
                objsignstate.ID = 2;
                objsignstate.Time = Convert.ToDateTime(TextBox2.Text.Trim());
                blX = signstate.UpdateSignStateByID(objsignstate);

                if (blS && blX)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上下班时间设置成功!');</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上下班时间设置失败!');</script>");
                }
            }
            else 
            {
                objsignstate.Signstate_describe = "上班";
                objsignstate.Time = Convert.ToDateTime(TextBox1.Text.Trim());
                blS = signstate.InsertIntoSignState(objsignstate);
                objsignstate.Signstate_describe = "下班";
                objsignstate.Time = Convert.ToDateTime(TextBox2.Text.Trim());
                blX = signstate.InsertIntoSignState(objsignstate);

                if (blS && blX)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上下班时间设置成功!');</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上下班时间设置失败!');</script>");
                }
            }

        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "00:00:00";
            TextBox2.Text = "00:00:00";
        }
    }
}
