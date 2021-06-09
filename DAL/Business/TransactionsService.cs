using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Business
{
    public class TransactionsService
    {
        private readonly BankContext _context;
        public TransactionsService(BankContext context)
        {
            _context = context;
        }


        public List<Dto.BankTransactionViewDto> GetTransactions()
        {
            var query = _context.BankTransaction.OrderByDescending(p => p.Date)
                .Select(p => new Dto.BankTransactionViewDto()
                {
                    IdTransaction = p.Id,
                    Date = p.Date,
                    AccountDestinity = p.AccountDestinity.AccountNro,
                    AccountOrigin = p.AccountOrigin.AccountNro,
                    BankDestinity = p.AccountDestinity.Client.BankName,
                    BankOrigin = p.AccountOrigin.Client.BankName,
                    ClientDestinityIdentification = p.AccountDestinity.Client.Identification,
                    ClientDestinityName = p.AccountDestinity.Client.Name,
                    ClientOriginIdentification = p.AccountOrigin.Client.Identification,
                    ClientOriginName = p.AccountOrigin.Client.Name,
                    Value = p.Value
                });
            return query.ToList();
        }

        public Guid CreateTransaction(Dto.BankTransactionCreateDto model)
        {
            var accountOrigin = _context.ClientAccounts.Find(model.AccountOriginId);
            var accountDestinity = _context.ClientAccounts.Find(model.AccountDestinityId);

            if ((accountOrigin.Balance - model.Value) < 0)
                throw new ArithmeticException("La cuenta de origen no tiene fondos suficientes!");
            accountOrigin.Balance = accountOrigin.Balance - model.Value;
            accountDestinity.Balance = accountDestinity.Balance + model.Value; 

            var dbModel = new BankTransaction()
            {
                Id = Guid.NewGuid(),
                IdAccountDestinity = model.AccountDestinityId,
                IdAccountOrigin = model.AccountOriginId,
                Value = model.Value,
                Date = DateTime.Now
            };
            _context.BankTransaction.Add(dbModel);

            //_context.Entry(accountDestinity).State = EntityState.Modified;
            //_context.Entry(accountOrigin).State = EntityState.Modified;
            _context.SaveChanges();
            return dbModel.Id;
        }

        public List<Dto.AccountClientDto> GetAccountClients()
        {
            var query = _context.ClientAccounts.OrderBy(p => p.Client.Name)
                .Select(p => new Dto.AccountClientDto()
                {
                    AccountNro = p.AccountNro,
                    Bank = p.Client.BankName,
                    Identification = p.Client.Identification,
                    Name = p.Client.Name,
                    AccountId = p.Id
                });

            return query.ToList();
        }
    }
}
