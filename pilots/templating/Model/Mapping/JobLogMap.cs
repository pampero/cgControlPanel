using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    public class JobLogMap : EntityTypeConfiguration<JobLog>
    {
        public JobLogMap()
        {
            // Primary Key
            this.HasKey(t => t.JobLogId);

            // Properties
            this.Property(t => t.InputValue)
                .IsRequired();

            this.Property(t => t.OutputValue)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("JobLog");
            this.Property(t => t.JobLogId).HasColumnName("JobLogId");
            this.Property(t => t.JobTriggerId).HasColumnName("JobTriggerId").IsOptional();
            this.Property(t => t.JobId).HasColumnName("JobId").IsOptional();
            this.Property(t => t.InputValue).HasColumnName("InputValue").IsOptional();
            this.Property(t => t.OutputValue).HasColumnName("OutputValue").IsOptional();
            this.Property(t => t.ExecutionDate).HasColumnName("ExecutionDate").IsOptional();
            this.Property(t => t.JobLogStatusEnum).HasColumnName("JobLogStatusEnum").IsOptional();

            // Relationships
            this.HasRequired(t => t.Job)
               .WithMany(t => t.Logs)
               .HasForeignKey(d => d.JobId);
          
            this.HasRequired(t => t.JobTrigger)
                .WithMany(t => t.JobLogs)
                .HasForeignKey(d => d.JobTriggerId);

        }
    }
}
