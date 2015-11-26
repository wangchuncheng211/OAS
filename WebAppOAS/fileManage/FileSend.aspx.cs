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

namespace WebAppOAS.fileManage
{
    public partial class FileSend : System.Web.UI.Page
    {
        employee emp = new employee();
        MEmployee objemp = new MEmployee();
        file files = new file();
        MFile objfiles = new MFile();
        static string path;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginName"] == null)   //判断是否非法登录
            {
                //如果非法登录，直接跳转到主页。
                //Response.Write("<script>this.parent.location.href='../Default.aspx'</script>");
                Response.Redirect("~/Default.aspx");
                return;
            }
            if (!IsPostBack)
            {
                //绑定文件接收人，均为企业员工
                ddlName.DataSource = emp.SelectAllEmployee(); ;
                ddlName.DataTextField = "name";
                ddlName.DataValueField = "name";
                ddlName.DataBind();
            }
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            //获取上传文件的路径
            string str = this.FileUpload1.PostedFile.FileName;
            //判断附件不能为空！
            if (str == string.Empty)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('上传文件不能为空!');</script>");
                return;
            }
            //获取附件名称 
            string fileName = str.Substring(str.LastIndexOf("\\") + 1);
            path = "~/file/" + fileName;                            //设置附件上传到的服务器路径
            long fileSize = (FileUpload1.PostedFile.ContentLength / 1024) / 1024;   //获取文件大小 B/1024 KB/1024 MB
            if (fileSize > 10)                                      //控制文件大小不能超过10M
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件大小不能超过10M!');</script>");
                //Response.Write(bc.MessageBox("文件大小不能超过10M ！"));
                return;                                             //不能继续执行
            }
            //上传送文件的相关信息保存到服务器中
            objfiles.FileSender = Convert.ToString(Session["loginName"]);
            objfiles.FileAccepter = ddlName.Text.ToString();
            objfiles.FileTitle = txtTitle.Text.ToString();
            objfiles.FileTime = DateTime.Now;
            objfiles.FileContent = "  " + txtContent.Text.ToString();
            objfiles.Path = path;
            objfiles.Examine = "未接收";
            objfiles.FileName = fileName;
            bool bl = files.InsertIntoFile(objfiles);
            if (bl)
            {
                files.SelectReceivedFilesUpdXml();
                files.SelectNotReceivedFilesUpdXml();
                this.FileUpload1.PostedFile.SaveAs(Server.MapPath(path));         //将文件保存到服务器上
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件传送成功!');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('网络故障，文件传送失败!');</script>");
                return;
            }
            //this.FileUpload1.PostedFile.SaveAs(Server.MapPath(path));         //将文件保存到服务器上
        }
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            txtContent.Text = "";
        }
    }
}
