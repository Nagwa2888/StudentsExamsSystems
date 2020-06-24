using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentExam.BLL.IRepositories
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int Id);
        IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Insert(TEntity entity);
        void SaveChanges();
    }
}
