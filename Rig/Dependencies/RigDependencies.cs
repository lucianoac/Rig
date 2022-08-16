using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rig.Dependencies
{
    public static class RigDependencies
    {
        private static Func<DbContext> _dbContextProvider;
     
        public static DbContext GetNewDbContextInstance()
        {
            var createInstance = GetDbContextProvider();
            var dbContext = createInstance();
            return dbContext;
        }

        private static Func<DbContext> GetDbContextProvider()
        {
            if (_dbContextProvider == null)
            {
                throw new Exception();
            }
            return _dbContextProvider;
        }

        public static void Init(Func<DbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

    }
}
