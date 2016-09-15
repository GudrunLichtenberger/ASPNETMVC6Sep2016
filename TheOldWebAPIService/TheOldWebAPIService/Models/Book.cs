namespace TheOldWebAPIService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int BookId { get; set; }

        [StringLength(50)]
        public string Publisher { get; set; }

        [StringLength(40)]
        public string Title { get; set; }
    }
}
