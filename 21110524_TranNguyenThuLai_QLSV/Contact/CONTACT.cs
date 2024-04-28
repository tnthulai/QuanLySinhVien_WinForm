using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21110524_TranNguyenThuLai_QLSV.Contact
{
    class CONTACT
    {
        MY_DB mydb = new MY_DB();
        public DataTable selectContactList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool checkID(string id)
        {
            try
            {
                MY_DB db = new MY_DB();
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from contact where id = @id", db.getConnection);
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                var result = cmd.ExecuteReader();
                if (result.HasRows)
                {
                    db.closeConnection();
                    return false;
                }
                db.closeConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteContact(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM contact WHERE id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
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
        public bool updateContact(string id, string fname, string lname, int group_id, string phone, string address, MemoryStream picture, string email, string userid)
        {
            SqlCommand command = new SqlCommand("UPDATE contact SET fname=@fname, lname=@lname, group_id=@group_id, " +
                "phone=@phone, address=@address, picture=@picture, email=@email, userid=@userid " +
                "where id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@group_id", SqlDbType.Int).Value = group_id;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@userid", SqlDbType.VarChar).Value = userid;
            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
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
        public bool insertContact(string id, string fname, string lname, int group_id, string phone, string address, MemoryStream picture, string email, string userid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO contact (id, fname, lname, group_id, phone, address, picture, email, userid)" +
                " VALUES (@id, @fname, @lname, @group_id, @phone, @address, @picture, @email, @userid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@lname", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@group_id", SqlDbType.Int).Value = group_id;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
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
    }
}
