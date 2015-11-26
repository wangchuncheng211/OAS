using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace OAS.DBUtility
{
    public class OleDbHelper
    {
        public OleDbHelper() { }

        /// <summary>
        /// 返回数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static String GetOleDbConnection()
        {
            String ConnStr = ConfigurationSettings.AppSettings["OleDbConnectionString"].ToString();
            return ConnStr;
        }

        /// <summary>
        ///  获得参数对象 
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="paramSize">长度</param>
        /// <param name="ColName">源列名称</param>
        /// <param name="paramValue">参数实值</param>
        /// <returns></returns>
        public static OleDbParameter GetParameter(String paramName, OleDbType paramType, Int32 paramSize, String ColName, Object paramValue)
        {
            OleDbParameter param = new OleDbParameter(paramName, paramType, paramSize, ColName);
            param.Value = paramValue;
            return param;
        }

        /// <summary>
        /// 获得参数对象
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="paramSize">长度</param>
        /// <param name="ColName">源列名称</param>
        /// <returns></returns>
        public static OleDbParameter GetParameter(String paramName, OleDbType paramType, Int32 paramSize, String ColName)
        {
            OleDbParameter param = new OleDbParameter(paramName, paramType, paramSize, ColName);
            return param;
        }

        /// <summary>
        /// 获得参数对象
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="paramSize">长度</param>
        /// <param name="ColName">源列名称</param>
        /// <param name="paramValue">参数实值</param>
        /// <returns></returns>
        public static OleDbParameter GetParameter(String paramName, OleDbType paramType, Object paramValue)
        {
            OleDbParameter param = new OleDbParameter(paramName, paramType);
            param.Value = paramValue;
            return param;
        }

        /// <summary>
        /// 获得参数对象
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="paramType">数据类型</param>
        /// <param name="ColName">源列名称</param>
        /// <param name="paramValue">参数实值</param>
        /// <returns></returns>
        public static OleDbParameter GetParameter(String paramName, OleDbType paramType, String ColName, Object paramValue)
        {
            OleDbParameter param = new OleDbParameter(paramName, paramType);
            param.Value = paramValue;
            param.SourceColumn = ColName;
            return param;
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象数组</param>
        /// <returns></returns>
        public static Boolean ExecuteSql(String Sqlstr, OleDbParameter[] param)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = Sqlstr;
                cmd.Parameters.AddRange(param);
                conn.Open();
                int AffectRows = cmd.ExecuteNonQuery();//对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。
                conn.Close();                         //对于所有其他类型的语句，返回值为 -1。如果发生回滚，返回值也为 -1。

                if (AffectRows > 0 || AffectRows == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 执行SQL语句并返回数据表
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(Sqlstr, conn);
                DataTable dt = new DataTable();
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        /// 执行SQL语句并返回数据表
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象列表</param>
        /// <returns></returns>
        public static DataTable ExecuteDt(String Sqlstr, OleDbParameter[] param)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand(Sqlstr, conn);
                //cmd.CommandText = Sqlstr;
                //cmd.Connection = conn;
                cmd.Parameters.AddRange(param);
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
        }

        /// <summary>
        /// 批量执行SQL语句
        /// </summary>
        /// <param name="Sqlstr">SQL语句数组</param>
        /// <param name="param">SQL参数对象数组</param>
        /// <returns></returns>
        public static Boolean ExecuteSqls(String[] Sqlstr, List<OleDbParameter[]> param)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {

                OleDbCommand cmd = new OleDbCommand();
                OleDbTransaction tran = null;
                cmd.Transaction = tran;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    Int32 count = Sqlstr.Length;
                    for (Int32 i = 0; i < count; i++)
                    {
                        cmd.CommandText = Sqlstr[i];
                        cmd.Parameters.AddRange(param[i]);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 根据SQL语句,取得OleDbDataReader结果
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteDr(string Sqlstr)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                OleDbCommand cmd = new OleDbCommand(Sqlstr, conn);
                //cmd.CommandText = Sqlstr;
                //cmd.Connection = conn;
                conn.Open();
                OleDbDataReader dataReader = cmd.ExecuteReader();
                conn.Close();
                return dataReader;
            }
        }

        /// <summary>
        /// 根据SQL语句,取得OleDbDataReader结果
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象列表</param>
        /// <returns>OleDbDataReader</returns>
        public static OleDbDataReader ExecuteDr(string Sqlstr, OleDbParameter[] param)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                OleDbCommand cmd = new OleDbCommand(Sqlstr, conn);
                //cmd.CommandText = Sqlstr;
                //cmd.Connection = conn;
                cmd.Parameters.AddRange(param);
                conn.Open();
                OleDbDataReader dataReader = cmd.ExecuteReader();
                conn.Close();
                return dataReader;
            }
        }

        /// <summary>
        /// 执行SQL语句并返回数据集
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDs(String Sqlstr)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand(Sqlstr, conn);
                //cmd.CommandText = Sqlstr;
                //cmd.Connection = conn;
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }

        /// <summary>
        /// 执行SQL语句并返回数据集
        /// </summary>
        /// <param name="Sqlstr">SQL语句</param>
        /// <param name="param">参数对象列表</param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDs(String Sqlstr, OleDbParameter[] param)
        {
            String ConnStr = OleDbHelper.GetOleDbConnection();
            using (OleDbConnection conn = new OleDbConnection(ConnStr))
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand(Sqlstr, conn);
                //cmd.CommandText = Sqlstr;
                //cmd.Connection = conn;
                cmd.Parameters.AddRange(param);
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
        }
    }
}
