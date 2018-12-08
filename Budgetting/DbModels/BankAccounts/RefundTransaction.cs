using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budgetting.DbModels.BankAccounts
{
  public class RefundTransaction
  {
    public int Id { get; set; }
    public virtual AccountTransaction OriginalTransaction { get; set; }
    public virtual AccountTransaction RefundingTransaction { get; set; }
  }
}
