namespace DB_993.Classes
{
    /// <summary>
    /// Класс, используемый для хранения информации об объектах пользователя в черном списке.
    /// </summary>
    public class BlackListTable
    {
        public int Id { get; set; }
        public List<Realty> Realtys { get; set; } = new();
    }
}
