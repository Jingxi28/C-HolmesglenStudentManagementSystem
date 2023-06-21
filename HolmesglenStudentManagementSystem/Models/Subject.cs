using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Subject
    {
        public string Id;
        public string Title;
        public string NumberOfSession;
        public string HourPerSession;


        public Subject()
        {
            Id = "";
            Title = "";
            NumberOfSession = "";
            HourPerSession = "";
        }
        public Subject(string id, string title, string numberOfSession, string hourPerSession)
        { 
        Id = id;
        Title = title;
        NumberOfSession = numberOfSession;
        HourPerSession = hourPerSession; 
        }
    }
}
