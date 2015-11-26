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

//需要用到的命名空间
using System.Net;
using System.IO;
using System.Text;
using OAS.MODEL;
using OAS.BLL;

namespace WebAppOAS.MobileInfo
{
    public partial class InfoSend : System.Web.UI.Page
    {
        private string url = "http://utf8.sms.webchinese.cn/?";
        private string strUid = "Uid=wangchuncheng";
        private string strKey = "&key=193c9bbd00171fd49cd4"; //这里代表秘钥
        private string strMob = "&smsMob=";
        private string strContent = "&smsText=";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                employee emp = new employee();
                chkblEmployee.DataSource = emp.SelectAllEmployee();;
                chkblEmployee.DataTextField = "name";
                chkblEmployee.DataValueField = "tel";
                chkblEmployee.DataBind();
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            txtAccepter.Text = "";                                      //清空手机号码
            for (int i = 0; i < chkblEmployee.Items.Count; i++)
            {
                if (chkblEmployee.Items[i].Selected)
                    txtAccepter.Text = chkblEmployee.Items[i].Value + "," + txtAccepter.Text;
            }
            if (txtAccepter.Text.Length != 0)
                txtAccepter.Text = txtAccepter.Text.Substring(0, txtAccepter.Text.Length - 1);
        }
        protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
        {
            //如果没有手机号码接收信息，则程序不继续执行。
            if (txtAccepter.Text == "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('手机号码不能为空!');</script>");
                //Response.Write(bc.MessageBox("手机号码不能为空！"));
                return;
            }

            if (txtAccepter.Text.ToString().Trim() != "" && txtInfo.Text.ToString() != null)
            {
                url += strUid + strKey + strMob + txtAccepter.Text + strContent + txtInfo.Text;
                
                try 
                {
                    string Result = GetHtmlFromUrl(url);
                    if (Convert.ToInt32(Result) > 0)
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('短信发送成功，数量：" + Result + "');</script>");
                        //Response.Write(bc.MessageBox("短信发送成功，数量：" + Result)); 
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('短信发送失败!');</script>");
                        //Response.Write(bc.MessageBox("短信发送失败！")); 
                    }
                }
                catch
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('短信发送失败!');</script>");
                }
                finally{}

            }
        }
        protected void imgBtnClear_Click(object sender, ImageClickEventArgs e)
        {
            txtAccepter.Text = "";
            txtInfo.Text = "";
        }

        //调用时只需要把拼成的URL传给该函数即可。判断返回值即可
        public string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch
            {
                strRet = null;
            }
            finally { }
            return strRet;
        }
    }
}
