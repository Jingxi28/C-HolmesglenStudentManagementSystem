using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using HolmesglenStudentManagementSystem.PresentationLayer.StudentPL;
using HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL;
using HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL;
using HolmesglenStudentManagementSystem.Models;

namespace HolmesglenStudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new GetAllStudents().Run();
            // uncomment the code below for testing
            //(new GetOneStudent()).Run();
            //(new CreateStudent()).Run();
            //(new UpdateStudent()).Run();
            //(new DeleteStudent()).Run();

            //new GetAllSubjects().Run();
            //(new GetOneSubject()).Run();
            //(new CreateSubject()).Run();
            //(new UpdateSubject()).Run();
            //(new DeleteSubject()).Run();




            new GetAllEnrollments().Run();
            //(new GetOneEnrollment()).Run();
            //(new CreateEnrollment()).Run();
            //(new UpdateEnrollment()).Run();
            (new DeleteEnrollment()).Run();



        }

    }
}
