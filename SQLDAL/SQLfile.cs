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
    public class file : OAS.IDAL.Ifile
    {
        public DataTable SelectAllFilesByExamine(MFile objfiles)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where examine=@Examine order by fileTime desc");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@Examine",SqlDbType.VarChar,10,"examine",objfiles.Examine)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(),param);
            return dt;
        }

        public DataTable SelectAllFilesByExamineAndAccepter(MFile objfiles)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where examine=@Examine and fileAccepter=@FileAccepter order by fileTime desc");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@Examine",SqlDbType.VarChar,10,"examine",objfiles.Examine),
                                       SQLDbHelper.GetParameter("@FileAccepter",SqlDbType.VarChar,20,"fileAccepter",objfiles.FileAccepter)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void UpdateFileExaminByFileID(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE tb_file SET examine = @Examine WHERE fileID =@FileID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@Examine",SqlDbType.VarChar,10,"examine",objfiles.Examine),
                                       SQLDbHelper.GetParameter("@FileID",SqlDbType.Int,4,"fileID",objfiles.ID)
                                   };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectAllFilesByAccepter(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where fileAccepter=@FileAccepter order by fileTime desc");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@FileAccepter",SqlDbType.VarChar,20,"fileAccepter",objfiles.FileAccepter)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public DataTable SelectAllFiles()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file order by fileTime desc");
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public DataTable SelectFilesByFileID(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where fileID=@FileID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@FileID",SqlDbType.Int,4,"fileID",objfiles.ID)
                                   };
            DataTable dt = SQLDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void DeleteFileByFileID(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete  from tb_file where fileID=@FileID");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@FileID",SqlDbType.Int,4,"fileID",objfiles.ID)
                                   };
            SQLDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public bool InsertIntoFile(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_file (fileSender, fileAccepter, fileTitle, fileTime, fileContent, path, examine, fileName) VALUES(@FileSender,@FileAccepter,@FileTitle,@FileTime,@FileContent,@FilePath,@FileExamine,@FileName)");
            SqlParameter[] param = {
                                       SQLDbHelper.GetParameter("@FileSender",SqlDbType.VarChar,20,"fileSender",objfiles.FileSender),
                                       SQLDbHelper.GetParameter("@FileAccepter",SqlDbType.VarChar,20,"fileAccepter",objfiles.FileAccepter),
                                       SQLDbHelper.GetParameter("@FileTitle",SqlDbType.VarChar,50,"fileTitle",objfiles.FileTitle),
                                       SQLDbHelper.GetParameter("@FileTime",SqlDbType.DateTime,"fileTime",objfiles.FileTime),
                                       SQLDbHelper.GetParameter("@FileContent",SqlDbType.Text,"fileContent",objfiles.FileContent),
                                       SQLDbHelper.GetParameter("@FilePath",SqlDbType.VarChar,100,"path",objfiles.Path),
                                       SQLDbHelper.GetParameter("@FileExamine",SqlDbType.VarChar,10,"examine",objfiles.Examine),
                                       SQLDbHelper.GetParameter("@FileName",SqlDbType.VarChar,50,"fileName",objfiles.FileName)
                                   };
            bool is_succeed = SQLDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }
    }
}
