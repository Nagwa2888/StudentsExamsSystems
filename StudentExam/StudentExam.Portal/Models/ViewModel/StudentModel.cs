using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentExam.Portal.Models.ViewModel
{
    public class StudentModel
    {
        public int StduentId { get; set; }
        public string StudentName { get; set; }
        public string ExamName { get; set; }
        public string ClassName { get; set; }
        public int? RollNumber { get; set; }
    }
}