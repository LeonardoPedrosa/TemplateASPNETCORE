using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

    public UserToken Authenticate(string username, string password)
    {     
      var user = _context.User.Where(x => x.name == username && x.password == password).FirstOrDefault();

      if (user == null)
        return null;

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(Settings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.name),
                    new Claim("TemplateASPNETCORE", user.role)
          }),
        Expires = DateTime.UtcNow.AddMinutes(2),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);

      UserToken userToken = new UserToken();
      userToken.Token = tokenHandler.WriteToken(token);

      user.password = null;

      return userToken;
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
