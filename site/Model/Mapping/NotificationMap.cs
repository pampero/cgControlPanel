using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    public class NotificationMap : EntityTypeConfiguration<Notification>
    {
        public NotificationMap()
        {
            // Primary Key
            this.HasKey(t => t.NotificationId);

            // Properties
            this.Property(t => t.Comments)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.ProcessName)
                .IsRequired()
                .HasMaxLength(70);

           this.Property(t => t.CreatedDate)
                .IsRequired();

           this.Property(t => t.Status)
              .IsRequired();

            // Table & Column Mappings
            this.ToTable("Notification");
            this.Property(t => t.NotificationId).HasColumnName("NotificationId");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.ProcessName).HasColumnName("ProcessName");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Checked).HasColumnName("Checked");
            this.Property(t => t.CheckedDate).HasColumnName("CheckedDate");
            this.Property(t => t.TriggerId).HasColumnName("TriggerId");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
