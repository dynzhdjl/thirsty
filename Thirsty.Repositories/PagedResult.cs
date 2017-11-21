using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thirsty.Repositories
{
    public class PagedResult<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; set; }
        public int CurrentPageIndex { get; set; }
        public int TotalPageCount { get; set; }

        public PagedResult(IEnumerable<TEntity> items, int currentPageIndex, int totalPageCount)
        {
            if(currentPageIndex <= 0)
            {
                throw new ArgumentException();
            }
            if(totalPageCount < currentPageIndex)
            {
                throw new ArgumentException();
            }
            Items = items;
            CurrentPageIndex = currentPageIndex;
            TotalPageCount = totalPageCount;
        }
    }
}
