using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    ///  Length validation rule. 
    ///  Length must be between given min and max values.
    /// </summary>
    public class ValidateLength : BusinessRule
    {
        private int _min;
        private int _max;

        public ValidateLength(string propertyName, int min, int max)
            : base(propertyName)
        {
            _min = min;
            _max = max;

            ErrorMessage = propertyName + " debe tener entre " + _min + " y " + _max + " caracteres de longitud.(Técnico)\r\n";
        }

        public ValidateLength(string propertyName, string errorMessage, int min, int max)
            : this(propertyName, min, max)
        {
            ErrorMessage = errorMessage;
        }

        public override bool Validate(BusinessObject businessObject)
        {
            int length = GetPropertyValue(businessObject).ToString().Length;
            return length >= _min && length <= _max;
        }
    }
}
