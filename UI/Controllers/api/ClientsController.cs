using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace UI.Controllers.api
{
    public class ClientsController : ApiController
    {
        public Dto.AccountClientDto[] Get()
        {
            try
            {
                using (BankTransactionServiceClient client = new BankTransactionServiceClient())
                {
                    return client.GetAccountClients();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
