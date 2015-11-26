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

using System.IO;
using OAS.MODEL;
using OAS.BLL;
using System.Xml;
using System.Xml.XPath;

namespace WebAppOAS.fileManage
{
    public partial class FileDelete : System.Web.UI.Page
    {
        sysUser user = new sysUser();
        MSysUser objsysuser = new MSysUser();
        file files = new file();
        MFile objfiles = new MFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                objsysuser.UserName = Session["loginName"].ToString();
                DataTable dt = user.SelectSysUserByUserName(objsysuser);
                //如果系统登录身份为系统管理员，那么显示所有职员的文件列表

                if (Convert.ToBoolean(Session["IsSysManager"]))
                {
                    GridView1.DataSource = files.SelectAllFiles();
                    GridView1.DataKeyNames = new string[] { "fileID" };
                    GridView1.DataBind();
                }
                else
                {
                    objfiles.FileAccepter = Session["loginName"].ToString();
                    GridView1.DataSource = files.SelectAllFilesByAccepter(objfiles);
                    GridView1.DataKeyNames = new string[] { "fileID" };
                    GridView1.DataBind();
                }
            }

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //清除文件（服务器）
            objfiles.ID = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
            DataTable dt = files.SelectFilesByFileID(objfiles);
            DataRow[] row = dt.Select();
            foreach (DataRow rs in row)
            {
                FileInfo file = new FileInfo(Server.MapPath(rs["path"].ToString()));
                file.Delete();
            }
            if ("已接收" == dt.Rows[0]["examine"].ToString())
            {
                XmlDocument xmlDocRec = new XmlDocument();
                xmlDocRec.Load(Server.MapPath("~/Xml/FileInfoXml/ReceivedFileInfo.xml"));
                XmlNode node = xmlDocRec.SelectSingleNode("/NewDataSet/Table1[fileID/text()='" + objfiles.ID + "']");
                node.ParentNode.RemoveChild(node);
                xmlDocRec.Save(Server.MapPath("~/Xml/FileInfoXml/ReceivedFileInfo.xml"));
            }
            else 
            {
                XmlDocument xmlDocNotRec = new XmlDocument();
                xmlDocNotRec.Load(Server.MapPath("~/Xml/FileInfoXml/NotReceivedFileInfo.xml"));
                XmlNode node = xmlDocNotRec.SelectSingleNode("/NewDataSet/Table1[fileID/text()='" + objfiles.ID + "']");
                node.ParentNode.RemoveChild(node);
                xmlDocNotRec.Save(Server.MapPath("~/Xml/FileInfoXml/NotReceivedFileInfo.xml"));
            }
            //清除数据
            //objfiles.ID = Convert.ToInt32(this.GridView1.DataKeys[e.RowIndex].Value);
            files.DeleteFileByFileID(objfiles);


            GridView1.DataSource = files.SelectAllFiles();
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }
    }
}
