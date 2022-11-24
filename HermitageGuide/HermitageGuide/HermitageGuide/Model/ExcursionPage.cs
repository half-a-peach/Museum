using System;
using System.Collections.Generic;
using System.Text;

namespace HermitageGuide
{
    /// <summary>
    /// Страница экскурсии
    /// </summary>
    public class ExcursionPage
    {
        /// <summary>
        /// ID страницы экскурсии
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Заголовок страницы экскурсии
        /// </summary>
        public string ExcursionPageName { get; set; }

        /// <summary>
        /// Расписание экскурсии
        /// </summary>
        public string ExcursionSchedule { get; set; }

        /// <summary>
        /// Место экскурсии
        /// </summary>
        public string ExcursionPlace { get; set; }

        /// <summary>
        /// Продолжительность экскурсии (минуты)
        /// </summary>
        public string ExcursionDuration { get; set; }

        /// <summary>
        /// Путь к обложке экскурсии
        /// </summary>
        public string ExcursionPagePict { get; set; }

        /// <summary>
        /// Подпись к обложке экскурсии
        /// </summary>
        public string ExcursionPageCaption { get; set; }

        /// <summary>
        /// Текст события
        /// </summary>
        public string ExcursionsPageText { get; set; }
    }
}
