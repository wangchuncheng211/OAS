using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAS.MODEL
{
    public class MEmployee
    {
        private int id;
        /// <summary>
        /// 职员id
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// 职员名字
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string sex;
        /// <summary>
        /// 职员性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private DateTime birthday;
        /// <summary>
        /// 职员出生日期
        /// </summary>
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private string learnDegree;
        /// <summary>
        /// 职员学历
        /// </summary>
        public string LearnDegree
        {
            get { return learnDegree; }
            set { learnDegree = value; }
        }

        private string post;
        /// <summary>
        /// 职员职称
        /// </summary>
        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        private string dept;
        /// <summary>
        /// 职员所属部门
        /// </summary>
        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        private string job;
        /// <summary>
        /// 职员职位
        /// </summary>
        public string Job
        {
            get { return job; }
            set { job = value; }
        }

        private string tel;
        /// <summary>
        /// 职员手机号
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        private string address;
        /// <summary>
        /// 职员住址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string email;
        /// <summary>
        /// 职员email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string state;
        /// <summary>
        /// 职员在职状态
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string photoPath;
        /// <summary>
        /// 职员照片路径
        /// </summary>
        public string PhotoPath
        {
            get { return photoPath; }
            set { photoPath = value; }
        }
    }
}
