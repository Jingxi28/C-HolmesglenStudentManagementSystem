﻿using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL
{
    public class GetOneSubject : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Getting a subject");
            Console.Write("Subject ID: ");
            var id = Console.ReadLine();

            var subjectBLL = new SubjectBLL();
            var subject = subjectBLL.GetOne(id);
            if (subject == null)
            {
                Console.WriteLine($"Subject({id}) does not exist");
            }
            else
            {
                Console.WriteLine($"{subject.Id}\t{subject.Title}\t{subject.NumberOfSession}\t{subject.HourPerSession}");
            }

        }
    }
}
