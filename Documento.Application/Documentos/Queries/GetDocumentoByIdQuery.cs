using MediatR;

namespace Documentos.Application.Documentos.Queries
{
    public class GetDocumentoByIdQuery : IRequest<Domain.Entities.Documento>
    {
        public string Codigo { get; set; }

        public GetDocumentoByIdQuery(string codigo)
        {
            Codigo = codigo;
        }
    }
}
