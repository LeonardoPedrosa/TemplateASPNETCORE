using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateASPNETCORE.Models
{
  public class User
  {
    public int id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public DateTime birthday { get; set; }
    public string password { get; set; }
    public string role { get; set; }
  }
}
