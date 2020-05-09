namespace PlottedAssist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HabitatSet")]
    public partial class HabitatSet
    {
        public int Id { get; set; }

        public int AnimalHabitatId { get; set; }

        public int PlantId { get; set; }

        public virtual AnimalHabitatSet AnimalHabitatSet { get; set; }

        public virtual PlantSet PlantSet { get; set; }
    }
}
