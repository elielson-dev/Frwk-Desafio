using Frwk.AppService.DTO;

namespace Frwk.AppService
{
    public interface ICalculadoraAppService
    {
        Task<NumerosDTO> Calcular(CalculadoraRequest request);
    }
}
