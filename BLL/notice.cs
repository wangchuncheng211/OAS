using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.IDAL;
using OAS.DALFactory;
using System.Data;
using System.IO;
using System.Web;

namespace OAS.BLL
{
    public class notice
    {
        private static readonly Inotice notce = DataAccess.Createnotice();

        public bool InsertIntoNotice(MNotice objNotice)
        {
            return notce.InsertIntoNotice(objNotice);
        }

        public DataTable SelectAllNotice()
        {
            return notce.SelectAllNotice();
        }

        public bool DeleteNoticeByID(MNotice objNotice)
        {
            return notce.DeleteNoticeByID(objNotice);
        }

        public bool UpdateNoticeByID(MNotice objNotice)
        {
            return notce.UpdateNoticeByID(objNotice);
        }

        public DataTable SelectNoticeByID(MNotice objNotice)
        {
            return notce.SelectNoticeByID(objNotice);
        }

        /// <summary>
        /// 获取全部公告内容自动生成或更新XML文件
        /// </summary>
        public void SelectAllNoticeUpdXml()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Notice";
                dt = notce.SelectAllNotice();
            //实例化一个FileStream对象
            FileStream objFs = new FileStream(HttpContext.Current.Server.MapPath("~/Xml/NoticeXml/Notice.xml"), 
                FileMode.Create, FileAccess.Write);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            //将获取后的数据自动生成或更新xml文件
            ds.WriteXml(objFs);
            //关闭新建对象
            objFs.Close();
        }

        /// <summary>
        /// 获取公告内容自动生成或更新XML文件
        /// </summary>
        //public void SelectNoticeUpdXmlByID(MNotice objNotice)
        //{
        //    //注意：ADO.NET通过DataSet与XML进行交互。
        //    //定义一个数据集对象
        //    DataTable dt = new DataTable();
        //    dt.TableName = "Notice";
        //    //获取数据
        //    dt = notce.SelectNoticeByID(objNotice);
        //    //实例化一个FileStream对象
        //    FileStream objFs = new FileStream(HttpContext.Current.Server.MapPath("~/Xml/NoticeXml/Notice.xml"),
        //        FileMode.OpenOrCreate, FileAccess.Write);
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dt);
        //    //将获取后的数据自动生成或更新xml文件
        //    ds.WriteXml(objFs);
        //    //关闭新建对象
        //    objFs.Close();
        //}

        /// <summary>
        /// 定义生成信息静态页面
        /// </summary>
        public void CreateNoticeHtml(MNotice objNotice)
        {
            //生成静态页面后保存的路径
            string strSavePath = HttpContext.Current.Server.MapPath("~/") + "Html/Notice/";
            //静态页面样板所保存的路径
            string strHtmlPath = HttpContext.Current.Server.MapPath("~/") + "Html/Notice/Model.html";
            //定义样板读取变量并读样板
            StreamReader objSr = new StreamReader(strHtmlPath, System.Text.Encoding.GetEncoding("gb2312"));//"utf-8"
            //文件数据流
            string ObjContent = "";
            //开始读取
            try
            {
                ObjContent = objSr.ReadToEnd();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
                objSr.Close();
            }
            //定义新生成的html文件名
            string strNewHtmlFileName = objNotice.NoticeHtmlName + ".html";
            StreamWriter objSw = new StreamWriter(strSavePath + strNewHtmlFileName, false, System.Text.Encoding.GetEncoding("gb2312"));

            //写入生成的文件
            ObjContent = ObjContent.Replace("T_Title", objNotice.NoticeTitle);
            ObjContent = ObjContent.Replace("N_Title", objNotice.NoticeTitle);
            ObjContent = ObjContent.Replace("N_Time", objNotice.NoticeTime.ToString());
            ObjContent = ObjContent.Replace("N_Author", objNotice.NoticePerson);
            ObjContent = ObjContent.Replace("N_Content", objNotice.NoticeContent);
            try
            {
                objSw.Write(ObjContent);
                objSw.Flush();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                HttpContext.Current.Response.End();
            }
            finally
            {
                objSw.Close();
            }
        }

        public void DeleteNoticeHtml(MNotice objNotice)
        {
            //生成静态页面后保存的路径
            string strSavePath = HttpContext.Current.Server.MapPath("~/") + "Html/Notice/";
            //定义新生成的html文件名
            string strNewHtmlFileName = objNotice.NoticeHtmlName + ".html";
            string Path = strSavePath + strNewHtmlFileName;
            if (File.Exists(@Path))
            {
                File.Delete(@Path);
            }

        }
    }
}
