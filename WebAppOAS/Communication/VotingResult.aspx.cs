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
    public partial class VotingResult : System.Web.UI.Page
    {
        vote votes = new vote();
        MVote objvotes = new MVote();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }

            GridView1.DataSource = votes.SelectAllVote();
            GridView1.DataKeyNames = new String[] { "ID" };
            GridView1.DataBind();

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //清除数据
            objvotes.ID = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
            votes.DeleteVoteByID(objvotes);

            GridView1.DataSource = votes.SelectAllVote();
            GridView1.DataBind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            objvotes.ID = Convert.ToInt32(this.GridView1.DataKeys[e.NewEditIndex].Value);
            objvotes.AgreeQty = 0;
            objvotes.DisagreeQty = 0;
            votes.UpdateVoteAgreeQtyByID(objvotes);
            votes.UpdateVoteDisagreeQtyByID(objvotes);

            GridView1.DataSource = votes.SelectAllVote();
            GridView1.DataBind();
        }
    }
}
