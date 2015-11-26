using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MSignState
    {
        private int id;
        /// <summary>
        /// 签到或签退状态id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string signstate_describe;
        /// <summary>
        /// 签到状态?还是签退状态？
        /// </summary>
        public string Signstate_describe
        {
            get { return signstate_describe; }
            set { signstate_describe = value; }
        }

        private DateTime time;
        /// <summary>
        /// 规定的签到时间或规定的签退时间
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
