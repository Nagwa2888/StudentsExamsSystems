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
    public class SubjectRepository : ISubjectRepository
    {
        StudentDBEntities db;
        public SubjectRepository()
        {
            db = new StudentDBEntities();
        }
        public void Delete(Subject entity)
        {
            db.Subjects.Remove(entity);
            SaveChanges();
        }

        public IQueryable<Subject> FindBy(Expression<Func<Subject, bool>> predicate)
        {
            return db.Subjects.Where(predicate);
        }

        public Subject Get(int Id)
        {
            return db.Subjects.SingleOrDefault(a=>a.ID==Id);
        }

        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects.ToList();
        }

        public void Insert(Subject entity)
        {
            db.Subjects.Add(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Subject entity)
        {
            var old = Get(entity.ID);
            old.Name = entity.Name;
            db.Entry(old).State = System.Data.Entity.EntityState.Modified;
            SaveChanges();
        }
    }
}
