namespace PlottedAssist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserPlantSet")]
    public partial class UserPlantSet
    {
        public int Id { get; set; }

        public int PlantId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string plantNickName { get; set; }

        [Required]
        public string PlantWaterFrq { get; set; }

        [Required]
        public string PlantPruningFrq { get; set; }

        [Required]
        public string PlantFertilizerFrq { get; set; }

        [Required]
        public string PlantMistFrq { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public string Active { get; set; }

        public virtual PlantSet PlantSet { get; set; }
    }
}
