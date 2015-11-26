using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Reflection;

namespace OAS.DALFactory
{
    public class DataAccess
    {
        //以下是连接Access数据库的命名空间路径
        private static readonly string path = ConfigurationSettings.AppSettings["OleDbDAL"];
        //以下是连接SQLserver数据库的命名空间路径
        //private static readonly string path = ConfigurationSettings.AppSettings["SQLDAL"];

        public static OAS.IDAL.IsysUser CreatesysUser()
        {
            string className = path + ".sysUser";
            return (OAS.IDAL.IsysUser)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Iemployee Createemployee()
        {
            string className = path + ".employee";
            return (OAS.IDAL.Iemployee)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Irule Createrule()
        {
            string className = path + ".rule";
            return (OAS.IDAL.Irule)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Ifile Createfile()
        {
            string className = path + ".file";
            return (OAS.IDAL.Ifile)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Ivote Createvote()
        {
            string className = path + ".vote";
            return (OAS.IDAL.Ivote)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.IsignState CreatesignState()
        {
            string className = path + ".signState";
            return (OAS.IDAL.IsignState)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Isign Createsign()
        {
            string className = path + ".sign";
            return (OAS.IDAL.Isign)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Idepartment Createdepartment()
        {
            string className = path + ".department";
            return (OAS.IDAL.Idepartment)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Inotice Createnotice()
        {
            string className = path + ".notice";
            return (OAS.IDAL.Inotice)Assembly.Load(path).CreateInstance(className);
        }

        public static OAS.IDAL.Inote Createnote()
        {
            string className = path + ".note";
            return (OAS.IDAL.Inote)Assembly.Load(path).CreateInstance(className);
        }
    }
}
