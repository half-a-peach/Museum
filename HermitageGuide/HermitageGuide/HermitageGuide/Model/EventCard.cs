using System;
using System.Collections.Generic;
using System.Text;

namespace HermitageGuide
{
    /// <summary>
    /// Карточка события
    /// </summary>
    public class EventCard
    {
        /// <summary>
        /// ID карточки события
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название карточки события
        /// </summary>
        public string EventCardTitle { get; set; }

        /// <summary>
        /// Дата карточки события
        /// </summary>
        public DateTime EventCardDate { get; set; }

        /// <summary>
        /// Путь к обложке карточки события
        /// </summary>
        public string EventCardPict { get; set; }
    }
}
