using System;
using System.Collections.Generic;
using System.Text;

namespace HermitageGuide
{
    /// <summary>
    /// Страница экспозиции
    /// </summary> 
    public class ExhibitionPage
    {
        /// <summary>
        /// ID страницы экспозиции
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок страницы экспозиции
        /// </summary>
        public string ExhibitPageName { get; set; }

        /// <summary>
        /// Путь к обложке страницы экспозиции
        /// </summary>
        public string ExhibitPagePict { get; set; }

        /// <summary>
        /// Список карточек экспозиции
        /// </summary>
        public List<ItemCard> ItemCardList { get; set; }
    }
}