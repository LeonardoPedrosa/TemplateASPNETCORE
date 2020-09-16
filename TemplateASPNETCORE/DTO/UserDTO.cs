using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateASPNETCORE.DTO
{
  //defining how the data will be sent over the network.
  public class UserDTO
  {
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public int age { get; set; }
  }
}
