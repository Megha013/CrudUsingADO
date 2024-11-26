using Microsoft.Data.SqlClient;

namespace CrudUsingADO.Models
{
    public class StudentCrud
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;

        public StudentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }
        // Get all emp
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            cmd = new SqlCommand("select * from student", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Percentage = Convert.ToDouble(dr["percentage"]);
                    students.Add(student);
                }

            }
            con.Close();
            return students;
        }
        public Student GetStudentById(int id)
        {
            Student student = new Student();
            cmd = new SqlCommand("select * from student where rollno=@rollno", con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.RollNo = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Email = dr["email"].ToString();
                    student.Percentage = Convert.ToDouble(dr["percentage"]);

                }
            }
            con.Close();
            return student;
        }
        public int AddStudent(Student stu)
        {
            int result = 0;
            string qry = "insert into student values(@name,@branch,@email,@percentage)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stu.Name);
            cmd.Parameters.AddWithValue("@branch", stu.Branch);
            cmd.Parameters.AddWithValue("@email", stu.Email);
            cmd.Parameters.AddWithValue("@salary", stu.Percentage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student stu)
        {
            int result = 0;
            string qry = "update student set name=@name,branch=@branch,email=@email,percentage=@percantage where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stu.Name);
            cmd.Parameters.AddWithValue("@branch", stu.Branch);
            cmd.Parameters.AddWithValue("@email", stu.Email);
            cmd.Parameters.AddWithValue("@percentage", stu.Percentage);
            cmd.Parameters.AddWithValue("@rollno", stu.RollNo);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from student where rollno=@rollno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
