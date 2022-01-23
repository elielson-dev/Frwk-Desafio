using Frwk.AppService;
using Frwk.AppService.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Frwk.Api.Controllers
{
    [Route("api/[controller]")]
    public class CalculadoraController : Controller
    {
        private readonly ICalculadoraAppService _calculadoraService;
        public CalculadoraController(ICalculadoraAppService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular([FromBody] CalculadoraRequest dadosDaEntrada)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _calculadoraService.Calcular(dadosDaEntrada);
                    return Ok(response);
                }
                catch(ArgumentException ex)
                {
                    return this.StatusCode(StatusCodes.Status400BadRequest, $"{ex.Message}");
                }
                catch (System.Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
                }
            }
            else
                return this.StatusCode(StatusCodes.Status400BadRequest, "Valor informado inválido");
        }
        
    }
}
