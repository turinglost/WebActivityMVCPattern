#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebActivityMVCPattern.Models;

namespace WebActivityMVCPattern.Data
{
    public class WebActivityMVCPatternContext : DbContext
    {
        public WebActivityMVCPatternContext (DbContextOptions<WebActivityMVCPatternContext> options)
            : base(options)
        {
        }

        public DbSet<WebActivityMVCPattern.Models.ActivityModel> ActivityModel { get; set; }

        public DbSet<WebActivityMVCPattern.Models.ActivityName> ActivityName { get; set; }
    }
}
