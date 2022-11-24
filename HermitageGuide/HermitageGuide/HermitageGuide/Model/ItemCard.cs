using System;
using System.Collections.Generic;
using System.Text;

namespace HermitageGuide
{
    /// <summary>
    /// Карточка объекта
    /// </summary>
    public class ItemCard
    {
        /// <summary>
        /// ID карточки объекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название карточки объекта
        /// </summary>
        public string ItemCardName { get; set; }

        /// <summary>
        /// Путь к обложке карточки объекта
        /// </summary>
        public string ItemCardPict { get; set; }
    }
}
