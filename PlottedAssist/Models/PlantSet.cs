namespace PlottedAssist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlantSet")]
    public partial class PlantSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlantSet()
        {
            UserPlantSet = new HashSet<UserPlantSet>();
            WeedSet = new HashSet<WeedSet>();
        }

        public int Id { get; set; }

        [Required]
        public string PlantCommonName { get; set; }

        [Required]
        public string PlantSciName { get; set; }

        [Required]
        public string PlantPhotoPath { get; set; }

        [Required]
        public string PlantType { get; set; }

        [Required]
        public string PlantSpring { get; set; }

        [Required]
        public string PlantSummer { get; set; }

        [Required]
        public string PlantAutumn { get; set; }

        [Required]
        public string PlantWinter { get; set; }

        [Required]
        public string PlantDesc { get; set; }

        [Required]
        public string PlantFlowersPath { get; set; }

        [Required]
        public string PlantFlowerColors { get; set; }

        [Required]
        public string PlantSunNeedPath { get; set; }

        [Required]
        public string PlantWaterFrq { get; set; }

        [Required]
        public string PlantPruningFrq { get; set; }

        [Required]
        public string PlantFertilizerFrq { get; set; }

        [Required]
        public string PlantMistFrq { get; set; }

        [Required]
        public string PlantSoilSand { get; set; }

        [Required]
        public string PlantSoilClay { get; set; }

        [Required]
        public string PlantSoilLoom { get; set; }

        [Required]
        public string PlantHabitat { get; set; }

        [Required]
        public string PlantDroughtTol { get; set; }

        [Required]
        public string PlantCompanion { get; set; }

        [Required]
        public string PlantBird { get; set; }

        [Required]
        public string PlantButterfly { get; set; }

        [Required]
        public string PlantBees { get; set; }

        [Required]
        public string PlantInsects { get; set; }

        [Required]
        public string PlantLarve { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserPlantSet> UserPlantSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeedSet> WeedSet { get; set; }
    }
}
