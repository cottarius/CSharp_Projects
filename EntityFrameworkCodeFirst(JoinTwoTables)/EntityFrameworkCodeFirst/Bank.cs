using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityFrameworkCodeFirst
{
    public partial class Bank : DbContext
    {
        public Bank()
            : base("name=Bank")
        {
        }

        public virtual DbSet<BRANCH> BRANCH { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BRANCH>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCH>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCH>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCH>()
                .Property(e => e.STATE)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCH>()
                .Property(e => e.ZIP_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCH>()
                .HasMany(e => e.EMPLOYEE)
                .WithOptional(e => e.BRANCH)
                .HasForeignKey(e => e.ASSIGNED_BRANCH_ID);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .Property(e => e.TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<EMPLOYEE>()
                .HasMany(e => e.EMPLOYEE1)
                .WithOptional(e => e.EMPLOYEE2)
                .HasForeignKey(e => e.SUPERIOR_EMP_ID);
        }
    }
}
