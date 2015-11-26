using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MDepartment
    {
        private int id;
        /// <summary>
        /// 部门id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string duty_description;
        /// <summary>
        /// 部门职责描述
        /// </summary>
        public string Duty_description
        {
            get { return duty_description; }
            set { duty_description = value; }
        }
    }
}
