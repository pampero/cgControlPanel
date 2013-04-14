using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Quartz;

namespace Model
{
    public class SqlScheduledJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var unitofWork = new UnitOfWork();
            var triggerId = context.JobDetail.JobDataMap["TriggerId"];
            var trigger = (SqlJobTrigger)unitofWork.JobTriggerRepository.GetByID(triggerId);
            var job = (SqlJob) trigger.Job;
            SqlConnection conn = null;
           
            try
            {
                //var connectionString = @"data source=.\SQLEXPRESS;Integrated Security=false;user id=sa;password=123456;User Instance=false;Initial Catalog=cgControlPanel2";
                var connectionString = @"data source=" + job.ServerName + ";Integrated Security=false;user id=" +
                                       job.UserName +
                                       ";password=" + job.Password + ";User Instance=false;Initial Catalog=" +
                                       job.DatabaseName;
                conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    job.ExecProcedure, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.Add("@xInput", SqlDbType.Xml).Value =
                    new SqlXml(new XmlTextReader(trigger.XmlFormInputValues, XmlNodeType.Document, null));
                cmd.Parameters.Add("@xOutput", SqlDbType.Xml).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@xResultado", SqlDbType.Xml).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@xLogEjecucion", SqlDbType.Xml).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@nRowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@nRowsTotal", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                trigger.XmlTableOutput = cmd.Parameters["@xOutput"].Value.ToString();
                trigger.XmlResult = cmd.Parameters["@xResultado"].Value.ToString();
                trigger.XmlLog = cmd.Parameters["@xLogEjecucion"].Value.ToString();
                trigger.RecordsAffected = int.Parse(cmd.Parameters["@nRowsAffected"].Value.ToString());
                trigger.RecordsProcessed = int.Parse(cmd.Parameters["@nRowsTotal"].Value.ToString());
                job.JobStatusEnum = (int)JobStatus.Success;
                //unitofWork.JobsRepository.Update(job);
                unitofWork.JobTriggerRepository.Update(trigger);
                unitofWork.Save();
            }
            catch(Exception e)
            {
                var ex = e.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }	
        }
    }
}
