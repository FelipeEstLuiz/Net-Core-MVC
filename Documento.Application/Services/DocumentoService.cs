using AutoMapper;
using Documentos.Application.Documentos.Command;
using Documentos.Application.Documentos.Queries;
using Documentos.Application.DTOs;
using Documentos.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documentos.Application.Services
{
    public class DocumentoService : IDocumentoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DocumentoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Remove(string codigo)
        {
            DocumentoDeleteCommand query = new DocumentoDeleteCommand(codigo);

            if (query == null)
                throw new Exception("Entidade não foi carregada");

            await _mediator.Send(query);
        }

        public async Task<IEnumerable<DocumentoDTO>> GetAll()
        {
            GetDocumentoQuery query = new GetDocumentoQuery();

            if (query == null)
                throw new Exception("Entidade não foi carregada");

            IEnumerable<Domain.Entities.Documento> result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<DocumentoDTO>>(result);
        }

        public async Task<DocumentoDTO> GetById(string codigo)
        {
            GetDocumentoByIdQuery query = new GetDocumentoByIdQuery(codigo);

            if (query == null)
                throw new Exception("Entidade não foi carregada");

            Domain.Entities.Documento result = await _mediator.Send(query);

            return _mapper.Map<DocumentoDTO>(result);
        }

        public async Task Update(DocumentoDTO documento)
        {
            DocumentoUpdateCommand document = _mapper.Map<DocumentoUpdateCommand>(documento);
            await _mediator.Send(document);
        }

        public async Task Add(DocumentoDTO documento)
        {
            var documentoCreateCommand = _mapper.Map<DocumentoCreateCommand>(documento);
            await _mediator.Send(documentoCreateCommand);
        }
    }
}
