using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Models
{
    public class BookGetModel : BookModel
    {
        public string BookNameAndYear { get; set; }
    }
}
