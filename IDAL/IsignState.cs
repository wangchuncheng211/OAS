using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAS.MODEL;
using System.Data;

namespace OAS.IDAL
{
    public interface IsignState
    {
        bool InsertIntoSignState(MSignState objsignstate);
        bool UpdateSignStateByID(MSignState objsignstate);
        DataTable SelectAllSignState();
    }
}
