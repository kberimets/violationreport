namespace ViolationReportLib.Db
{
    using System.Data.Entity;

    public partial class OikDbContext : DbContext
    {
        public OikDbContext()
            : base("name=OikDbContext")
        {
        }

        public virtual DbSet<AllTI> AllTI { get; set; }
        public virtual DbSet<EnObj> EnObj { get; set; }
        public virtual DbSet<UDef> UDef { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllTI>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AllTI>()
                .Property(e => e.Abbr)
                .IsUnicode(false);

            modelBuilder.Entity<AllTI>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<EnObj>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EnObj>()
                .Property(e => e.Abbr)
                .IsUnicode(false);

            modelBuilder.Entity<UDef>()
                .Property(e => e.OP_OI)
                .IsUnicode(false);

            modelBuilder.Entity<UDef>()
                .Property(e => e.NPP_OI)
                .IsUnicode(false);

            modelBuilder.Entity<UDef>()
                .Property(e => e.VPP_OI)
                .IsUnicode(false);

            modelBuilder.Entity<UDef>()
                .Property(e => e.Phase)
                .IsUnicode(false);
        }
    }
}
