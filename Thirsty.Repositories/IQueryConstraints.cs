using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public interface IQueryConstraints
    {
        int PageNumber { get; }
        SortOrder SortOrder { get; }
        string SortPropertyName { get; }
        IQueryConstraints Page(int pageNumber);
        IQueryConstraints SortBy(string propertyName);
        IQueryConstraints SortByDescending(string propertyName);
        IQueryConstraints Descending();
    }
}
