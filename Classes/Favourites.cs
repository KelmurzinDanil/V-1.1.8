namespace DB_993.Classes
{
    /// <summary>
    /// Класс, используемый для хранения информации об избранных объектах пользователя.
    /// </summary>
    public class Favourites
    {
        public int Id { get; set; }
        public List<Realty> Realtys { get; set; } = new();
    }
}
