using System;
using System.Collections.Generic;
using System.Text;

namespace HermitageGuide
{
    /// <summary>
    /// Карточка экскурсии
    /// </summary>
    public class ExcursionCard
    {
        /// <summary>
        /// ID карточки экскурсии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название карточки экскурсии
        /// </summary>
        public string ExcursCardName { get; set; }

        /// <summary>
        /// Путь к обложке карточки экскурсии
        /// </summary>
        public string ExcursCardPict { get; set; }
    }
}
