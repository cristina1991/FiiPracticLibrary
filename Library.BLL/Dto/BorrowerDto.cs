﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BLL.Dto
{
    public class BorrowerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<BookDto> Books { get; set; }
    }
}
