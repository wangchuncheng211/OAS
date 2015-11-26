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
    public partial class RuleUpdate : System.Web.UI.Page
    {
        rule rules = new rule();
        MRule objrules = new MRule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = rules.SelectAllRules();
                DataRow[] row = dt.Select();
                foreach (DataRow rs in row)
                {
                    FreeTextBox1.Text = rs["content"].ToString();
                }
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            objrules.RuleContent = FreeTextBox1.Text.ToString();
            objrules.ID = 1;
            DataTable dt = rules.SelectAllRules();
            if (dt.Rows.Count > 0)
            {

                bool blUpdate = rules.UpdateRuleContentByID(objrules);
                if (blUpdate)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新成功!');</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新失败!');</script>");
                }
            }
            else 
            {
                bool blInsert = rules.InsertIntoRule(objrules);
                if (blInsert)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('插入成功!');</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('插入失败!');</script>");
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            FreeTextBox1.Text = "";
        }
    }
}
