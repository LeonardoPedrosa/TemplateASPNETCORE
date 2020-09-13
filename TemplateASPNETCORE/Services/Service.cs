using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateASPNETCORE.Data;

namespace TemplateASPNETCORE.Services
{
  public class Service : IService
  {
    //Open Closed Principle
    private readonly Context _context;
    //DI - Dependecy Injection
    public Service(Context context)
    {
      _context = context;
    }

    public Context Context { get; }

    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }   

    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }

    public async Task<bool> SaveChangeAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }
    
  }
}
