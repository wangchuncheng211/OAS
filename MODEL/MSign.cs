using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MSign
    {
        private int id;
        /// <summary>
        /// 签到或签退id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime datetime;
        /// <summary>
        /// 签到或签退时间
        /// </summary>
        public DateTime Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }

        private string employeeName;
        /// <summary>
        /// 签到或签退人
        /// </summary>
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        private bool late;
        /// <summary>
        /// 迟到？
        /// </summary>
        public bool Late
        {
            get { return late; }
            set { late = value; }
        }

        private bool quit;
        /// <summary>
        /// 早退？
        /// </summary>
        public bool Quit
        {
            get { return quit; }
            set { quit = value; }
        }
    }
}
