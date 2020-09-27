using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateASPNETCORE.Models;

namespace TemplateASPNETCORE.Services
{
  public interface IUserService
  {
    Task<User[]> GetUsers();
    Task<User> GetUserById(int id);
    Task<bool> UserExists(int id);
    User Authenticate(string username, string password);
  }
}
