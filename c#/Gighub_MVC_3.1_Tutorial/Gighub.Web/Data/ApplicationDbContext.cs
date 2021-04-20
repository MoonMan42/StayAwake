using Gighub.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gighub.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<GigModel> Gigs { get; set; }
        public DbSet<GenreModel> Genres { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
    }
}
