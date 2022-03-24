using Documentos.Application.Documentos.Queries;
using Documentos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Documentos.Application.Documentos.Handlers
{
    public class GetDocumentoByIdQueryHandler : IRequestHandler<GetDocumentoByIdQuery, Domain.Entities.Documento>
    {
        private readonly IDocumentoRepository _repository;

        public GetDocumentoByIdQueryHandler(IDocumentoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Domain.Entities.Documento> Handle(GetDocumentoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Codigo);
        }
    }
}