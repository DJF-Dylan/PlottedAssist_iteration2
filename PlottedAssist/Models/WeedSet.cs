namespace PlottedAssist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeedSet")]
    public partial class WeedSet
    {
        public int Id { get; set; }

        public int PlantId { get; set; }

        [Required]
        public string WeedCommonName { get; set; }

        [Required]
        public string WeedSciName { get; set; }

        [Required]
        public string WeedPhotoPath { get; set; }

        [Required]
        public string WeedDesc { get; set; }

        [Required]
        public string WeedFlowerColor { get; set; }

        [Required]
        public string WeedControl { get; set; }

        public virtual PlantSet PlantSet { get; set; }
    }
}
