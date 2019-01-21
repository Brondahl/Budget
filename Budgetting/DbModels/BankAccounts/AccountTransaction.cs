using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.Helpers;

namespace Budgetting.DbModels.BankAccounts
{
  public class AccountTransaction
  {
    [Key]
    public int Id { get; set; }
    [Required] public virtual Account Account { get; set; }
    [Required] public string Description { get; set; }
    [Required] public string Type { get; set; }
    [Required] public decimal Amount { get; set; }
    [Required] public DateTime DateOfTransaction { get; set; }
    [Required] public DateTime DateOfImport { get; set; }
    [Required] public string ImportHash { get; set; }

    // If you have 2 transactions that are sufficiently similar (buy a coffee, then immediately buy another coffee)
    // then the properties on this object won't be distinguishable, and we're likely to assume that we've re-imported
    // an old transaction. This discriminator value can be used to say that, no, we really do have multiple of these.
    // 
    // It's not included in the ImportHash, since the first of the Txns could have come in on its own :(
    public int? IdenticalTransactionDiscriminator { get; set; }

    public string AccountPlusImportHash => SimpleHasher.Hash(Account.Id, ImportHash);
    public string GloballyUniqueHash => SimpleHasher.Hash(Account.Id, ImportHash, IdenticalTransactionDiscriminator);
  }
}
