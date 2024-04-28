using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21110524_TranNguyenThuLai_QLSV
{
    internal class User
    {
        MY_DB mydb = new MY_DB();

        public DataTable getUser(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool deleteUser(String username)
        {
            SqlCommand command = new SqlCommand("Delete from account where username = @username", mydb.getConnection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }


        
        string execCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            String count = command.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }
        public string totalStudent()
        {
            return execCount("SELECT COUNT(*) FROM account");
        }

        public void Confirm(string username)
        {
            SqlCommand command = new SqlCommand("Update account set status = 'Accepted' where username = @username", mydb.getConnection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                
            }
            else
            {
                mydb.closeConnection();
                
            }
        }

    }

    
}
