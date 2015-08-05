namespace MakokeroData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MakokeroContext : DbContext
    {
        public MakokeroContext()
            : base("name=MakokeroContext")
        {
        }

        public virtual DbSet<EventOwner> EventOwners { get; set; }
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventOwner>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.EventOwner)
                .WillCascadeOnDelete(false);
        }
    }
}
