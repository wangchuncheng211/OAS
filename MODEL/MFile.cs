using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MFile
    {
        private int id;
        /// <summary>
        /// 文件id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string fileSender;
        /// <summary>
        /// 文件发送者
        /// </summary>
        public string FileSender
        {
            get { return fileSender; }
            set { fileSender = value; }
        }

        private string fileAccepter;
        /// <summary>
        /// 文件接收者
        /// </summary>
        public string FileAccepter
        {
            get { return fileAccepter; }
            set { fileAccepter = value; }
        }

        private string fileTitle;
        /// <summary>
        /// 文件标题
        /// </summary>
        public string FileTitle
        {
            get { return fileTitle; }
            set { fileTitle = value; }
        }
        private DateTime fileTime;
        /// <summary>
        /// 文件传送时间
        /// </summary>
        public DateTime FileTime
        {
            get { return fileTime; }
            set { fileTime = value; }
        }

        private string fileContent;
        /// <summary>
        /// 文件内容
        /// </summary>
        public string FileContent
        {
            get { return fileContent; }
            set { fileContent = value; }
        }

        private string path;
        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string examine;
        /// <summary>
        /// 文件接收状态
        /// </summary>
        public string Examine
        {
            get { return examine; }
            set { examine = value; }
        }

        private string fileName;
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
    }
}
