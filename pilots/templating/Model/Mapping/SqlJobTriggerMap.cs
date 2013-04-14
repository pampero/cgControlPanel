using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Model.Mapping
{
    public class SqlJobTriggerMap : EntityTypeConfiguration<SqlJobTrigger>
    {
        public SqlJobTriggerMap()
        {
            // Primary Key
            this.HasKey(t => t.JobTriggerId);

            this.Property(t => t.XmlTableInput)
                .IsOptional()
                .HasMaxLength(250);

            this.Property(t => t.XmlTableOutput)
               .IsOptional()
               .HasMaxLength(8000);

            this.Property(t => t.XmlResult)
               .IsOptional()
               .HasMaxLength(8000);

            this.Property(t => t.XmlLog)
               .IsOptional()
               .HasMaxLength(8000);

            this.Property(t => t.RecordsProcessed)
               .IsOptional();


            this.Property(t => t.RecordsAffected)
               .IsOptional();

            // Table & Column Mappings
            this.ToTable("SqlJobTrigger");
            this.Property(t => t.RecordsProcessed).HasColumnName("nRegistrosProcesados");
            this.Property(t => t.RecordsAffected).HasColumnName("nRegistrosAfectados");
            this.Property(t => t.XmlTableInput).HasColumnName("XmlTableInput");
            this.Property(t => t.XmlTableOutput).HasColumnName("XmlTableOutput");
            this.Property(t => t.XmlResult).HasColumnName("XmlResult");
            this.Property(t => t.XmlLog).HasColumnName("XmlLog");
        }
    }
}
