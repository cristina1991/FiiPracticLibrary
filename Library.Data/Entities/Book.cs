namespace Library.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int? BorowerId { get; set; }
    }
}
