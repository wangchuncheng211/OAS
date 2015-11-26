using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OAS.MODEL;
using OAS.IDAL;
using OAS.DALFactory;
using System.Data;

namespace OAS.BLL
{
    public class signState
    {
        private static readonly IsignState signstate = DataAccess.CreatesignState();

        public bool InsertIntoSignState(MSignState objsignstate)
        {
            return signstate.InsertIntoSignState(objsignstate);
        }

        public bool UpdateSignStateByID(MSignState objsignstate)
        {
            return signstate.UpdateSignStateByID(objsignstate);
        }

        public DataTable SelectAllSignState()
        {
            return signstate.SelectAllSignState();
        }
    }
}
