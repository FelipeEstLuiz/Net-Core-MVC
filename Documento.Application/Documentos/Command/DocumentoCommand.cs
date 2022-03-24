using Documentos.Domain.Entities;
using MediatR;
using System;

namespace Documentos.Application.Documentos.Command
{
    public abstract class DocumentoCommand : IRequest<Documento>
    {
        public string Codigo { get; set; }
        public string Titulo { get; set; }
        public string Revisao { get; set; }
        public DateTime DataPlanejada { get; set; }
        public decimal Valor { get; set; }
    }
}
