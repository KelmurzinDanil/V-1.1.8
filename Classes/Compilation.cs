namespace DB_993.Classes
{
    /// <summary>
    /// Класс, используемый для хранения информации о подборках пользователя.
    /// </summary>
    public class Compilation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<Realty> Realtys { get; set; } = new();
        public List<User> Users { get; set; } = new();
        public List<IntermediateRealtyAndComp> intermediateRealtyAndComps { get; set; } = new();
    }
}
