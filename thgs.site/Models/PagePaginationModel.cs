using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thgs.site.Models
{
    public class PagePaginationModel
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int TotalPages { get; private set; }

        public PagePaginationModel(int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}
