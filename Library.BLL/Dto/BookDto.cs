using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int BorrowerId { get; set; }
    }
}
