using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{
    public interface IMenuRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetMenu();
    }
}
