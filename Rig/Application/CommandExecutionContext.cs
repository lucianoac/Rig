using Microsoft.EntityFrameworkCore;
using Rig.Security;

namespace Rig.Application
{
    public class CommandExecutionContext<T> where T : DbContext
    {
        public Command<T> Owner { get; set; }
        public T DbContext { get; }
        public IUser User { get; }

        public CommandExecutionContext(Command<T> owner, T dbContext, IUser user)
        {
            Owner = owner;
            DbContext = dbContext;
            User = user;
        }
    }
}