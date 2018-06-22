using NWind.DAL;
using NWind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWind.Business
{
    public class CategoryBusiness
    {
        public Categories Create(Categories newCategory)
        {
            using (var r = RepositoryFactory.CreateRepository())
            {
                newCategory = r.Create(newCategory);
            }
            return newCategory;
        }
    }

}
