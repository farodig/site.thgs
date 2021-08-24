using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace thgs.site.Models
{
    /// <summary>
    /// Модель старницы с пагинацией
    /// </summary>
    public class UsersViewModel
    {
        /// <summary>
        /// Список пользователей
        /// </summary>
        public List<UserModel> Users { get; set; }

        /// <summary>
        /// Пагинация
        /// </summary>
        public PagePaginationModel PagePaginationModel { get; set; }
    }
}
