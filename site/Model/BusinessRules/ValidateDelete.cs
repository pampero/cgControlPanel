using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// Compares values of two properties given a data type and operator  (>, ==, etc).
    /// </summary>
    public class ValidateDelete : BusinessRule
    {
        CGControlPanelContext context = new CGControlPanelContext();

        public ValidateDelete (string propertyName)
            : base(propertyName)
        {

            ErrorMessage = "Para eliminar un job/trigger debe asignarle valores a los parámetros DeletedBy y DeletedDate.(Técnico)\r\n";
        }

        public ValidateDelete(string propertyName, string errorMessage)
            : this(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            try
            {
                int keyId = Convert.ToInt32(businessObject.GetType().GetProperty(base.PropertyName).GetValue(businessObject, null));

                // Aún no se ha creado el trigger en la BD, y este es autonumérico.
                if (keyId == 0)
                    return true;

                var deleted = Convert.ToBoolean(businessObject.GetType().GetProperty("Deleted").GetValue(businessObject, null));
                
                if (deleted)
                {
                    var deletedBy = businessObject.GetType().GetProperty("DeletedBy").GetValue(businessObject, null).ToString();

                    DateTime? deletedDate = null;

                    if (businessObject.GetType().GetProperty("DeletedDate").GetValue(businessObject, null) != null)
                        deletedDate = Convert.ToDateTime(businessObject.GetType().GetProperty("DeletedDate").GetValue(businessObject, null));
                
                    if (!String.IsNullOrEmpty(deletedBy) && deletedDate.HasValue)
                        return true;
                }
                
                return false; 
            }
            catch{
                ErrorMessage = "El objeto Trigger no pudo ser encontrado.(Técnico)\r\n";
                return false; }
        }
    }
}
