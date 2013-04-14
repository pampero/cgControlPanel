using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class JobStatuMap : EntityTypeConfiguration<JobStatu>
    {
        public JobStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.JobStatusId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("JobStatus");
            this.Property(t => t.JobStatusId).HasColumnName("JobStatusId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
