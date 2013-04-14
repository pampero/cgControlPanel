using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class JobTypeMap : EntityTypeConfiguration<JobType>
    {
        public JobTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.JobTypeId);

            // Properties
            // Table & Column Mappings
            this.ToTable("JobType");
            this.Property(t => t.JobTypeId).HasColumnName("JobTypeId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
