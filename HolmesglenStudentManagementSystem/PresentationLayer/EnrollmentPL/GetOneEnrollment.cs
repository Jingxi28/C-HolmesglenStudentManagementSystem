﻿using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class GetOneEnrollment : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting a enrollment");
            Console.Write("Enrollment ID: ");
            var id = Console.ReadLine();

            var enrollmentBLL = new EnrollmentBLL();
            var enrollment = enrollmentBLL.GetOne(id);
            if (enrollment == null)
            {
                Console.WriteLine($"Enrollment({id}) does not exist");
            }
            else
            {
                Console.WriteLine($"{enrollment.Id}\t{enrollment.StudentID_FK}\t{enrollment.SubjectID_FK}");
            }
        }
    }
}
