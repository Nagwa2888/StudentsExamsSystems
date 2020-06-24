using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentExam.Portal.Models.ViewModel
{
    public class StudentMarksModel
    {
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public int TotalMarks { get; set; }
        public int MarksObtained { get; set; }
        public decimal percentage { get; set; }
    }
}