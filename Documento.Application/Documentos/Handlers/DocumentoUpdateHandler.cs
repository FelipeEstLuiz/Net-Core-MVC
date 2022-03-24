using Documentos.Application.Documentos.Command;
using Documentos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Documentos.Application.Documentos.Handlers
{
    public class DocumentoUpdateHandler : IRequestHandler<DocumentoUpdateCommand, Domain.Entities.Documento>
    {
        private readonly IDocumentoRepository _repository;

        public DocumentoUpdateHandler(IDocumentoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Domain.Entities.Documento> Handle(DocumentoUpdateCommand request, CancellationToken cancellationToken)
        {
            var documento = await _repository.GetByIdAsync(request.Codigo);

            if (documento == null)
                throw new ApplicationException("Documento não encontrado");

            documento.Update(request.Titulo, request.Revisao, request.DataPlanejada, request.Valor);

            return await _repository.UpdateAsync(documento);
        }
    }
}
