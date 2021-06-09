using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IBankTransactionService
    {
        [OperationContract]
        List<Dto.BankTransactionViewDto> GetTransactions();

        [OperationContract]
        Dto.ResultOperation<Guid> CreateTransaction(Dto.BankTransactionCreateDto model);

        [OperationContract]
        List<Dto.AccountClientDto> GetAccountClients();

        // TODO: agregue aquí sus operaciones de servicio
    }
}
