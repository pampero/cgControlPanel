using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Model
{
    public class CGControlPanelInitializer : DropCreateDatabaseIfModelChanges<CGControlPanelContext>
    {
        protected override void Seed(CGControlPanelContext context)
        {
            try
            {
                var notifications = new List<Notification> {
                    new Notification { Checked = false, Comments = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.", ProcessName = "Proceso Automatico 2", UserName = "admin", TriggerId = 65 , CreatedDate = DateTime.Now, Status = "I"},
                    new Notification { Checked = false, Comments = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.", ProcessName = "Proceso Manual 1 (c/dialogo)", UserName = "admin", TriggerId = 243 , CreatedDate = DateTime.Now, Status = "E"},
                    new Notification { Checked = true, CheckedDate = DateTime.Now, Comments = "Comentario 3", ProcessName = "Proceso Automatico", UserName = "admin", TriggerId = 54, CreatedDate = DateTime.Now , Status = "W"},
                    new Notification { Checked = false, Comments = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod .", ProcessName = "Proceso Manual 1 (c/dialogo)", UserName = "admin", TriggerId = 43 , CreatedDate = DateTime.Now.AddDays(-2).AddMinutes(120), Status = "W"},
                    new Notification { Checked = false, Comments = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.", ProcessName = "Proceso Manual 1 (c/dialogo)", UserName = "admin", TriggerId = 43 , CreatedDate = DateTime.Now.AddDays(-4).AddMinutes(240), Status = "W"},
                    new Notification { Checked = false, Comments = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt.", ProcessName = "Proceso Manual 1 (c/dialogo)", UserName = "admin", TriggerId = 243 , CreatedDate = DateTime.Now.AddDays(-3).AddMinutes(10), Status = "E"},
                    new Notification { Checked = false, Comments = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.", ProcessName = "Proceso Manual 1 (c/dialogo)", UserName = "admin", TriggerId = 43 , CreatedDate = DateTime.Now.AddDays(-4).AddMinutes(240), Status = "W"},
                    new Notification { Checked = false, Comments = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt.", ProcessName = "Proceso Manual 1 (c/dialogo)", UserName = "admin", TriggerId = 243 , CreatedDate = DateTime.Now.AddDays(-3).AddMinutes(10), Status = "I"},
                };

                notifications.ForEach(s => context.Notifications.Add(s));
                context.SaveChanges();

                string serverTest;
                string userTest;
                string passwordTest;
                
                try
                {
                    serverTest = ConfigurationManager.AppSettings["ServerTest"];
                    userTest = ConfigurationManager.AppSettings["UserTest"];
                    passwordTest = ConfigurationManager.AppSettings["PasswordTest"];
                }
                catch (Exception)
                {
                    
                    throw new Exception("Los campos de server, user y password son obligatorios (CGControlPanelInitializer)");
                }
                
                var jobs = new List<SqlJob>
                                {
                                    new SqlJob { DatabaseName="cgControlPanel", ExecProcedure="OP_PROCESO_EJEMPLO_EXEC", InputSchemaProcedure="OP_PROCESO_EJEMPLO_CONFIG", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Description = "Descripción del Proceso Manual con diálogo", JobType = JobType.Manual, IsFavorite=true, IsGeneral=true, Name = "Proceso Manual 1 (c/diálogo)", Group="Procesos Manuales", ParentJobId=0, Comments = "Este proceso es un proceso con todas las características de la aplicación.\r\nEs decir:\r\n-Entrada: al ser manual (y con Stored Procedure de configuración) posee formulario dinámico de carga manual. No posee datos tabulados de entrada.\r\n-Salida: retorna datos tabulados, resultados y log de ejecución. No retorna trace por el momento.", InputXmlFixedParameters= @"<INPUTXMLFIXEDPARAMETERS><CIUDAD>
Buenos Aires
</CIUDAD>
<PARTIDO>
Pehuajó
</PARTIDO></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgControlPanel", ExecProcedure="OP_PROCESO_EJEMPLO_EXEC", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Description = "Descripción del Proceso Automático sin diálogo", JobType = JobType.Automático, IsFavorite=true, IsGeneral=true, Name = "Proceso Automático 1", Group="Procesos Automáticos", ParentJobId=1, Comments = "Este proceso al ser manual no tiene formulario dinámico de entrada de datos, aunque podría tener datos fijos en este caso no los tiene, tampoco datos de entrada tabulados. La salida retorna datos tabulados, resultados y log de ejecución. No retorna trace por el momento.", AutomaticProcessTime=DateTime.Now, InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgControlPanel", ExecProcedure="OP_PROCESO_DIVBYZERO_EXEC", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Description = "Este proceso genera un error al dividir por cero.", JobType = JobType.Automático, IsFavorite=true, IsGeneral=true, Name = "Proceso Error Divide por Cero", Group="Procesos Automáticos", ParentJobId=2, Comments = "Utilizarlo para validar si genera correctamente el error y si este se loguea en el archivo de logs que está configurado en el archivo de xml \"Log4Net.xml\"" , AutomaticProcessTime=DateTime.Now, InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgControlPanel", ExecProcedure="OP_PROCESO_WRONGPARAMETERS_EXEC", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Description = "Este proceso genera un error al enviar un parametro menos.", JobType = JobType.Automático, IsFavorite=true, IsGeneral=true, Name = "Proceso Error Diferencia de Parámetros", Group="Procesos Automáticos", ParentJobId=1, Comments = "Utilizarlo para validar si genera correctamente el error (el Stored Procedure posee un parametro menos) y si este se loguea en el archivo de logs que está configurado en el archivo de xml \"Log4Net.xml\"", AutomaticProcessTime=DateTime.Now , InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgQuartz", ExecProcedure="OP_PROCESO_QUARTZ_EXEC", InputSchemaProcedure="OP_PROCESO_QUARTZ_CONFIG", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Description = "Descripción del Proceso Manual", JobType = JobType.Manual, IsFavorite=true, IsGeneral=true, Name = "Proceso Manual 2 (c/diálogo)", Group="Procesos Manuales", ParentJobId=1, InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgQuartz", ExecProcedure="OP_PROCESO_QUARTZ_EXEC",  UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Description = "Descripción del Proceso Automático", JobType = JobType.Automático, IsFavorite=true, IsGeneral=true, Name = "Proceso Automático 2", Group="Procesos Automáticos", ParentJobId=1, AutomaticProcessTime=DateTime.Now, InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgQuartz", ExecProcedure="OP_PROCESO_QUARTZ_EXEC", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Description = "Descripción del Proceso Manual", JobType = JobType.Manual, IsFavorite=true, IsGeneral=true, Name = "Proceso Manual 3 (s/diálogo)", Group="Procesos Manuales", ParentJobId=1, Comments = "Este proceso al ser manual no tiene formulario dinámico de entrada de datos, aunque podría tener datos fijos en este caso no los tiene, tampoco datos de entrada tabulados. La salida retorna resultados y log de ejecución. No retorna trace por el momento ni datos tabulados.", InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgQuartz", ExecProcedure="OP_PROCESO_QUARTZ_EXEC", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Weekdays = 127, Description = "Descripción del Proceso Automático", JobType = JobType.Automático, Name = "Proceso Automático 3 (visualiza solo diario)", Group="Procesos Automáticos", ParentJobId=2, AutomaticProcessTime=DateTime.Now, InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS><CIUDAD>Pehuajó</CIUDAD></INPUTXMLFIXEDPARAMETERS>"},
                                    new SqlJob { DatabaseName="cgQuartz", ExecProcedure="OP_PROCESO_QUARTZ_TIMED_EXEC", UserName=userTest, Password=passwordTest, ServerName = @serverTest, CreatedBy = "CVazquez", CreatedDate = DateTime.Now, Deleted = false, Weekdays = 127, Description = "Descripción del Proceso Automático", JobType = JobType.Automático, Name = "Proceso Automático 4 (proceso larga duración)", Group="Procesos Automáticos", ParentJobId=6, AutomaticProcessTime=DateTime.Now, InputXmlFixedParameters = @"<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>"}
                                };

                jobs.ForEach(s => context.Jobs.Add(s));

                context.SaveChanges();

                var job = context.Jobs.SingleOrDefault(x => x.JobId == 1);
                var job2 = context.Jobs.SingleOrDefault(x => x.JobId == 5);
                var job3 = context.Jobs.SingleOrDefault(x => x.JobId == 7);

                var jobTriggers = new List<JobTrigger>
                                      {
                                          new SqlJobTrigger
                                              {
                                                  CreatedBy = "cvazquez",
                                                  Job = job,
                                                  CreatedDate = DateTime.Now,
                                                  JobTriggerStatus = JobTriggerStatus.Agendado,
                                                  Enabled = true,
                                                  Deleted = false,
                                                  ScheduledStartExecutionDate = DateTime.Now
                                              },
                                        
                                         new SqlJobTrigger
                                         {
                                             RecordsProcessed = 10,
                                             CreatedBy = "cvazquez",
                                             Job = job3,
                                             CreatedDate = DateTime.Now,
                                             JobTriggerStatus = JobTriggerStatus.Agendado,
                                             Enabled = true,
                                             Deleted = false,
                                             ScheduledStartExecutionDate =  DateTime.Now
                                         }
                                 };

                jobTriggers.ForEach(s => context.JobTriggers.Add(s));
                context.SaveChanges();
            }
            catch (Exception exception)
            {

                throw;
            }

        }
    }
}
