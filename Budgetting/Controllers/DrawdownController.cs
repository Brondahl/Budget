using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Budgetting.DbModels.BankAccounts;
using Microsoft.AspNetCore.Mvc;

namespace Budgetting.Controllers
{
  /*
   * Demonstrates basic path routing.
   */
  [Route("api/[controller]")]
  [ApiController]
  public class DrawdownController : ControllerBase
  {
    private IAccountsService accountsService;
    private IAccountTransactionsService txnService;
    private IDownloadersRepository downloaders;
    private ICredentialsService credentialsService;

    [HttpPost]
    public ActionResult InitiateDrawdown(string credentialAuthorisation, DateTime startDate)
    {
      var credentials = credentialsService.GetCredentials(credentialAuthorisation);
      var txDownloaders = downloaders.GetAll();

      var allDownloadedTxs = new List<AccountTransaction>();
      foreach (var downloader in txDownloaders)
      {
        downloader.RetrieveSpecificCredentials(credentials);
        allDownloadedTxs.AddRange(downloader.GetAllTransactions(startDate));
      }

      MarkHashCollisionsAsNotDuplicates(allDownloadedTxs);

      var existingRecentTxs = txnService.GetAllTransactionsSince(startDate.AddMonths(-1));

      var newTxs = RemoveExistingTransactions(allDownloadedTransactions, existingRecentTransactions);

      txnService.SaveNewTransactions(allDownloadedTransactions);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }

  internal interface IDownloadersRepository
  {
    IEnumerable<TransactionDownloader> GetAll();
  }

  internal interface IAccountsService
  {
    IEnumerable<Account> GetAll();
  }
}
