using Microsoft.EntityFrameworkCore;
using Rig.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rig.Application
{
    public abstract class CommandCrud<T, E>: Command<T> where T : DbContext where E: class, IEntity
    {
        public abstract void Read(T entidade);
    }
}
