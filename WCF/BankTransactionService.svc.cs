using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class BankTransactionService : IBankTransactionService
    {
        public ResultOperation<Guid> CreateTransaction(BankTransactionCreateDto model)
        {
            try
            {
                using (DAL.BankContext context = new DAL.BankContext())
                {
                    var result = new DAL.Business.TransactionsService(context).CreateTransaction(model);
                    return new ResultOperation<Guid>(result);
                }
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
        }

        public List<AccountClientDto> GetAccountClients()
        {
            using (DAL.BankContext context = new DAL.BankContext())
            {
                return new DAL.Business.TransactionsService(context).GetAccountClients();
            }
        }

        public List<BankTransactionViewDto> GetTransactions()
        {
            using (DAL.BankContext context = new DAL.BankContext())
            {
                return new DAL.Business.TransactionsService(context).GetTransactions();
            }
        }
    }
}
