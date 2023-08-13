using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace Presentation.Helpers
{
    public class DataValidation
    {
        private ValidationContext context;
        private List<ValidationResult> results;
        private bool valid;
        private string message;

        public DataValidation(Object instance)
        {
            context = new ValidationContext(instance);
            results = new List<ValidationResult>();
            valid = Validator.TryValidateObject(instance, context, results, true);

        }
        public bool Validate()
        {
            if (!valid)
            {
                foreach (ValidationResult result in results)
                {
                    message += result.ErrorMessage + "\n";
                }
                MessageBox.Show(message);
            }
            return valid;
        }
    }
}