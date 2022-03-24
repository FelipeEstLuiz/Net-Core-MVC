using Documentos.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documentos.Application.Interfaces
{
    public interface IDocumentoService
    {
        Task<IEnumerable<DocumentoDTO>> GetAll();
        Task<DocumentoDTO> GetById(string codigo);
        Task Update(DocumentoDTO documento);
        Task Add(DocumentoDTO documento);
        Task Remove(string codigo);
    }
}
