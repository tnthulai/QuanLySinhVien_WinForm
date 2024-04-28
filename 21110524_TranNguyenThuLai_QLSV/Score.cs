using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.VariantTypes;
using System.Windows.Forms;

namespace _21110524_TranNguyenThuLai_QLSV
{
    internal class Score
    {
        MY_DB mydb = new MY_DB();
        public bool insertScore(string student_id, string course_id , double? score, string desc)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO score (student_id, course_id, student_score, decription)" +
                " VALUES (@stdid,@courseid, @score, @desc)", mydb.getConnection);
                command.Parameters.Add("@stdid", SqlDbType.VarChar).Value = student_id;
                command.Parameters.Add("@courseid", SqlDbType.VarChar).Value = course_id;
                if (score.HasValue)
                {
                    command.Parameters.Add("@score", SqlDbType.Float).Value = score.Value;
                }
                else
                {
                    command.Parameters.Add("@score", SqlDbType.Float).Value = DBNull.Value;
                }
                command.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;

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
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.Message);
            }
        }

        public bool updateScore(string student_id, string course_id, double? score, string desc)
        {
            try
            {
                SqlCommand command = new SqlCommand("update score set student_score = @score, decription = @desc where student_id = @stdid and course_id = @courseid", mydb.getConnection);
                command.Parameters.Add("@stdid", SqlDbType.VarChar).Value = student_id;
                command.Parameters.Add("@courseid", SqlDbType.VarChar).Value = course_id;
                if (score.HasValue)
                {
                    command.Parameters.Add("@score", SqlDbType.Float).Value = score.Value;
                }
                else
                {
                    command.Parameters.Add("@score", SqlDbType.Float).Value = DBNull.Value;
                }
                command.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;

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
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.Message);
            }
        }


        public bool studentScoreExist(String stdId, String courseId)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("Select * from score where student_id = @stdid AND course_id = @courseid", mydb.getConnection);
                command.Parameters.Add("@stdid", SqlDbType.VarChar).Value = stdId;
                command.Parameters.Add("@courseid", SqlDbType.VarChar).Value = courseId;

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
        public bool courseExist(String stdId, String courseId)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("Select * from score where course_id = @courseid", mydb.getConnection);
                command.Parameters.Add("@courseid", SqlDbType.VarChar).Value = courseId;

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

        public bool studentExist(String stdId)
        {
            try
            {
                mydb.openConnection();
                SqlCommand command = new SqlCommand("Select * from score where student_id = @stdid", mydb.getConnection);
                command.Parameters.Add("@stdid", SqlDbType.VarChar).Value = stdId;
                
                var result = command.ExecuteReader();
                if (result.HasRows)
                {
                    mydb.closeConnection();
                    return true;
                }
                mydb.closeConnection();
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteScore(String studentId, String courseID)
        {
            try
            {
                SqlCommand command = new SqlCommand("delete from score where student_id = @id AND course_id = @courseid", mydb.getConnection);
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = studentId;
                command.Parameters.Add("@courseid", SqlDbType.VarChar).Value = courseID;

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
            catch (Exception ex)
            {
                return false;
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable getAvgScoreByCourse()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;

            command.CommandText = "select Course.lable as CourseName , AVG(score.student_score) as AverageGrade from Course, score where Course.Id = score.course_id group by Course.lable";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public string getCourseName(String courseID)
        {
            string name = null;
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;

            command.CommandText = "select lable from Course where id = @id";
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = courseID;

            mydb.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            
            
            if (reader.Read())
            {
                name = reader["lable"].ToString();
            }
            mydb.closeConnection();
            return name;
            
        }
        public string getCourseId(String name)
        {
            string id = null;
            SqlCommand command = new SqlCommand();
            command.Connection = mydb.getConnection;

            command.CommandText = "select Id from Course where lable = @name";
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

            mydb.openConnection();
            SqlDataReader reader = command.ExecuteReader();


            if (reader.Read())
            {
                name = reader["Id"].ToString();
            }
            mydb.closeConnection();
            return name;

        }
    }
}
