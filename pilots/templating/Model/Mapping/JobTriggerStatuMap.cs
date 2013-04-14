using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class JobTriggerStatuMap : EntityTypeConfiguration<JobTriggerStatu>
    {
        public JobTriggerStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.JobTriggerStatusId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("JobTriggerStatus");
            this.Property(t => t.JobTriggerStatusId).HasColumnName("JobTriggerStatusId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
