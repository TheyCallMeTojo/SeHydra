using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SeHydra.Security
{
    class Server
    {
        private readonly string _serverString = "Data Source=stxsbrgx6b.database.windows.net;"
            + "Initial Catalog=seomadness;"
            + "Persist Security Info=True;"
            + "User ID=projectintercept@stxsbrgx6b;"
            + "Password=" + Cryptor.DecryptStringAes("XHJat5Cg+A6s/lfjFwIJEA==", "109237sddsdDD");

        /// <summary>
        ///     Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param name="sql">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string sql)
        {
            var dt = new DataTable();
            try
            {
                var connectionString = new SqlConnection(_serverString);
                connectionString.Open();
                var mycommand = new SqlCommand { Connection = connectionString, CommandText = sql };
                var reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                connectionString.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return dt;
        }

        /// <summary>
        /// Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                var connectionString = new SqlConnection(_serverString);
                connectionString.Open();
                var mycommand = new SqlCommand { Connection = connectionString, CommandText = sql };
                var rowsUpdated = mycommand.ExecuteNonQuery();
                connectionString.Close();
                return rowsUpdated;
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            return 0;
        }

        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public string ExecuteScalar(string sql)
        {
            var connectionString = new SqlConnection(_serverString);
            connectionString.Open();
            var mycommand = new SqlCommand { Connection = connectionString, CommandText = sql };
            var value = mycommand.ExecuteScalar();
            connectionString.Close();
            return value != null ? value.ToString() : "";
        }

        /// <summary>
        ///     Allows the programmer to easily delete rows from the DB.
        /// </summary>
        /// <param name="tableName">The table from which to delete.</param>
        /// <param name="where">The where clause for the delete.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Delete(String tableName, String where)
        {
            var returnCode = true;
            try
            {
                ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        ///     Allows the user to easily clear all data from a specific table.
        /// </summary>
        /// <param name="table">The name of the table to clear.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearTable(String table)
        {
            try
            {
                ExecuteNonQuery(String.Format("delete from {0};", table));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
