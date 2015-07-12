using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.core.Abstracts
{
    public interface IController<T> where T : class
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        Boolean Add(T entity);
        Boolean Update(T entity);
        Boolean Delete(int id);
    }
}
