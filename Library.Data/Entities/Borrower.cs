using System.Collections.Generic;

namespace Library.Data.Models
{
    public class Borower
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Book> Books { get; set; }
    }
}
