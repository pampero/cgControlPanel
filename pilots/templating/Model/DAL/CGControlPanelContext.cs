using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Model.Mapping;
using Model.Mapping;

namespace Model
{
    public class CGControlPanelContext : DbContext
    {
        static CGControlPanelContext()
        {
            // Cuidado, si se descomenta genera la base de datos del connectionstring "CGControlPanelContext"
            // Solo usar cuando se modifica el modelo, cambiar para que apunte a otra base de datos y luego copiar el script.
            // Database.SetInitializer<CGControlPanelContext>(new CGControlPanelInitializer());
        }

        public CGControlPanelContext()
            : base("Name=cgControlPanelContext")
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobLog> JobLogs { get; set; }
        public DbSet<JobTrigger> JobTriggers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new JobLogMap());
            modelBuilder.Configurations.Add(new JobTriggerMap());
            modelBuilder.Configurations.Add(new SqlJobMap());
            modelBuilder.Configurations.Add(new SqlJobTriggerMap());
        }
    }
}
