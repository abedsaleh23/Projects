using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GProject2.Models;

namespace GProject2.Data
{
    public class CoachDBContext : DbContext
    {
        public CoachDBContext (DbContextOptions<CoachDBContext> options)
            : base(options)
        {
        }

        public DbSet<GProject2.Models.Coach> Coach { get; set; }

        public DbSet<GProject2.Models.ProjectRole> ProjectRole { get; set; }
    }
}
