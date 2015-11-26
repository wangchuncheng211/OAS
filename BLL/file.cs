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
    public class file
    {
        private static readonly Ifile files = DataAccess.Createfile();

        public DataTable SelectAllFilesByExamine(MFile objfiles)
        {
            return files.SelectAllFilesByExamine(objfiles);
        }

        public DataTable SelectAllFilesByExamineAndAccepter(MFile objfiles)
        {
            return files.SelectAllFilesByExamineAndAccepter(objfiles);
        }

        public void UpdateFileExaminByFileID(MFile objfiles)
        {
            files.UpdateFileExaminByFileID(objfiles);
        }

        public DataTable SelectAllFilesByAccepter(MFile objfiles) 
        {
            return files.SelectAllFilesByAccepter(objfiles);
        }

        public DataTable SelectAllFiles()
        {
            return files.SelectAllFiles();
        }

        public DataTable SelectFilesByFileID(MFile objfiles)
        {
            return files.SelectFilesByFileID(objfiles);
        }

        public void DeleteFileByFileID(MFile objfiles)
        {
            files.DeleteFileByFileID(objfiles);
        }

        public bool InsertIntoFile(MFile objfiles)
        {
            return files.InsertIntoFile(objfiles);
        }

        /// <summary>
        /// 获取全部已接收文件信息自动生成或更新XML文件
        /// </summary>
        public void SelectReceivedFilesUpdXml()
        {
            DataTable dt = new DataTable();
            dt.TableName = "File";
            MFile objfiles = new MFile();
            objfiles.Examine = "已接收";
            dt = files.SelectAllFilesByExamine(objfiles);
            //实例化一个FileStream对象
            FileStream objFs = new FileStream(HttpContext.Current.Server.MapPath("~/Xml/FileInfoXml/ReceivedFileInfo.xml"),
                FileMode.Create, FileAccess.Write);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            //将获取后的数据自动生成或更新xml文件
            ds.WriteXml(objFs);
            //关闭新建对象
            objFs.Close();
        }
        /// <summary>
        /// 获取全部未接收文件信息自动生成或更新XML文件
        /// </summary>
        public void SelectNotReceivedFilesUpdXml()
        {
            DataTable dt = new DataTable();
            dt.TableName = "File";
            MFile objfiles = new MFile();
            objfiles.Examine = "未接收";
            dt = files.SelectAllFilesByExamine(objfiles);
            //实例化一个FileStream对象
            FileStream objFs = new FileStream(HttpContext.Current.Server.MapPath("~/Xml/FileInfoXml/NotReceivedFileInfo.xml"),
                FileMode.Create, FileAccess.Write);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            //将获取后的数据自动生成或更新xml文件
            ds.WriteXml(objFs);
            //关闭新建对象
            objFs.Close();
        }
    }
}
