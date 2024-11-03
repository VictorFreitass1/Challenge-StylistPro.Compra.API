using StylistPro.Compra.Application.Dtos;
using StylistPro.Compra.Domain.Entities;
using StylistPro.Compra.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StylistPro.Compra.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly IComprasApplicationService _comprasApplicationService;

        public ComprasController(IComprasApplicationService comprasApplicationService)
        {
            _comprasApplicationService = comprasApplicationService;
        }

        /// <summary>
        /// Método para obter todos os dados da compra
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<ComprasEntity>>]
        public IActionResult Get()
        {
            var compras = _comprasApplicationService.ObterTodasCompras();

            if (compras is not null)
                return Ok(compras);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Método para obter um feedback
        /// </summary>
        /// <param name="id">Identificador da compra</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<ComprasEntity>]

        public IActionResult GetPorId(int id)
        {
            var compras = _comprasApplicationService.ObterComprasPorId(id);

            if (compras is not null)
                return Ok(compras);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Métodos para salvar a compra
        /// </summary>
        /// <param name="entity">Modelo de dados do Compra</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<ComprasEntity>]
        public IActionResult Post(ComprasDto entity)
        {
            try
            {
                var compras = _comprasApplicationService.SalvarDadosCompras(entity);

                if (compras is not null)
                    return Ok(compras);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Métodos para editar a compra
        /// </summary>
        /// <param name="id"> Identificador do Compra</param>
        /// <param name="entity">Modelo de dados da Compra</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<ComprasEntity>]
        public IActionResult Put(int id, [FromBody] ComprasDto entity)
        {
            try
            {
                var compras = _comprasApplicationService.EditarDadosCompras(id, entity);

                if (compras is not null)
                    return Ok(compras);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para deletar uma compra
        /// </summary>
        /// <param name="id">Identificador da compra</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<ComprasEntity>]

        public IActionResult Delete(int id)
        {
            var compras = _comprasApplicationService.DeletarDadosCompras(id);

            if (compras is not null)
                return Ok(compras);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
