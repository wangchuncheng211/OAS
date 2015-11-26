using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.DBUtility;
using System.Data;
using System.Data.OleDb;

namespace OAS.OleDbDAL
{
    public class file : OAS.IDAL.Ifile
    {
        public DataTable SelectAllFilesByExamine(MFile objfiles)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where examine=@Examine order by fileTime desc");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@Examine",OleDbType.VarWChar,10,"examine",objfiles.Examine)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public DataTable SelectAllFilesByExamineAndAccepter(MFile objfiles)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where examine=@Examine and fileAccepter=@FileAccepter order by fileTime desc");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@Examine",OleDbType.VarWChar,10,"examine",objfiles.Examine),
                                       OleDbHelper.GetParameter("@FileAccepter",OleDbType.VarWChar,20,"fileAccepter",objfiles.FileAccepter)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void UpdateFileExaminByFileID(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE tb_file SET examine=@Examine WHERE fileID=@FileID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@Examine",OleDbType.VarWChar,10,"examine",objfiles.Examine),
                                       OleDbHelper.GetParameter("@FileID",OleDbType.Integer,4,"fileID",objfiles.ID)
                                   };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public DataTable SelectAllFilesByAccepter(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where fileAccepter=@FileAccepter order by fileTime desc");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@FileAccepter",OleDbType.VarWChar,20,"fileAccepter",objfiles.FileAccepter)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public DataTable SelectAllFiles()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file order by fileTime desc");
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString());
            return dt;
        }

        public DataTable SelectFilesByFileID(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tb_file where fileID=@FileID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@FileID",OleDbType.Integer,4,"fileID",objfiles.ID)
                                   };
            DataTable dt = OleDbHelper.ExecuteDt(sb.ToString(), param);
            return dt;
        }

        public void DeleteFileByFileID(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete  from tb_file where fileID=@FileID");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@FileID",OleDbType.Integer,4,"fileID",objfiles.ID)
                                   };
            OleDbHelper.ExecuteSql(sb.ToString(), param);
        }

        public bool InsertIntoFile(MFile objfiles)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO tb_file (fileSender, fileAccepter, fileTitle, fileTime, fileContent, path, examine, fileName) VALUES(@FileSender,@FileAccepter,@FileTitle,@FileTime,@FileContent,@FilePath,@FileExamine,@FileName)");
            OleDbParameter[] param = {
                                       OleDbHelper.GetParameter("@FileSender",OleDbType.VarWChar,20,"fileSender",objfiles.FileSender),
                                       OleDbHelper.GetParameter("@FileAccepter",OleDbType.VarWChar,20,"fileAccepter",objfiles.FileAccepter),
                                       OleDbHelper.GetParameter("@FileTitle",OleDbType.VarWChar,50,"fileTitle",objfiles.FileTitle),
                                       OleDbHelper.GetParameter("@FileTime",OleDbType.Date,"fileTime",objfiles.FileTime),
                                       OleDbHelper.GetParameter("@FileContent",OleDbType.LongVarWChar,"fileContent",objfiles.FileContent),
                                       OleDbHelper.GetParameter("@FilePath",OleDbType.VarWChar,100,"path",objfiles.Path),
                                       OleDbHelper.GetParameter("@FileExamine",OleDbType.VarWChar,10,"examine",objfiles.Examine),
                                       OleDbHelper.GetParameter("@FileName",OleDbType.VarWChar,50,"fileName",objfiles.FileName)
                                   };
            bool is_succeed = OleDbHelper.ExecuteSql(sb.ToString(), param);
            if (is_succeed)
                return true;
            else
                return false;
        }
    }
}
