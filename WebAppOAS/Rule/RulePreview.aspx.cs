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

namespace WebAppOAS.Rule
{
    public partial class RulePreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rule rules = new rule();
                DataTable dt = rules.SelectAllRules();
                DataRow[] row = dt.Select();
                foreach (DataRow rs in row)  //将检索到的数据逐一,循环添加到Listbox1中
                {
                    TextBox1.Text = rs["content"].ToString();
                }
            }
        }
    }
}
