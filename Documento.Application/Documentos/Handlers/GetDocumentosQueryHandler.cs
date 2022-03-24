using Documentos.Application.Documentos.Queries;
using Documentos.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Documentos.Application.Documentos.Handlers
{
    public class GetDocumentosQueryHandler : IRequestHandler<GetDocumentoQuery, IEnumerable<Domain.Entities.Documento>>
    {
        private readonly IDocumentoRepository _repository;

        public GetDocumentosQueryHandler(IDocumentoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Domain.Entities.Documento>> Handle(GetDocumentoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
