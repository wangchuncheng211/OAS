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

namespace WebAppOAS.BaseInfo
{
    public partial class BaseEmployeeAdd : System.Web.UI.Page
    {

        static bool IsUploadPhoto = false;
        static string path;   //必须设置静态变量　　才可以保存存储　上传　文件路径
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
                //imgBtnSave.Attributes.Add("onclick", "GetArea()");
                department dept = new department();
                dlDepartment.DataSource = dept.SelectAllDepartment();
                dlDepartment.DataBind();
                //Page.ClientScript.RegisterArrayDeclaration("IDArray", string.Format("'{0}'", HiddenField1.ClientID));
            }
        }
        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            bool filesValid = false;
            //如果确认了上传文件，则判断文件类型是否符合要求
            if (this.FileUpload1.HasFile)
            {
                //获取上传文件的后缀
                String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower().Trim();
                String[] restrictExtension = { ".gif", ".jpg", ".bmp", ".png" };

                //判断文件类型是否符合要求
                for (int i = 0; i < restrictExtension.Length; i++)
                {
                    if (fileExtension == restrictExtension[i])
                    { filesValid = true; }
                }
                //如果文件类型符合要求，调用SaveAs方法实现上传，并显示相关信息
                if (filesValid == true)
                {
                    try
                    {
                        path = "~/photo/" + FileUpload1.FileName;
                        this.Image1.ImageUrl = path;
                        string s = Server.MapPath("~/photo/") + FileUpload1.FileName;
                        if (File.Exists(s))
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该文件已经存在，请重新命名！！！');</script>");
                            return;
                        }
                        this.FileUpload1.SaveAs(s);
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件上传成功!');</script>");
                        IsUploadPhoto = true;
                    }
                    catch
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('文件上传失败!');</script>");
                    }
                    finally
                    { }
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只能够上传后缀为.gif,.jpg,.bmp,.png的文件!');</script>");
                }
            }
        }
        protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
        {
            string area = Hidden1.Value;
            employee emp = new employee();
            MEmployee objemp = new MEmployee();
            objemp.Name = txtName.Text.Trim().ToString();
            objemp.Sex = dlSex.Text.ToString();
            objemp.Birthday = Convert.ToDateTime(txtBirthday.Text.Trim());
            objemp.LearnDegree = txtLearn.Text.Trim().ToString();
            objemp.Post = txtPost.Text.Trim().ToString();
            objemp.Dept = dlDepartment.Text.ToString();
            objemp.Job = dlJob.Text.ToString();
            objemp.Tel = txtTel.Text.Trim().ToString();
            objemp.Address = area + " " + txtAddress.Text.Trim().ToString();
            objemp.Email = txtEmail.Text.Trim().ToString();
            objemp.State = dlState.Text.ToString();
            objemp.PhotoPath = path;

            bool bl = emp.InsertIntoEmployee(objemp);
            if (bl)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('员工基础信息添加成功!');</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('员工基础信息添加失败!');</script>");
                if (IsUploadPhoto)
                {
                    try
                    {
                        FileInfo file = new FileInfo(Server.MapPath(path));
                        file.Delete();
                    }
                    catch { }
                    finally { }
                }
            }
        }
        protected void imgBtnClear_Click(object sender, ImageClickEventArgs e)
        {
            txtName.Text = "";
            txtBirthday.Text = "";
            txtAddress.Text = "";
            txtLearn.Text = "";
            txtPost.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";

            try
            {
                FileInfo file = new FileInfo(Server.MapPath(path));
                file.Delete();
            }
            catch { }
            finally { }

        }
    }
}
