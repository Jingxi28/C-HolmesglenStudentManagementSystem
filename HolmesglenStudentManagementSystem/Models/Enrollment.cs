using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Enrollment
    {
        public string Id;
        public string StudentID_FK; 
        public string SubjectID_FK;

        public Enrollment() 
        {
            Id = "";
            StudentID_FK = "";
            SubjectID_FK = "";
        }
       public Enrollment(string id, string studentId_FK, string subjectId_FK)
        {
            Id = id;
            StudentID_FK = studentId_FK;
            SubjectID_FK = subjectId_FK;
        }

    }
}
