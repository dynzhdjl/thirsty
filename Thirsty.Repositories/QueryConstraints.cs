using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{
    public class QueryConstraints : IQueryConstraints
    {
        private const int firstPageNumber = 1;

        public int PageNumber { get; private set; } = firstPageNumber;

        public SortOrder SortOrder { get; private set; } = SortOrder.Ascending;

        public string SortPropertyName { get; private set; }

        public IQueryConstraints Page(int pageNumber)
        {
            if(pageNumber <= 0)
            {
                throw new ArgumentException();
            }
            this.PageNumber = pageNumber;
            return this;
        }

        public IQueryConstraints SortBy(string propertyName)
        {
            if(String.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException();
            }
            SortOrder = SortOrder.Ascending;
            SortPropertyName = propertyName;
            return this;
        }

        public IQueryConstraints SortByDescending(string propertyName)
        {
            if (String.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException();
            }
            SortOrder = SortOrder.Descending;
            SortPropertyName = propertyName;
            return this;
        }

        public IQueryConstraints SortByDescending()
        {
            if(String.IsNullOrEmpty(SortPropertyName))
            {
                throw new InvalidOperationException();
            }
            SortOrder = SortOrder.Descending;
            return this;
        }
    }
}
