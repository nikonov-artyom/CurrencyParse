namespace CurrencyParse.Models
{
    /// <summary>
    /// Валюта
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Цифр. код
        /// </summary>
        /// <remarks>Используется тип String, из за наличия 0 (нулей) в начале значений</remarks>
        public string Code { get; set; }

        /// <summary>
        /// Букв. код
        /// </summary>
        public string CodeDescription { get; set; }

        /// <summary>
        /// За едениц
        /// </summary>
        public int Unit { get; set; }

        /// <summary>
        /// Наименование валюты
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        public decimal Value { get; set; }
    }
}
