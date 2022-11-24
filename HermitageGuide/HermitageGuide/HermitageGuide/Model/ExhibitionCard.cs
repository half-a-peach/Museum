using System;
using System.Collections.Generic;
using System.Text;

namespace HermitageGuide
{
    /// <summary>
    /// Карточка экспозиции
    /// </summary>
    public class ExhibitionCard
    {
        /// <summary>
        /// ID карточки экспозиции
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название карточки экспозиции
        /// </summary>
        public string ExhibitCardName { get; set; }

        /// <summary>
        /// Путь к обложке карточки экспозиции
        /// </summary>
        public string ExhibitCardPict { get; set; }
    }
}
