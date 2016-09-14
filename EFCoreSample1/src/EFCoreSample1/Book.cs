using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreSample1
{
    public class Book
    {


        public int BookId { get; set; }
        [StringLength(50)]
        public string Publisher { get; set; }
        public string Title { get; set; }

        [MaxLength(40)]
        public string Isbn { get; set; }
    }
}
