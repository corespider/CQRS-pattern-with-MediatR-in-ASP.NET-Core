using CQRS_MediatR.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Features.TransactionFeatures.Commands
{
    public class UpdateTransactionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string BeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string SWIFTCode { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, int>
        {
            private readonly ITransactionDbContext _context;
            public UpdateTransactionCommandHandler(ITransactionDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateTransactionCommand command, CancellationToken cancellationToken)
            {
                var tran = _context.Transactions.Where(a => a.TransactionId == command.Id).FirstOrDefault();
                if (tran == null)
                {
                    return default;
                }
                else
                {
                    tran.AccountNumber = command.AccountNumber;
                    tran.BeneficiaryName = command.BeneficiaryName;
                    tran.BankName = command.BankName;
                    tran.SWIFTCode = command.SWIFTCode;
                    tran.Amount = command.Amount;
                    tran.Date = command.Date;
                    await _context.SaveChangesAsync();
                    return tran.TransactionId;
                }
            }
        }
    }
}
