using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface Ifile
    {
        DataTable SelectAllFilesByExamine(MFile objfiles);
        DataTable SelectAllFilesByExamineAndAccepter(MFile objfiles);
        void UpdateFileExaminByFileID(MFile objfiles);
        DataTable SelectAllFilesByAccepter(MFile objfiles);
        DataTable SelectAllFiles();
        DataTable SelectFilesByFileID(MFile objfiles);
        void DeleteFileByFileID(MFile objfiles);
        bool InsertIntoFile(MFile objfiles);
    }
}
