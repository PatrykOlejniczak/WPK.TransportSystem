using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Common.Validators
{
    public class Validatable
    {
        protected IValidator Validator = null;
        protected IEnumerable<ValidationFailure> ValidationFailures;

        protected virtual IValidator GetValidator()
        {
            return null;
        }

        public IEnumerable<ValidationFailure> ValidityErrors
        {
            get {  return ValidationFailures; }
            set { ValidationFailures = value; }
        }

        public void Validate()
        {
            if (Validator != null)
            {
                ValidationResult results = Validator.Validate(this);
                ValidityErrors = results.Errors;
            }
        }

        public virtual bool IsValid
        {
            get
            {
                if (ValidityErrors != null && ValidityErrors.Count() > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}