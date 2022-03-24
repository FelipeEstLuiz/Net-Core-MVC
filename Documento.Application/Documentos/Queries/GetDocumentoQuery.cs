using MediatR;
using System.Collections.Generic;

namespace Documentos.Application.Documentos.Queries
{
    public class GetDocumentoQuery : IRequest<IEnumerable<Domain.Entities.Documento>>
    {
        public GetDocumentoQuery() { }
    }
}
