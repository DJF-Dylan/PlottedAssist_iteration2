namespace PlottedAssist.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProjectModel : DbContext
    {
        public ProjectModel()
            : base("name=ProjectModel")
        {
        }

        public virtual DbSet<PlantSet> PlantSet { get; set; }
        public virtual DbSet<UserPlantSet> UserPlantSet { get; set; }
        public virtual DbSet<WeedSet> WeedSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantSet>()
                .HasMany(e => e.UserPlantSet)
                .WithRequired(e => e.PlantSet)
                .HasForeignKey(e => e.PlantId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlantSet>()
                .HasMany(e => e.WeedSet)
                .WithRequired(e => e.PlantSet)
                .HasForeignKey(e => e.PlantId)
                .WillCascadeOnDelete(false);
        }
    }
}
