using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV
{
    internal class STUDENT
    {
        MY_DB mydb = new MY_DB();

        public static int Id { get; set; }
        public static string FName { get; set; }
        public static string LName { get; set; }
        public static DateTime Bdate { get; set; }
        public static string Gender { get; set; }
        public static string Phone { get; set; }
        public static string Address { get; set; }
        public static string Pic { get; set; }
        public static string Email { get; set; }

        public static bool checkUserExist()
        {
            try
            {
                MY_DB db = new MY_DB();
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from std where id = @id", db.getConnection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Id;
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
        public static bool AddStudent()
        {

            MY_DB mydb = new MY_DB();
            SqlCommand command = new SqlCommand("INSERT INTO std (id, fname, lname, bdate, email)" +
                " VALUES (@id,@fn, @ln, @bdt,@email)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = FName;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = LName;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = Bdate;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;

            mydb.openConnection();
            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;

        }

        //  function to insert a new student
        public bool insertStudent(int Id, string fname, string lname, DateTime bdate, string gender, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO std (id, fname, lname, bdate, gender, phone, address, picture, email)" +
                " VALUES (@id,@fn, @ln, @bdt, @gdr, @phn, @adrs, @pic, @email)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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

        public DataTable getStudents(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateStudent(int Id, string fname, string lname, DateTime bdate, string gender, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname= @fn, lname=@ln, bdate=@bdt,gender=@gdr, phone=@phn, email = @email, address=@adrs, picture=@pic where Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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
        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("Delete from std where Id = @id", mydb.getConnection);
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
            return execCount("SELECT COUNT(*) FROM STD");
        }

        public string totalMaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM STD WHERE gender = 'Male'");
        }

        public string totalFemaleStudent()
        {
            return execCount("SELECT COUNT(*) FROM STD WHERE gender = 'Female'");
        }

    }
}
