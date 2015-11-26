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

//using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace WebAppOAS.fileManage
{
    public partial class FileAccept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)　//用户非法登录，跳转的系统主页。
            {
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            Ajax.Utility.RegisterTypeForAjax(typeof(WebAppOAS.fileManage.FileAccept));
        }

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public void UpdateFileExaminByFileID(int fileid)
        {
            MFile objfiles = new MFile();
            objfiles.ID = fileid;
            objfiles.Examine = "已接收";
            file files = new file();
            files.UpdateFileExaminByFileID(objfiles);

            //files.SelectAllFilesInfoUpdXml();

            //将NotReceivedFileInfo.xml的fileID节点examine状态改变为"已接收"，插入到ReceivedFileInfo.xml
            //然后将将NotReceivedFileInfo.xml的该节点删除
            XmlDocument xmlDocNotRec = new XmlDocument();
            xmlDocNotRec.Load(Server.MapPath("~/Xml/FileInfoXml/NotReceivedFileInfo.xml"));
            XmlNode node1 = xmlDocNotRec.SelectSingleNode("/NewDataSet/Table1[fileID/text()='" + fileid + "']");
            node1.ChildNodes[7].InnerText = "已接收";

            string strfileID = node1.ChildNodes[0].InnerText;
            string strfileSender = node1.ChildNodes[1].InnerText;
            string strfileAccepter = node1.ChildNodes[2].InnerText;
            string strfileTitle = node1.ChildNodes[3].InnerText;
            string strfileTime = node1.ChildNodes[4].InnerText;
            string strfileContent = node1.ChildNodes[5].InnerText;
            string strpath = node1.ChildNodes[6].InnerText;
            string strexamine = node1.ChildNodes[7].InnerText;
            string strfileName = node1.ChildNodes[8].InnerText;

            node1.ParentNode.RemoveChild(node1);
            xmlDocNotRec.Save(Server.MapPath("~/Xml/FileInfoXml/NotReceivedFileInfo.xml"));

  //<Table1>
  //  <fileID>5</fileID>
  //  <fileSender>王春城</fileSender>
  //  <fileAccepter>王春城</fileAccepter>
  //  <fileTitle>项目总结</fileTitle>
  //  <fileTime>2015-06-16T00:00:00+08:00</fileTime>
  //  <fileContent>项目总结项目总结</fileContent>
  //  <path>~/file/项目总结.doc</path>
  //  <examine>已接收</examine>
  //  <fileName>项目总结.doc</fileName>
  //</Table1>
            XmlDocument xmlDocRec = new XmlDocument();
            xmlDocRec.Load(Server.MapPath("~/Xml/FileInfoXml/ReceivedFileInfo.xml"));
            XmlNode node2 = xmlDocRec.SelectSingleNode("/NewDataSet");
            XmlElement Table1 = xmlDocRec.CreateElement("Table1");
            XmlElement fileID = xmlDocRec.CreateElement("fileID");
            fileID.InnerText = strfileID;
            XmlElement fileSender = xmlDocRec.CreateElement("fileSender");
            fileSender.InnerText = strfileSender;
            XmlElement fileAccepter = xmlDocRec.CreateElement("fileAccepter");
            fileAccepter.InnerText = strfileAccepter;
            XmlElement fileTitle = xmlDocRec.CreateElement("fileTitle");
            fileTitle.InnerText = strfileTitle;
            XmlElement fileTime = xmlDocRec.CreateElement("fileTime");
            fileTime.InnerText = strfileTime;
            XmlElement fileContent = xmlDocRec.CreateElement("fileContent");
            fileContent.InnerText = strfileContent;
            XmlElement path = xmlDocRec.CreateElement("path");
            path.InnerText = strpath;
            XmlElement examine = xmlDocRec.CreateElement("examine");
            examine.InnerText = strexamine;
            XmlElement fileName = xmlDocRec.CreateElement("fileName");
            fileName.InnerText = strfileName;
            Table1.AppendChild(fileID);
            Table1.AppendChild(fileSender);
            Table1.AppendChild(fileAccepter);
            Table1.AppendChild(fileTitle);
            Table1.AppendChild(fileTime);
            Table1.AppendChild(fileContent);
            Table1.AppendChild(path);
            Table1.AppendChild(examine);
            Table1.AppendChild(fileName);
            node2.InsertBefore(Table1,node2.FirstChild);
            //node2.AppendChild(Table1);
            xmlDocRec.Save(Server.MapPath("~/Xml/FileInfoXml/ReceivedFileInfo.xml"));
            //xmlDocRec.DocumentElement.AppendChild(node);
        }
    }
}
