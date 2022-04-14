using System.Collections.Generic;

namespace Library.Data.Entities
{
    public class Borrower
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
    }
}
