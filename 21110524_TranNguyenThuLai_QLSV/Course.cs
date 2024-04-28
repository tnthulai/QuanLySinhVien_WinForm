using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.Word;

namespace _21110524_TranNguyenThuLai_QLSV
{
    internal class Course
    {

        public string id { get; set; }
        public string lable { get; set; }

        public string period { get; set; }

        public string desc { get; set; }
        public string semester { get; set; }

        public Course(string id, string lable)
        {
            this.id = id;
            this.lable = lable;
        }


        public Course()
        {
        }

        public override string ToString()
        {
            return lable;
        }

        MY_DB mydb = new MY_DB();

        public bool insertCourse(String id, String lable, int period, String desc, String semester)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (id, lable, period, description, semester)" +
                " VALUES (@id,@lable, @period, @desc, @semester)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@lable", SqlDbType.VarChar).Value = lable;
            command.Parameters.Add("@period", SqlDbType.Int).Value = period;
            command.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = semester;


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


        public bool updateCourse(String id, String lable, int period, String desc, String semester)
        {
            SqlCommand command = new SqlCommand("update Course set lable = @lable, period = @period, description = @desc, semester = @semester Where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@lable", SqlDbType.VarChar).Value = lable;
            command.Parameters.Add("@period", SqlDbType.Int).Value = period;
            command.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
            command.Parameters.Add("@semester", SqlDbType.VarChar).Value = semester;

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
        public bool deleteCourse(String id)
        {
            SqlCommand command = new SqlCommand("delete from Course where id = @id", mydb.getConnection);
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
        public bool checkCourseExist (String id)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("Select * from Course where id = @id");
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
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
        public DataTable getCourse(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}




