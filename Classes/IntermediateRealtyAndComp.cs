namespace DB_993.Classes
{
    public class IntermediateRealtyAndComp
    {
        public int Id { get; set; }
        public int RealtyId { get; set; }
        public Realty? Realty { get; set; }
        public int CompilationId { get; set; }
        public Compilation? Compilation { get; set; }

    }
}
