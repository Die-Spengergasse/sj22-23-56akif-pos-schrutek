using Microsoft.EntityFrameworkCore;
using Spg.Sayonara.DomainModel.Model;
using Spg.Sayonara.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.Sayonara.DomainModel.Test
{
    public class UnitTestContext : SayonaraContext
    {
        public DbSet<Category> Categories => Set<Category>();

        public UnitTestContext(DbContextOptions options)
            : base(options)
        { }
    }
}
