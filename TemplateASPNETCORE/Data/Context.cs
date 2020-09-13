using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateASPNETCORE.Models;

namespace TemplateASPNETCORE.Data
{
  public class Context : DbContext
  {
    public Context(DbContextOptions<Context> options) : base(options) {}

    //here create DbSet<Class>
    public DbSet<User> User { get; set; }
  }
}
