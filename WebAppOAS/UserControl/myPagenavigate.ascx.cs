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

namespace WebAppOAS.UserControl
{
    public partial class myPagenavigate : System.Web.UI.UserControl
    {
        private System.Web.UI.WebControls.DataList mydataGrid;
        protected System.Web.UI.WebControls.LinkButton LinkButton1;
        private DataSet mydataSet;
        private DataTable mydataTable;
        protected static PagedDataSource pds = new PagedDataSource();//创建一个分页数据源的对象且一定要声明为静态
        private int pager_size;
        #region --定义实现分页功能的属性
        public DataList myDataGrid//定义DataList类型的控件
        {
            get//可读属性
            {
                return mydataGrid;
            }
            set
            {//可写属性
                mydataGrid = value;
            }
        }
        public DataSet myDataSet//定义数据集对象
        {
            get
            {
                return mydataSet;
            }
            set
            {
                mydataSet = value;
            }
        }
        public DataTable myDataTable//定义数据集对象
        {
            get
            {
                return mydataTable;
            }
            set
            {
                mydataTable = value;
            }
        }
        public int Pager_Size//定义DataList控件的每页显示的数据条数
        {
            get
            {
                return pager_size;
            }
            set
            {
                pager_size = value;
            }
        }
        #endregion
        #region --显示页数
        private void BindDataList(int currentpage)
        {
            pds.AllowPaging = true;
            pds.PageSize = pager_size;
            pds.CurrentPageIndex = currentpage;
            //pds.DataSource = mydataSet.Tables[0].DefaultView;
            pds.DataSource = mydataTable.DefaultView;
            mydataGrid.DataSource = pds;
            mydataGrid.DataBind();
            if (Convert.ToBoolean(Session["IsSysManager"]) == false)
            {
                //for (int i = 0; i < mydataGrid.Items.Count; i++)
                //{
                //    ((ImageButton)mydataGrid.Items[i].FindControl("ImageButton1")).Visible = false;
                //    ((ImageButton)mydataGrid.Items[i].FindControl("ImageButton2")).Visible = false;
                //}
                foreach (DataListItem item in this.mydataGrid.Items)
                {
                    //Panel p = item.FindControl("Panel") as Panel;
                    ((ImageButton)item.FindControl("ImageButton1")).Visible = false;
                    ((ImageButton)item.FindControl("ImageButton2")).Visible = false;
                }
            }
            this.lnkbtnFirst.Enabled = true;
            this.lnkbtnFront.Enabled = true;
            this.lnkbtnNext.Enabled = true;
            this.lnkbtnLast.Enabled = true;
            if (currentpage == 0)
            {
                this.lnkbtnFirst.Enabled = false;
                this.lnkbtnFront.Enabled = false;
            }
            if (currentpage == pds.PageCount - 1)
            {
                this.lnkbtnNext.Enabled = false;
                this.lnkbtnLast.Enabled = false;
            }
            labCurrentPage.Text = "当前页数：" + (pds.CurrentPageIndex + 1).ToString();
            labPageCount.Text = "总页数（" + pds.PageCount.ToString() + "）";
        }
        #endregion

        protected void Pager_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                //以下5个为 捕获用户点击 上一页 下一页等时发生的事件
                case "first"://第一页
                    pds.CurrentPageIndex = 0;
                    BindDataList(pds.CurrentPageIndex);
                    break;
                case "pre"://上一页
                    pds.CurrentPageIndex = pds.CurrentPageIndex - 1;
                    BindDataList(pds.CurrentPageIndex);
                    break;
                case "next"://下一页
                    pds.CurrentPageIndex = pds.CurrentPageIndex + 1;
                    BindDataList(pds.CurrentPageIndex);
                    break;
                case "last"://最后一页
                    pds.CurrentPageIndex = pds.PageCount - 1;
                    BindDataList(pds.CurrentPageIndex);
                    break;
                case "search"://页面跳转页
                    int PageCount = int.Parse(pds.PageCount.ToString());
                    int MyPageNum = 0;
                    if (!txtPage.Text.Equals(""))
                        MyPageNum = Convert.ToInt32(txtPage.Text.Trim().ToString());
                    if (MyPageNum <= 0 || MyPageNum > PageCount)
                        Page.ClientScript.RegisterStartupScript(this.GetType(),"","<script>alert('请输入页数并确定没有超出总页数！')</script>");
                        //Response.Write("<script>alert('请输入页数并确定没有超出总页数！')</script>");
                    else
                        BindDataList(MyPageNum - 1);
                    break;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataList(0);
            }
        }
    }
}