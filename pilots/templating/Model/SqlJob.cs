using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;


namespace Model
{
    public class SqlJob : Job
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ExecProcedure { get; set; }

        //public override string ToString()
        //{
        //    return "<NAME>" + Name + "</NAME><GROUPNAME>" + Group + "</GROUPNAME><INPUTSCHEMAPROCEDURE>" +  InputSchemaProcedure + "</INPUTSCHEMAPROCEDURE><FIXEDPARAMETERSPROCEDURE>" + FixedParametersProcedure + "</FIXEDPARAMETERSPROCEDURE><SERVERNAME>" + ServerName + "</SERVERNAME><DATABASENAME>" + DatabaseName +
        //           "<DATABASENAME><USERNAME>" + UserName + "</USERNAME><EXECPROCEDURE>" + ExecProcedure +
        //           "</EXECPROCEDURE><CREATEDBY>" + CreatedBy + "</CREATEDBY><SCHED_NAME>" + SCHED_NAME + "</SCHED_NAME><JOB_NAME>" + JOB_NAME + "</JOB_NAME><JOB_GROUP>" + JOB_GROUP + "</JOB_GROUP>";
        //}
    }
}

