using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWind.DAL
{
    public class RepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            var context = new NWindEntities();
            context.Configuration.ProxyCreationEnabled = false;
            return new EFRepository(context);
        }
    }
}
