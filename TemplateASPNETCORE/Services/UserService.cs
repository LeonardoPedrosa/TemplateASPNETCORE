using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateASPNETCORE.Data;
using TemplateASPNETCORE.Models;

namespace TemplateASPNETCORE.Services
{
  public class UserService : IUserService
  {
    private readonly Context _context;

    public UserService(Context context)
    {
      _context = context;
    }
    public async Task<User> GetUserById(int id)
    {
      return await _context.User.FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<User[]> GetUsers()
    {
      IQueryable<User> users = _context.User;

      return await users.ToArrayAsync();
    }

    public async Task<bool> UserExists(int id)
    {
      return await _context.User.AnyAsync(e => e.id == id);
    }
  }
}
