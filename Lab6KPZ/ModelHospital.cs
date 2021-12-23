using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab6KPZ
{
    public partial class ModelHospital : DbContext
    {
        public ModelHospital()
            : base("name=ModelHospital")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<DrugStorage> DrugStorages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Doctor>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();
        }
    }
}
