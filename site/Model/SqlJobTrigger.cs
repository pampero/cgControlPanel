using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Model;

namespace Model
{
    public class SqlJobTrigger : JobTrigger
    {
        public string SPID { get; set; }
        public int RecordsProcessed { get; set; }
        public int RecordsAffected { get; set; }
        public string OutputExecutionTrace { get; set; }
        public string InputFormXmlValues { get; set; }
        [MaxLength]
        public string InputXmlTable { get; set; }
        [MaxLength]
        public string OutputXmlTable { get; set; }
        public string OutputExecutionResult { get; set; }
        public string OutputExecutionStatus { get; set; }
    }
}
