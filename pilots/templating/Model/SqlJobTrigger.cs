using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Model
{
    public class SqlJobTrigger : JobTrigger
    {

        public int RecordsProcessed { get; set; }
        public int RecordsAffected { get; set; }
        public string XmlFormInputValues { get; set; }
        public string XmlTableInput { get; set; }
        public string XmlTableOutput { get; set; }
        public string XmlResult { get; set; }
        public string XmlLog { get; set; }
    }
}
