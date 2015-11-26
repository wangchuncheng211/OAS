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

namespace WebAppOAS.Communication
{
    public partial class VoteItemSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
        }
        protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            vote votes = new vote();
            MVote objvotes = new MVote();
            objvotes.VoteTitle = txtTitle.Text.ToString();
            objvotes.VoteContent = txtContent.Text.ToString();
            bool bl = votes.InsertIntoVote(objvotes);
            if (bl)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('数据提交成功!');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('网络故障,数据提交失败!');</script>");
            }
        }
        protected void imgBtnClear_Click(object sender, ImageClickEventArgs e)
        {
            txtTitle.Text = "";
            txtContent.Text = "";
        }
    }
}
