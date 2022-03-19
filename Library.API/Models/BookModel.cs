﻿namespace Library.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookNameAndYear { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int? BorowerId { get; set; }
    }
}
