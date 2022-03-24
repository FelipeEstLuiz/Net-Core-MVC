using Documentos.Application.DTOs;
using Documentos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Documento.MVC.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly IDocumentoService _service;

        public DocumentoController(IDocumentoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Dados")]
        public async Task<IActionResult> GetDados()
        {
            var retorno = await _service.GetAll();
            return Ok(retorno);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetById(string codigo)
        {
            var retorno = await _service.GetById(codigo);
            return Ok(retorno);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DocumentoDTO documento)
        {
            await _service.Update(documento);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(DocumentoDTO documento)
        {
            await _service.Add(documento);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(string codigo)
        {
            await _service.Remove(codigo);
            return Ok();
        }
    }
}
