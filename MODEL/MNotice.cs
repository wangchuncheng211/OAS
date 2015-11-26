using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MNotice
    {
        private int id;
        /// <summary>
        /// 公告id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string noticeTitle;
        /// <summary>
        /// 公告标题
        /// </summary>
        public string NoticeTitle
        {
            get { return noticeTitle; }
            set { noticeTitle = value; }
        }

        private DateTime noticeTime;
        /// <summary>
        /// 公告时间
        /// </summary>
        public DateTime NoticeTime
        {
            get { return noticeTime; }
            set { noticeTime = value; }
        }

        private string noticePerson;
        /// <summary>
        /// 公告人
        /// </summary>
        public string NoticePerson
        {
            get { return noticePerson; }
            set { noticePerson = value; }
        }

        private string noticeContent;
        /// <summary>
        /// 公告内容
        /// </summary>
        public string NoticeContent
        {
            get { return noticeContent; }
            set { noticeContent = value; }
        }

        private string noticeHtmlName;
        /// <summary>
        /// 公告Html文件名
        /// </summary>
        public string NoticeHtmlName
        {
            get { return noticeHtmlName; }
            set { noticeHtmlName = value; }
        }
    }
}
