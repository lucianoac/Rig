using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rig.Dependencies;
using Rig.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rig.Application
{
    public abstract class Command<T> where T : DbContext
    {
        public virtual string CommandFriendlyName => GetType().Name;

        public CommandExecutionResult Execute(CommandExecutionContext<T> context)
        {
            var userCanExecute = CanExecute(context);

            if (!userCanExecute)
            {
                var msg = $"User {context.User.Name} cannot execute the command ${CommandFriendlyName}";
                return CommandExecutionResult.Fail(msg);
            }

            var validator = CreateValidator();

            var validationContext = new ValidationContext<object>(this);
            var validationResults = validator.Validate(validationContext);

            if (!validationResults.IsValid)
            {
                var joinedErrorMessages = string.Join(Environment.NewLine,
                    validationResults.Errors.Select(x => x.ErrorMessage).ToArray());

                return CommandExecutionResult.Fail(joinedErrorMessages);
            }

            try
            {
                var executionResult = Handle(context);

                if (executionResult.Succeeded && context.Owner == this)
                {
                    context.DbContext.SaveChanges();
                }

                return executionResult;
            }
            catch (Exception ex)
            {
                //Log.Exception("Comando", contexto.Usuario, ex);
                return CommandExecutionResult.Exception(ex);
            }
        }

        public CommandExecutionResult Execute(IUser usuario)
        {
            var dbContext = RigDependencies.GetNewDbContextInstance() as T;
            var context = new CommandExecutionContext<T>(this, dbContext, usuario);
            return Execute(context);
        }

        protected abstract CommandExecutionResult Handle(CommandExecutionContext<T> context);

        protected virtual bool CanExecute(CommandExecutionContext<T> contexto)
        {
            return true;
        }

        public virtual IValidator CreateValidator()
        {
            return new AlwaysValidValidator();
        }
    }
}
