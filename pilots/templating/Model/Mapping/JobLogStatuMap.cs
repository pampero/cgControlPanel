using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class JobLogStatuMap : EntityTypeConfiguration<JobLogStatu>
    {
        public JobLogStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.JobLogStatusId);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("JobLogStatus");
            this.Property(t => t.JobLogStatusId).HasColumnName("JobLogStatusId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
