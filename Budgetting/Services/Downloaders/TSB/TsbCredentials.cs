using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.Services.Downloaders.TSB
{
  public class TsbCredentials
  {
    public string UserName { get; set; }
    public string Password { get; set; }
    public char[] PassCode { get; set; }
  }
}
