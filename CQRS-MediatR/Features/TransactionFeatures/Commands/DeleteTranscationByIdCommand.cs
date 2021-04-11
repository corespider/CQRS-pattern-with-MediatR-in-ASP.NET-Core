using CQRS_MediatR.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Features.TransactionFeatures.Commands
{
    public class DeleteTranscationByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteTranscationByIdCommand, int>
        {
            private readonly ITransactionDbContext _context;
            public DeleteProductByIdCommandHandler(ITransactionDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTranscationByIdCommand command, CancellationToken cancellationToken)
            {
                var transcation = _context.Transactions.Where(a => a.TransactionId == command.Id).FirstOrDefault();
                if (transcation == null) return default;
                _context.Transactions.Remove(transcation);
                await _context.SaveChangesAsync();
                return transcation.TransactionId;
            }
        }
    }
}