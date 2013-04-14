using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// Compares values of two properties given a data type and operator  (>, ==, etc).
    /// </summary>
    public class ValidateSchedule : BusinessRule
    {
        CGControlPanelContext context = new CGControlPanelContext();
        private string OtherPropertyName { get; set; }

        public ValidateSchedule(string propertyName, string otherPropertyName)
            : base(propertyName)
        {
            
            OtherPropertyName = otherPropertyName;


            ErrorMessage = "La fecha y hora deben ser mayor a la actual si es automático o la fecha mayor o igual a la actual si es manual.\r\n";
        }

        public ValidateSchedule(string propertyName, string otherPropertyName, string errorMessage)
            : this(propertyName, otherPropertyName)
        {
            ErrorMessage = errorMessage;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                bool deleted = Convert.ToBoolean(businessObject.GetType().GetProperty("Deleted").GetValue(businessObject, null));

                if (deleted) return true;

                string scheduledStringStartExecutionDate = businessObject.GetType().GetProperty(PropertyName).GetValue(businessObject, null).ToString();
                int jobId = Convert.ToInt32(businessObject.GetType().GetProperty(OtherPropertyName).GetValue(businessObject, null));
                
                var job = context.Jobs.SingleOrDefault(x => x.JobId == jobId && !x.Deleted);

                DateTime scheduledStartExecutionDate = DateTime.Parse(scheduledStringStartExecutionDate);
                DateTime now = DateTime.Now;

                // Se le suma un minuto sino genera error
                if (job.JobType == JobType.Automático && scheduledStartExecutionDate.AddMinutes(1) >= now)
                    return true;

                if (job.JobType == JobType.Manual && scheduledStartExecutionDate.Date >= now.Date)
                    return true;

                return false; 
            }
            catch{
                ErrorMessage = "El objeto Trigger no contiene la referencia la objeto Job al que pertenece.(Técnico)\r\n";                     
                return false; 
            }
        }
    }
}
