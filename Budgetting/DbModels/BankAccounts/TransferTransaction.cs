using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.DbModels.BankAccounts
{
  public class TransferTransaction
  {
    public int Id { get; set; }
    public virtual AccountTransaction OutboundTransaction { get; set; }
    public virtual AccountTransaction InboundTransaction { get; set; }
  }
}
