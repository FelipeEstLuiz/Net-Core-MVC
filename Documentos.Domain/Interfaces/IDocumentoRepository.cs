using Documentos.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Documentos.Domain.Interfaces
{
    public interface IDocumentoRepository
    {
        Task<IEnumerable<Documento>> GetAllAsync();
        Task<Documento> GetByIdAsync(string codigo);
        Task<Documento> UpdateAsync(Documento documento);
        Task<Documento> DeleteAsync(Documento documento);
        Task<Documento> CreateAsync(Documento documento);
    }
}
