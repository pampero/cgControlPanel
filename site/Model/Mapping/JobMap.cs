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

            this.Property(t => t.CreatedDate)
                .IsRequired();

            this.Property(t => t.InputSchemaProcedure)
                    .IsOptional()
                    .HasMaxLength(255);

             this.Property(t => t.InputXmlFixedParameters)
                    .IsOptional()
                    .HasMaxLength(8000);

            this.Property(t => t.AutomaticProcessTime)
                .IsOptional();
            
            this.Property(t => t.DeletedBy)
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("Job");
            this.Property(t => t.JobId).HasColumnName("JobId");
            this.Property(t => t.SecurityLevel).HasColumnName("nNivelDeUso");
            this.Property(t => t.JobTypeEnum).HasColumnName("ctEjecucionEnum");
            this.Property(t => t.AutomaticProcessTime).HasColumnName("AutomaticProcessTime");
            this.Property(t => t.SecurityLevel).HasColumnName("nNivel");
            this.Property(t => t.IsFavorite).HasColumnName("lFavorito");
            this.Property(t => t.IsGeneral).HasColumnName("lGeneral");
            this.Property(t => t.Group).HasColumnName("cdGrupo");
            this.Property(t => t.Name).HasColumnName("cdProceso");
            this.Property(t => t.Description).HasColumnName("cdDescripcion");
            this.Property(t => t.Comments).HasColumnName("cComentario");
            this.Property(t => t.InputXmlFixedParameters).HasColumnName("xInputFixedParameters");
            this.Property(t => t.InputSchemaProcedure).HasColumnName("cConfigFormInputProcedure");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("dDateIns");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.DeletedBy).HasColumnName("DeletedBy");
            this.Property(t => t.DeletedDate).HasColumnName("DeletedDate");
            this.Property(t => t.Weekdays).HasColumnName("WeekDays");
            this.Property(t => t.ParentJobId).HasColumnName("ParentJobId");
            // Relationships
        //    this.HasOptional(t => t.ParentJob)
         //       .HasForeignKey(d => d.JobId).WillCascadeOnDelete(false);
        }
    }
}
