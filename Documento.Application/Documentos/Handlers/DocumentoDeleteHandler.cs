using Documentos.Application.Documentos.Command;
using Documentos.Domain.Entities;
using Documentos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Documentos.Application.Documentos.Handlers
{
    public class DocumentoDeleteHandler : IRequestHandler<DocumentoDeleteCommand, Documento>
    {
        private readonly IDocumentoRepository _repository;

        public DocumentoDeleteHandler(IDocumentoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Domain.Entities.Documento> Handle(DocumentoDeleteCommand request, CancellationToken cancellationToken)
        {
            var documento = await _repository.GetByIdAsync(request.Codigo);

            if (documento == null)
                throw new ApplicationException("Documento não encontrado");

            return await _repository.DeleteAsync(documento);
        }
    }
}
