using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace OAS.SQLDAL
{
    public class notice : OAS.IDAL.Inotice
    {
        public bool InsertIntoNotice(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into tb_notice (noticeTitle,noticeTime,noticePerson,noticeContent,noticeHtmlName) values(@Title,@Datetime,@NoticePerson,@NoticeContent,@NoticeHtmlName)");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@Title",SqlDbType.VarChar,40,"noticeTitle",objNotice.NoticeTitle),
                                       SQLDbHelper.GetParameter("@Datetime",SqlDbType.DateTime,"noticeTime",objNotice.NoticeTime),
                                       SQLDbHelper.GetParameter("@NoticePerson",SqlDbType.VarChar,20,"noticePerson",objNotice.NoticePerson),
                                       SQLDbHelper.GetParameter("@NoticeContent",SqlDbType.Text,"noticeContent",objNotice.NoticeContent),
                                       SQLDbHelper.GetParameter("@NoticeHtmlName",SqlDbType.VarChar,50,"noticeHtmlName",objNotice.NoticeHtmlName)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectAllNotice()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM tb_notice ORDER BY noticeTime DESC");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public bool DeleteNoticeByID(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from tb_notice where noticeID=@ID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"noticeID",objNotice.ID)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateNoticeByID(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update tb_notice set noticeTitle=@Title,noticePerson=@NoticePerson,noticeContent=@NoticeContent where noticeID=@ID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@Title",SqlDbType.VarChar,40,"noticeTitle",objNotice.NoticeTitle),
                                       SQLDbHelper.GetParameter("@NoticePerson",SqlDbType.VarChar,20,"noticePerson",objNotice.NoticePerson),
                                       SQLDbHelper.GetParameter("@NoticeContent",SqlDbType.Text,"noticeContent",objNotice.NoticeContent),
                                       SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"noticeID",objNotice.ID)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectNoticeByID(MNotice objNotice)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_notice where noticeID=@ID");
            SqlParameter[] param = {
                                        SQLDbHelper.GetParameter("@ID",SqlDbType.Int,4,"noticeID",objNotice.ID)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(),param);
            return dt;
        }
    }
}
