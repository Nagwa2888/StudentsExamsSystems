using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentExam.Portal.Models.ViewModel
{
    public class StudnetMarksViewModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainedMarks { get; set; }
        public decimal Percentage { get; set; }
    }
}