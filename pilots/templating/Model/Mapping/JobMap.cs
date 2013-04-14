using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Mapping
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            // Primary Key
            this.HasKey(t => t.JobId);

            // Properties
            this.Property(t => t.Group)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(70);

            this.Property(t => t.Description)
                .HasMaxLength(500);

             this.Property(t => t.Comments)
                .HasMaxLength(1000);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.InputSchemaProcedure)
                    .IsOptional()
                    .HasMaxLength(255);

             this.Property(t => t.FixedParametersProcedure)
                    .IsOptional()
                    .HasMaxLength(8000);
 
            this.Property(t => t.SCHED_NAME)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.JOB_NAME)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.JOB_GROUP)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.DeletedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Job");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.JobTypeEnum).HasColumnName("ctEjecucionEnum");
            this.Property(t => t.ExecutionDays).HasColumnName("ExecutionDays");
            this.Property(t => t.JobStatusEnum).HasColumnName("JobStatusEnum");
            this.Property(t => t.LastExecutionStatusEnum).HasColumnName("LastExecutionStatusEnum");
            this.Property(t => t.IsFavorite).HasColumnName("lFavorito");
            this.Property(t => t.IsDaily).HasColumnName("lDiario");
            this.Property(t => t.Group).HasColumnName("cdGrupo");
            this.Property(t => t.Name).HasColumnName("cdProceso");
            this.Property(t => t.Description).HasColumnName("cdDescripcion");
            this.Property(t => t.Comments).HasColumnName("cComentario");
            this.Property(t => t.FixedParametersProcedure).HasColumnName("cConfigFormInputFixed");
            this.Property(t => t.InputSchemaProcedure).HasColumnName("cConfigFormInputProcedure");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("dDateIns");
            this.Property(t => t.SCHED_NAME).HasColumnName("SCHED_NAME");
            this.Property(t => t.JOB_NAME).HasColumnName("JOB_NAME");
            this.Property(t => t.JOB_GROUP).HasColumnName("JOB_GROUP");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.DeletedBy).HasColumnName("DeletedBy");
            this.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        }
    }
}
