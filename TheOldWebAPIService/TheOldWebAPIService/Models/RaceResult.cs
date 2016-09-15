namespace TheOldWebAPIService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaceResult
    {
        public int Id { get; set; }

        public int RaceId { get; set; }

        public int RacerId { get; set; }

        public int TeamId { get; set; }

        public int Position { get; set; }

        public int? Number { get; set; }

        public int? Grid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Points { get; set; }

        public TimeSpan? Time { get; set; }

        public int? Laps { get; set; }

        [StringLength(50)]
        public string Retired { get; set; }

        public virtual Race Race { get; set; }

        public virtual Racer Racer { get; set; }
    }
}
