using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class EnrollmentDAL
    {
        private SqliteConnection Connection;

        public EnrollmentDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create new enrollment method
        public void Create(Enrollment enrollment)
        {
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Enrollment
                (EnrollmentID, StudentID_FK, SubjectID_FK)
                VALUES(@a, @b, @c)
            ";
            command.Parameters.AddWithValue("a", enrollment.Id);
            command.Parameters.AddWithValue("b", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("c", enrollment.SubjectID_FK);
            command.ExecuteReader();

            Connection.Close();
        }

        // Read one by id
        public Enrollment Read(string id)
        {
            Enrollment enrollment = null;
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT EnrollmentID, StudentID_FK, SubjectID_FK
                FROM Enrollment
                WHERE EnrollmentId = @a
            ";
            command.Parameters.AddWithValue("a", id);
            // execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var enrollmentId = reader.GetString(0);
                var enrollmenStudentID_FK = reader.GetString(1);
                var enrollmentSubjectID_FK = reader.GetString(2);
                enrollment = new Enrollment(enrollmentId, enrollmenStudentID_FK, enrollmentSubjectID_FK);
            } // else student = null

            Connection.Close();

            return enrollment;
        }

        // read all
        public List<Enrollment> ReadAll()
        {
            var enrollments = new List<Enrollment>();

            try
            {
                Connection.Open();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception occurred: " + ex.Message);
            }
            

            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT EnrollmentID, StudentID_FK, SubjectID_FK
                FROM Enrollment
            ";

            // execute the query
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var enrollmentId = reader.GetString(0);
                var enrollmenStudentID_FK = reader.GetString(1);
                var enrollmentSubjectID_FK = reader.GetString(2);
                enrollments.Add(new Enrollment(enrollmentId, enrollmenStudentID_FK, enrollmentSubjectID_FK));
            }
            Connection.Close();
            return enrollments;
        }

        // Update by id
        public void Update(Enrollment enrollment)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Enrollment
                SET StudentID_FK = @a,
                    SubjectID_FK = @b
                   
                WHERE EnrollmentID = @c
            ";
            command.Parameters.AddWithValue("a", enrollment.StudentID_FK);
            command.Parameters.AddWithValue("b", enrollment.SubjectID_FK);
            command.Parameters.AddWithValue("c", enrollment.Id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        //Delete by id
        public void Delete(string id)
        {
            // challenge yourself
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Enrollment
                WHERE EnrollmentID = @a
            ";
            command.Parameters.AddWithValue("a", id);

            // execute the query
            command.ExecuteReader();

            Connection.Close();
        }
    }
}
