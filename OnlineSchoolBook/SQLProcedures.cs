using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchoolBook
{
    class SQLProcedures
    {
        public static string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStr"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connstr);
        public static SqlCommand cmd;
        public static SqlDataAdapter dataAdapter;
        public static DataTable SelectUsers()
        {
            cmd = new SqlCommand("SelectUsers", conn);
            dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }

        public static void InsertUser(string name, string lastname, string username, string password)
        {
            cmd = new SqlCommand("InsertUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[4];

            paramss[0] = new SqlParameter("@name", SqlDbType.VarChar, (50));
            paramss[0].Value = name;

            paramss[1] = new SqlParameter("@lastname", SqlDbType.VarChar, (50));
            paramss[1].Value = lastname;

            paramss[2] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[2].Value = username;

            paramss[3] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[3].Value = password;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UpdateUser(int id, string name, string lastname, string username, string password)
        {
            cmd = new SqlCommand("UpdateUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[5];

            paramss[0] = new SqlParameter("@id", SqlDbType.VarChar, (50));
            paramss[0].Value = id;

            paramss[1] = new SqlParameter("@name", SqlDbType.VarChar, (50));
            paramss[1].Value = name;

            paramss[2] = new SqlParameter("@lastname", SqlDbType.VarChar, (50));
            paramss[2].Value = lastname;

            paramss[3] = new SqlParameter("@username", SqlDbType.VarChar, (50));
            paramss[3].Value = username;

            paramss[4] = new SqlParameter("@password", SqlDbType.VarChar, (50));
            paramss[4].Value = password;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteUser(int id)
        {
            cmd = new SqlCommand("DeleteUser", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter[] paramss = new SqlParameter[1];

            paramss[0] = new SqlParameter("@id", SqlDbType.VarChar, (50));
            paramss[0].Value = id;

            cmd.Parameters.AddRange(paramss);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
