using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> properties, params Expression<Func<T, Object>>[] includeProperties);

    }
}
