using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rig.Application
{
    internal class AlwaysValidValidator : IValidator
    {
        public bool CanValidateInstancesOfType(Type type) { return true; }

        public IValidatorDescriptor CreateDescriptor()
        {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(IValidationContext context)
        {
            return new ValidationResult();
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            return Task.FromResult(new ValidationResult());
        }
    }
}
