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
    public partial class BaseNoticeList : System.Web.UI.Page
    {
        notice notce = new notice();
        MNotice objNotice = new MNotice();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            DataTable dtNotice = notce.SelectAllNotice();
            DataList1.DataKeyField = "noticeID";
            myPagenavigate1.Pager_Size = 4;//设定DataList控件每页要显示的数据条数
            myPagenavigate1.myDataGrid = DataList1;//指定义要实现分页功能的DataList
            myPagenavigate1.myDataTable = dtNotice;//指定DataList数据源

            //if (Convert.ToBoolean(Session["IsSysManager"]) == false)
            //{
            //    //for (int i = 0; i < DataList1.Items.Count; i++)
            //    //{
            //    //    ((ImageButton)DataList1.Items[i].FindControl("ImageButton1")).Visible = false;
            //    //    ((ImageButton)DataList1.Items[i].FindControl("ImageButton2")).Visible = false;
            //    //}

            //    foreach (DataListItem item in this.DataList1.Items)
            //    {
            //        //Panel p = item.FindControl("Panel") as Panel;
            //        ((ImageButton)item.FindControl("ImageButton1")).Visible = false;
            //        ((ImageButton)item.FindControl("ImageButton2")).Visible = false;
            //    }
            //}

        }
        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            objNotice.ID = (int)DataList1.DataKeys[e.Item.ItemIndex];
            DataTable dt = notce.SelectNoticeByID(objNotice);
            objNotice.NoticeHtmlName = dt.Rows[0]["noticeHtmlName"].ToString();
            bool bl = notce.DeleteNoticeByID(objNotice);
            notce.SelectAllNoticeUpdXml();
            notce.DeleteNoticeHtml(objNotice);
            if (bl)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
            }
            else 
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            }

            Response.Redirect("BaseNoticeList.aspx");
            //DataList1.DataSource = notce.SelectAllNotice();
            //DataList1.DataKeyField = "noticeID";
            //DataList1.DataBind();
        }

        protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
        {
            int id = (int)DataList1.DataKeys[e.Item.ItemIndex];
            Response.Redirect("~/BaseInfo/BaseNoticeIssuance.aspx?mess=2&id="+id+"");
        }

        protected string MyContent(string input)
        {
            if (input.Length > 100)
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
