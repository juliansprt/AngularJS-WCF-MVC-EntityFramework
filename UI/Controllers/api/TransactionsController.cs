using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Controllers.api
{
    public class TransactionsController : ApiController
    {
        // GET: api/Categorias

        public Dto.BankTransactionViewDto[] Get()
        {
            try
            {
                using (BankTransactionServiceClient client = new BankTransactionServiceClient())
                {
                    return client.GetTransactions();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public Dto.ResultOperationOfguid Post([FromBody] TransactionCreate model)
        {
            try
            {
                using (BankTransactionServiceClient client = new BankTransactionServiceClient())
                {
                    return client.CreateTransaction(new Dto.BankTransactionCreateDto()
                    {
                        AccountDestinityId = model.AccountDestinityId,
                        AccountOriginId = model.AccountOriginId,
                        Value = model.Value
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class TransactionCreate
    {
        public Guid AccountOriginId { get; set; }

        public Guid AccountDestinityId { get; set; }

        public decimal Value { get; set; }
    }
}
