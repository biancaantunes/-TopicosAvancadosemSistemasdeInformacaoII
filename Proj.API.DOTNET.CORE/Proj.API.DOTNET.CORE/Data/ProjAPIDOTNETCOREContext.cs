using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proj.API.DOTNET.CORE.Model;

namespace Proj.API.DOTNET.CORE.Data
{
    public class ProjAPIDOTNETCOREContext : DbContext
    {
        public ProjAPIDOTNETCOREContext (DbContextOptions<ProjAPIDOTNETCOREContext> options)
            : base(options)
        {
        }

        public DbSet<Proj.API.DOTNET.CORE.Model.Person> Person { get; set; }
    }
}
