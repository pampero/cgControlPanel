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

            this.Property(t => t.InputXmlTable)
                .IsOptional()
                .HasMaxLength(250);

             this.Property(t => t.SPID)
                .IsOptional();

            this.Property(t => t.OutputXmlTable)
               .IsOptional()
               .HasMaxLength(8000);

            this.Property(t => t.OutputExecutionResult)
               .IsOptional()
               .HasMaxLength(8000);

            this.Property(t => t.OutputExecutionLog)
               .IsOptional();

            this.Property(t => t.OutputExecutionStatus)
               .IsOptional()
               .HasMaxLength(250);

            this.Property(t => t.RecordsProcessed)
               .IsOptional();

            this.Property(t => t.RecordsAffected)
               .IsOptional();

            this.Property(t => t.OutputExecutionTrace)
              .IsOptional();

            // Table & Column Mappings
            this.ToTable("SqlJobTrigger");
            this.Property(t => t.RecordsProcessed).HasColumnName("nRegistrosProcesados");
            this.Property(t => t.RecordsAffected).HasColumnName("nRegistrosAfectados");
            this.Property(t => t.InputXmlTable).HasColumnName("InputXmlTable");
            this.Property(t => t.OutputXmlTable).HasColumnName("OutputXmlTable");
            this.Property(t => t.OutputExecutionResult).HasColumnName("OutputExecutionResult");
            this.Property(t => t.OutputExecutionTrace).HasColumnName("OutputExecutionTrace");
            this.Property(t => t.SPID).HasColumnName("SPID");
        }
    }
}
