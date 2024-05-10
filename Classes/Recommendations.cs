namespace DB_993.Classes
{
    /// <summary>
    /// Класс представляет модель данных для хранения рекомендаций или оценок недвижимости.
    /// </summary>
    public class Recommendations
    {
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public List<Realty> Realtys { get; set; } = new();
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
