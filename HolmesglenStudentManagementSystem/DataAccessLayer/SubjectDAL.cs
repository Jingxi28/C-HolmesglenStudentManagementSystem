using Microsoft.Data.Sqlite;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class SubjectDAL
    {        
        private SqliteConnection Connection;

        public SubjectDAL(SqliteConnection connection)
        {
            // connect to the target database
            Connection = connection;
        }
        // create new subject method
        public void Create(Subject subject)
        {
            Connection.Open();
            //build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Subject
                (SubjectID, Title, NumberOfSession, HourPerSession)
                VALUES(@a, @b, @c, @d)

            ";
            command.Parameters.AddWithValue("a", subject.Id);
            command.Parameters.AddWithValue("b", subject.Title);
            command.Parameters.AddWithValue("c", subject.NumberOfSession);
            command.Parameters.AddWithValue("d", subject.HourPerSession);

            //execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        //Read one by id
        public Subject Read(string id)
        {
            Subject subject = null;
            Connection.Open();
            //build the query command
            var command =Connection.CreateCommand();
            command.CommandText = @"
            SELECT SubjectID, Title, NumberOfSession, HourPerSession
            FROM Subject
            WHERE SubjectId =@a
            ";
            command.Parameters.AddWithValue("a", id);

            //execute the query
            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var SubjectId = reader.GetString(0);
                var SubjectTitle = reader.GetString(1);
                var SubjectNumberOfSession = reader.GetString(2);
                var SubjectHourPerSession = reader.GetString(3);
                subject = new Subject(SubjectId, SubjectTitle, SubjectNumberOfSession, SubjectHourPerSession); 
            }//else subject =null

            Connection.Close();
            return subject;
        }

        // read all
        public List<Subject> ReadAll()
        {
            var subjects = new List<Subject>();

            Connection.Open();
            //build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT SubjectID, Title, NumberOfSession, HourPerSession
                FROM Subject
            ";

            //execute the query 
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var SubjectId = reader.GetString(0);
                var SubjectTitle = reader.GetString(1);
                var SubjectNumberOfSession = reader.GetString(2);
                var SubjectHourPerSession = reader.GetString(3);
                subjects.Add(new Subject(SubjectId, SubjectTitle, SubjectNumberOfSession, SubjectHourPerSession)); 

            }
            Connection.Close();
            return subjects;
        }

        //Update by id
        public void Update(Subject subject)
        {
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"
                UPDATE Subject
                SET Title = @a, 
                    NumberOfSession = @b, 
                    HourPerSession = @c
                WHERE SubjectID = @d
            ";
            command.Parameters.AddWithValue("a", subject.Title);
            command.Parameters.AddWithValue("b", subject.NumberOfSession);
            command.Parameters.AddWithValue("c", subject.HourPerSession);
            command.Parameters.AddWithValue("d", subject.Id);

            //execute the query
            command.ExecuteReader();

            Connection.Close();
        }

        //Delete by id
        public void Delete(string id)
        {
            Connection.Open();
            var command = Connection.CreateCommand();
            command.CommandText = @"
                DELETE FROM Subject
                WHERE SubjectID = @a
            ";
            command.Parameters.AddWithValue("a", id);
            //execute the query
            command.ExecuteReader();
            Connection.Close();
        }
    }
}
