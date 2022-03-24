using Documentos.Application.Documentos.Command;
using Documentos.Domain.Entities;
using Documentos.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Documentos.Application.Documentos.Handlers
{
    public class DocumentoCreateHandler : IRequestHandler<DocumentoCreateCommand, Documento>
    {
        private readonly IDocumentoRepository _repository;

        public DocumentoCreateHandler(IDocumentoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Documento> Handle(DocumentoCreateCommand request, CancellationToken cancellationToken)
        {
            var documentoExistente = await _repository.GetByIdAsync(request.Codigo);

            if (documentoExistente != null)
                throw new Exception("Já existe um cadastro com esse codigo");

            var documento = new Documento(request.Codigo, request.Titulo, request.Revisao, request.DataPlanejada, request.Valor);

            if (documento == null)
            {
                throw new ApplicationException($"Erro ao criar entidade.");
            }
            else
            {
                return await _repository.CreateAsync(documento);
            }
        }
    }
}
