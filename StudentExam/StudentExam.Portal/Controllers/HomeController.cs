using StudentExam.BLL.IRepositories;
using StudentExam.BLL.Repositories;
using StudentExam.Entity;
using StudentExam.Portal.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace StudentExam.Portal.Controllers
{
    public class HomeController : Controller
    {
        StudentMasterViewModel studentMasterViewModel;
        IExamRepository examRepository;
        ISubjectRepository subjectRepository;
        IStudentMasterRepository studentMasterRepository;
        IStudentDetailsRepository studentDetailsRepository;
        public HomeController()
        {
            subjectRepository = new SubjectRepository();
            examRepository = new ExamRepository();
            studentMasterViewModel = new StudentMasterViewModel();
            studentMasterRepository = new StudentMasterRepository();
            studentDetailsRepository = new StudentDetailsRepository();
        }
        [HttpGet]
        public ActionResult Index()
        { 
            var Subjects= subjectRepository.GetAll().ToList();
            var ListSubjects = new SelectList(Subjects,"ID","Name");
            studentMasterViewModel.ListOfSubjects = ListSubjects;
            
            var Exams = examRepository.GetAll().ToList();
            var ListExams = new SelectList(Exams,"ID","Name");
            studentMasterViewModel.ListOfExams = ListExams;


           var listOfStudent= studentMasterRepository.GetAll();
           var listOfStudentModels = new List<StudentModel>();
           
            foreach (var item in listOfStudent)
            {
                var student = new StudentModel();
                student.ClassName = item.ClassName;
                student.ExamName = item.Exam.Name;
                student.RollNumber = item.RollNumber;
                student.StduentId = item.StudentId;
                student.StudentName = item.Name;
                listOfStudentModels.Add(student);
            }
            studentMasterViewModel.ListOfStudentModels = listOfStudentModels;
            return View(studentMasterViewModel);
        }
        [HttpPost]
        public ActionResult Index(StudentViewModel objStudentViewModel)
        {
            var objStudentMaster = new StudentMaster();
            objStudentMaster.Name = objStudentViewModel.StudentName;
            objStudentMaster.ClassName = objStudentViewModel.ClassName;
            objStudentMaster.ExamId = objStudentViewModel.ExamId;
            objStudentMaster.RollNumber = objStudentViewModel.RollNumber;
            studentMasterRepository.Insert(objStudentMaster);

            foreach (var item in objStudentViewModel.ListOfStudentMarks)
            {
                var studentDetail = new StudentDetail();
                studentDetail.MarksObtained = item.ObtainedMarks;
                studentDetail.Percentage = item.Percentage;
                studentDetail.SubjectId = item.SubjectId;
                studentDetail.TotalMarks = item.TotalMarks;
                studentDetail.StudentId = objStudentMaster.StudentId;

                studentDetailsRepository.Insert(studentDetail);

            }
            return Json(new { message="Data Successfully Added",status=true},JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult GetStudentMarks(int studentId)
        {
            var studentMarks = studentDetailsRepository.FindBy(a => a.StudentId == studentId).Include(a => a.Subject);
            var studentMarksModelList = new List<StudentMarksModel>();
            foreach (var item in studentMarks)
            {
                var AllStudentMarks = new StudentMarksModel();
                AllStudentMarks.StudentId = (int)item.StudentId;
                AllStudentMarks.SubjectName = item.Subject.Name;
                AllStudentMarks.TotalMarks = (int)item.TotalMarks;
                AllStudentMarks.MarksObtained = (int)item.MarksObtained;
                AllStudentMarks.percentage = (decimal)item.Percentage;
                studentMarksModelList.Add(AllStudentMarks);
            }
            return PartialView("_StudentMarksPartial", studentMarksModelList);
        }

    }
}