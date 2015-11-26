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

namespace WebAppOAS.BaseInfo
{
    public partial class BaseNoticeIssuance : System.Web.UI.Page
    {
        notice notce = new notice();
        MNotice objNotice = new MNotice();
        private string message;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
            }
            message = Request.QueryString["mess"];
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                TextBoxInit();
            }
        }
        protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            bool bl;
            objNotice.NoticeTitle = txtTitle.Text.Trim().ToString();
            objNotice.NoticeTime = DateTime.Now;//.ToString("yyyy-MM-dd");
            objNotice.NoticePerson = Session["loginName"].ToString();
            objNotice.NoticeContent = FreeTextBox1.Text.Trim().ToString();
            objNotice.NoticeHtmlName = DateTime.Now.ToString("ddHHmmss");//生成静态页文件名称
            if (message == "1")//发布公告
            {
                bl = notce.InsertIntoNotice(objNotice);
                notce.SelectAllNoticeUpdXml();
                notce.CreateNoticeHtml(objNotice);
                if (bl)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('公告发布－成功！');</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('公告发布－失败！');</script>");
                }
            }
            else if (message == "2")//修改公告
            {
                objNotice.ID = id;
                bl = notce.UpdateNoticeByID(objNotice);
                notce.SelectAllNoticeUpdXml();
                //notce.SelectNoticeUpdXmlByID(objNotice);
                notce.CreateNoticeHtml(objNotice);
                if (bl)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('公告修改－成功！');</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('公告修改－失败！');</script>");
                }
            }
        }

        protected void imgBtnClear_Click(object sender, ImageClickEventArgs e)
        {
            txtTitle.Text = "";
            FreeTextBox1.Text = "";
        }

        protected void TextBoxInit()
        {

            switch (message)
            {
                case "1":   //发布公告
                    {
                        LabelNotice.Text = "发布公告";
                        break;
                    }
                case "2":  //修改公告
                    {
                        LabelNotice.Text = "修改公告";
                        objNotice.ID = id;
                        DataTable dt = notce.SelectNoticeByID(objNotice);
                        if (dt.Columns.Count > 0)
                        {
                            foreach (DataRow rs in dt.Rows)
                            {
                                txtTitle.Text = rs["noticeTitle"].ToString();
                                FreeTextBox1.Text = "    " + rs["noticeContent"].ToString();
                            }
                        }
                        else
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('无此记录！');</script>");
                        }
                        break;
                    }
            }
        }
    }
}
