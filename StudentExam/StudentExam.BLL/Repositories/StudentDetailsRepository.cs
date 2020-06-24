using StudentExam.BLL.IRepositories;
using StudentExam.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentExam.BLL.Repositories
{
    public class StudentDetailsRepository : IStudentDetailsRepository
    {
        StudentDBEntities db;
        public StudentDetailsRepository()
        {
            db = new StudentDBEntities();
        }
        public void Delete(StudentDetail entity)
        {
            db.StudentDetails.Remove(entity);
            SaveChanges();
        }

        public IQueryable<StudentDetail> FindBy(Expression<Func<StudentDetail, bool>> predicate)
        {
            return db.StudentDetails.Where(predicate);
        }

        public StudentDetail Get(int Id)
        {
            return db.StudentDetails.SingleOrDefault(a=>a.StudentDetailId==Id);
        }

        public IEnumerable<StudentDetail> GetAll()
        {
            return db.StudentDetails.ToList();
        }

        public void Insert(StudentDetail entity)
        {
            db.StudentDetails.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(StudentDetail entity)
        {
            var old = Get(entity.StudentDetailId);
            old.SubjectId = entity.SubjectId;
            old.TotalMarks = entity.TotalMarks;
            old.Percentage = entity.Percentage;
            old.MarksObtained = entity.MarksObtained;
            old.StudentId = entity.StudentId;
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
