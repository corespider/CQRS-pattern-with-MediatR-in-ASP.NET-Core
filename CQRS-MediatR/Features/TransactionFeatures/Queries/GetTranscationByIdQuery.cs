using CQRS_MediatR.Context;
using CQRS_MediatR.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Features.TransactionFeatures.Queries
{
    public class GetTranscationByIdQuery : IRequest<Transaction>
    {
        public int Id { get; set; }
        public class GetTranscationByIdQueryHandler : IRequestHandler<GetTranscationByIdQuery, Transaction>
        {
            private readonly ITransactionDbContext _context;
            public GetTranscationByIdQueryHandler(ITransactionDbContext context)
            {
                _context = context;
            }
            public async Task<Transaction> Handle(GetTranscationByIdQuery query, CancellationToken cancellationToken)
            {
                var transcation = _context.Transactions.Where(a => a.TransactionId == query.Id).FirstOrDefault();
                if (transcation == null) return null;
                return transcation;
            }
        }
    }
}