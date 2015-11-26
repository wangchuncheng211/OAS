using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface Inotice
    {
        bool InsertIntoNotice(MNotice objNotice);
        DataTable SelectAllNotice();
        bool DeleteNoticeByID(MNotice objNotice);
        bool UpdateNoticeByID(MNotice objNotice);
        DataTable SelectNoticeByID(MNotice objNotice);
    }
}
