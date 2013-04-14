using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    public class SqlJobMap : EntityTypeConfiguration<SqlJob>
    {
        public SqlJobMap()
        {
            // Primary Key
            this.HasKey(t => t.JobId);

            // Properties
            this.Property(t => t.ServerName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DatabaseName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Password)
                .HasMaxLength(50);

            this.Property(t => t.ExecProcedure)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("SqlJob");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.ServerName).HasColumnName("cProcesoEXECServer");
            this.Property(t => t.DatabaseName).HasColumnName("cProcesoEXECDB");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.ExecProcedure).HasColumnName("cProcesoEXEC");
        }
    }
}
