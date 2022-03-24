using AutoMapper;
using Documentos.Application.Documentos.Command;
using Documentos.Application.DTOs;

namespace Documentos.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<DocumentoDTO, DocumentoCreateCommand>();
            CreateMap<DocumentoDTO, DocumentoDeleteCommand>();
            CreateMap<DocumentoDTO, DocumentoUpdateCommand>();
        }
    }
}
