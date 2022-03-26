using System.Collections.Generic;

namespace Library.API.Models
{
    public class BorrowerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<BookModel> Books { get; set; }

    }
}
