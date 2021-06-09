using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class BankTransactionViewDto
    {
        public Guid IdTransaction { get; set; }

        public DateTime Date { get; set; }
        public string ClientOriginName { get; set; }

        public string ClientOriginIdentification { get; set; }

        public string BankOrigin { get; set; }

        public string AccountOrigin { get; set; }

        public decimal Value { get; set; }

        public string ClientDestinityName { get; set; }

        public string ClientDestinityIdentification { get; set; }

        public string BankDestinity { get; set; }

        public string AccountDestinity { get; set; }
    }


}
