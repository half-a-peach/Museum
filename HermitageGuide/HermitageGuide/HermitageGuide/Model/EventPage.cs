using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace HermitageGuide
{
    /// <summary>
    /// Страница события
    /// </summary>
    public class EventPage
    {
        /// <summary>
        /// ID страницы события
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок страницы события
        /// </summary>
        public string EventPageName { get; set; }

        /// <summary>
        /// Вступление к тексту события
        /// </summary>
        public string EventPageIntro { get; set; }

        /// <summary>
        /// Путь к обложке события
        /// </summary>
        public string EventPagePict { get; set; }

        /// <summary>
        /// Подпись к обложке события
        /// </summary>
        public string EventPageCaption { get; set; }

        /// <summary>
        /// Текст события
        /// </summary>
        public string EventPageText { get; set; }
    }
}
