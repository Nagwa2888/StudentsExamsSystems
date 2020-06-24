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
    public class ExamRepository : IExamRepository
    {
        StudentDBEntities db;
        public ExamRepository()
        {
            db = new StudentDBEntities();     
        }
        public void Delete(Exam entity)
        {
            db.Exams.Remove(entity);
            SaveChanges();
        }

        public IQueryable<Exam> FindBy(Expression<Func<Exam, bool>> predicate)
        {
            return db.Exams.Where(predicate);
        }

        public Exam Get(int Id)
        {
            return db.Exams.SingleOrDefault(a => a.ID == Id);
        }

        public IEnumerable<Exam> GetAll()
        {
            return db.Exams.ToList();
        }

        public void Insert(Exam entity)
        {
            db.Exams.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Exam entity)
        {
            var old = Get(entity.ID);
            old.Name = entity.Name;
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
