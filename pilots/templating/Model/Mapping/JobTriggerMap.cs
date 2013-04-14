using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    public class JobTriggerMap : EntityTypeConfiguration<JobTrigger>
    {
        public JobTriggerMap()
        {
            // Primary Key
            this.HasKey(t => t.JobTriggerId);

            // Properties
            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SerializedJob)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.SerializedJob)
                    .IsOptional()
                    .HasMaxLength(8000);

            // Table & Column Mappings
            this.ToTable("JobTrigger");
            this.Property(t => t.JobTriggerId).HasColumnName("JobTriggerId");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.JobTriggerStatusEnum).HasColumnName("JobTriggerStatusEnum");
            this.Property(t => t.StartExecutionDate).HasColumnName("StartExecutionDate");
            this.Property(t => t.EndExecutionDate).HasColumnName("EndExecutionDate");
            this.Property(t => t.SerializedJob).HasColumnName("SerializedJob");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Enabled).HasColumnName("Enabled");
            this.Property(t => t.Enabled).HasColumnName("ExecutionLog");

            // Relationships
            this.HasRequired(t => t.Job)
                .WithMany(t => t.Triggers)
                .HasForeignKey(d => d.JobId).WillCascadeOnDelete(false);
        }
    }
}