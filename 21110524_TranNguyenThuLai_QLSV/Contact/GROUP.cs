using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    class GROUP
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public GROUP(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public GROUP()
        {
        }

        public override string ToString()
        {
            return Name;
        }

        MY_DB mydb = new MY_DB();


        public bool insertGroup(String name, string userid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO groups (name, userid)" +
                " VALUES (@name, @userid)", mydb.getConnection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@userid", SqlDbType.VarChar).Value = userid;


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


        public bool updateGroup(int id, String name)
        {
            SqlCommand command = new SqlCommand("update groups set name = @name Where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

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
        public bool deleteGroup(int id)
        {
            SqlCommand command = new SqlCommand("delete from groups where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
        public bool checkGroupExist(int id)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("Select * from groups where id = @id");
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    mydb.closeConnection();
                    return false;
                }
                mydb.closeConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable getGroup(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = mydb.getConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
