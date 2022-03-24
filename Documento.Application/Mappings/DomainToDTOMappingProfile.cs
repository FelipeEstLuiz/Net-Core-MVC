using AutoMapper;
using Documentos.Application.DTOs;

namespace Documentos.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Domain.Entities.Documento, DocumentoDTO>().ReverseMap();
        }
    }
}
