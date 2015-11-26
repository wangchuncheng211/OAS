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
    public partial class VotingResultPie : System.Web.UI.Page
    {
        protected int Sum;
        protected int AgreeQty;
        protected int DisagreeQty;
        vote votes = new vote();
        MVote objvotes = new MVote();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            objvotes.ID = id;
            DataTable dt = votes.SelectVoteByID(objvotes);
            AgreeQty = Convert.ToInt32(dt.Rows[0]["agreeQty"].ToString());
            DisagreeQty = Convert.ToInt32(dt.Rows[0]["disagreeQty"].ToString());
            Sum = AgreeQty + DisagreeQty;
        }
    }
}
