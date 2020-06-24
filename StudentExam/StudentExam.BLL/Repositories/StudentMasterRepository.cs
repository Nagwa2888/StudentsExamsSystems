using StudentExam.BLL.IRepositories;
using StudentExam.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentExam.BLL.Repositories
{
    public class StudentMasterRepository : IStudentMasterRepository
    {
        StudentDBEntities db ;
        public StudentMasterRepository()
        {
            db = new StudentDBEntities();
        }
        public void Delete(StudentMaster entity)
        {
            db.StudentMasters.Remove(entity);
            SaveChanges();
        }

        public IQueryable<StudentMaster> FindBy(Expression<Func<StudentMaster, bool>> predicate)
        {
            return db.StudentMasters.Where(predicate);
        }

        public StudentMaster Get(int Id)
        {
            return db.StudentMasters.FirstOrDefault(a=>a.StudentId==Id);
        }

        public IEnumerable<StudentMaster> GetAll()
        {
            return db.StudentMasters.Include(a=>a.Exam).ToList();
        }

        public void Insert(StudentMaster entity)
        {
            db.StudentMasters.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(StudentMaster entity)
        {
            var old = Get(entity.StudentId);
            old.Name = entity.Name;
            old.ClassName = entity.ClassName;
            old.ExamId = entity.ExamId;
            old.RollNumber = entity.RollNumber;
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
