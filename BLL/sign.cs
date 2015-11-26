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
    public class sign
    {
        private static readonly Isign signs = DataAccess.Createsign();

        public void InsertIntoSign(MSign objsign)
        {
            signs.InsertIntoSign(objsign);
        }
    }
}
