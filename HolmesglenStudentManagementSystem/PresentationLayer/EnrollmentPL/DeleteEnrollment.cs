﻿using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL
{
    public class DeleteEnrollment : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Deleting a enrollment");
            Console.Write("Enrollment ID: ");
            var id = Console.ReadLine();

            var enrollmentBLL = new EnrollmentBLL();
            var result = enrollmentBLL.Delete(id);
            if (result == false)
            {
                Console.WriteLine($"Delete enrollment unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete enrollment successful");
            }
        }
    }
}
