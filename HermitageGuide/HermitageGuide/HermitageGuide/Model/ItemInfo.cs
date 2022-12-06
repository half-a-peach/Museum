using SQLite;

namespace HermitageGuide
{
    /// <summary>
    /// Страница объекта
    /// </summary>
    [Table("Items")]
    public class ItemInfo
    {
        /// <summary>
        /// ID страницы объекта
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        /// <summary>
        /// ID экспозиции
        /// </summary>
        public int ExhibitionId { get; set; }

        /// <summary> 
        /// Путь к картинке объекта
        /// </summary>
        public string ItemPict { get; set; }

        /// <summary>
        /// Автор произведения
        /// </summary>
        public string ItemAuthor { get; set; }

        /// <summary> 
        /// Название произведения
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Время создания произведения
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// Место создания произведения
        /// </summary>
        public string CreationPlace { get; set; }

        /// <summary>
        /// Размеры произведения
        /// </summary>
        public string ItemSizes { get; set; } 

        /// <summary>
        /// Материал произведения
        /// </summary>
        public string ItemMaterial { get; set; }

        /// <summary>
        /// Техника создания произведения
        /// </summary>
        public string ItemTechnique { get; set; }

        /// <summary>
        /// Поступление произведения
        /// </summary>
        public string ItemAcquisition { get; set; }

        /// <summary>
        /// Инвернтарный номер произведения
        /// </summary>
        public string ItemStockNumber { get; set; }

        /// <summary>
        /// Категория произведения
        /// </summary>
        public string ItemCategory { get; set; }
    }
}
