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
    public partial class Voting : System.Web.UI.Page
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

            DataList1.DataSource = votes.SelectAllVote();
            DataList1.DataKeyField = "ID";
            DataList1.DataBind();
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (Convert.ToString(Session["vote"]) != string.Empty)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('每人只有一次投票机会,谢谢!!');</script>");
                //Response.Write("<script>history.go(-1)</script>");
                return;
            }
            else
            {
                int str = (int)DataList1.DataKeys[e.Item.ItemIndex];
                string commandName = e.CommandName.ToString().Trim();
                if (commandName == "agree")
                {
                    int AgreeQty = 0;
                    //检索　原有票　+１
                    objvotes.ID = str;
                    DataTable dt = votes.SelectVoteByID(objvotes);
                    AgreeQty = Convert.ToInt32(dt.Rows[0]["agreeQty"]);
                    AgreeQty = AgreeQty + 1;
                    //更新投票
                    objvotes.AgreeQty = AgreeQty;
                    objvotes.ID = str;
                    bool bl = votes.UpdateVoteAgreeQtyByID(objvotes);
                    if (bl)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('投票成功!');</script>");
                    }
                    
                }
                else if (commandName == "disagree")
                {
                    int DisagreeQty = 0;
                    //检索　原有票　+１
                    objvotes.ID = str;
                    DataTable dt = votes.SelectVoteByID(objvotes);
                    DisagreeQty = Convert.ToInt32(dt.Rows[0]["disagreeQty"]);
                    DisagreeQty = DisagreeQty + 1;
                    //更新投票
                    objvotes.DisagreeQty = DisagreeQty;
                    objvotes.ID = str;
                    bool bl = votes.UpdateVoteDisagreeQtyByID(objvotes);
                    if (bl)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('投票成功!');</script>");
                    }
                }

                DataList1.DataSource = votes.SelectAllVote();
                DataList1.DataKeyField = "ID";
                DataList1.DataBind();
                //标记本浏览器已经投过票
                Session["vote"] = "vote";
            }

        }
    }
}
