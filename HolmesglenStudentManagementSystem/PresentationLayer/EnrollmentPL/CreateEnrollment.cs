using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class CreateEnrollment : PLBase
    {
        public override void Run()
        {
            var enrollment = new Enrollment();
            Console.WriteLine("Creating a new enrollment");
            Console.Write("Enter ID: ");
            enrollment.Id = Console.ReadLine();
            Console.Write("Enter StudentID_FK: ");
            enrollment.StudentID_FK = Console.ReadLine();
            Console.Write("Enter SubjectID_FK: ");
            enrollment.SubjectID_FK = Console.ReadLine();
            

            var enrollmentBLL = new EnrollmentBLL();
            var result = enrollmentBLL.Create(enrollment);

            if (result == false)
            {
                Console.WriteLine($"Create new enrollment unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new enrollment successful");
            }
        }
    }
}
