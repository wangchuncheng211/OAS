using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OAS.MODEL;
using OAS.BLL;

namespace WebAppOAS.UserControl
{
    public partial class Notice : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            notice notce = new notice();

            DataList1.DataSource = notce.SelectAllNotice();
            DataList1.DataBind();
        }

        protected string MyContent(string input)
        {
            if (input.Length > 150)
            {
                return input.Substring(0, 100) + "...";
            }
            else 
            {
                return input;
            }
        }
    }
}