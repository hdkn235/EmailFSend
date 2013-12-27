using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace HDHelper
{
    public static class AccessHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        static readonly string connStr = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        /// <summary>
        /// 执行增、删、改SQL语句
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sp">参数数据</param>
        public static void ExecuteNonQuery(string sql, params OleDbParameter[] sp)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    if (sp != null)
                    {
                        cmd.Parameters.AddRange(sp);
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回一行一列的值
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sp">参数数据</param>
        public static object ExecuteScalar(string sql, params OleDbParameter[] sp)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    if (sp != null)
                    {
                        cmd.Parameters.AddRange(sp);
                    }
                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回OleDbDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sp">参数数据</param>
        public static OleDbDataReader ExecuteReader(string sql, params OleDbParameter[] sp)
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    if (sp != null)
                    {
                        cmd.Parameters.AddRange(sp);
                    }
                    conn.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
            }
            catch (Exception ex)
            {
                conn.Dispose();
                throw ex;
            }
        }

        /// <summary>
        /// 执行查询语句，返回数据集DataSet
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sp">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string sql, params OleDbParameter[] sp)
        {
            DataSet ds = new DataSet();
            using (OleDbDataAdapter odda = new OleDbDataAdapter(sql, connStr))
            {
                if (sp != null)
                {
                    odda.SelectCommand.Parameters.AddRange(sp);
                }
                odda.Fill(ds);
            }
            return ds;
        }
    }
}
