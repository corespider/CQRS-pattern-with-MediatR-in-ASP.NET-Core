using CQRS_MediatR.Context;
using CQRS_MediatR.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.Features.TransactionFeatures.Queries
{
    public class GetAllTranscationsQuery : IRequest<IEnumerable<Transaction>>
    {
        public class GetAllTranscationsQueryHandler : IRequestHandler<GetAllTranscationsQuery, IEnumerable<Transaction>>
        {
            private readonly ITransactionDbContext _context;
            public GetAllTranscationsQueryHandler(ITransactionDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Transaction>> Handle(GetAllTranscationsQuery query, CancellationToken cancellationToken)
            {
                var transcationList = await _context.Transactions.ToListAsync();
                if (transcationList == null)
                {
                    return null;
                }
                return transcationList.AsReadOnly();
            }
        }
    }
}
