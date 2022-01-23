using Frwk.AppService.DTO;

namespace Frwk.AppService
{
    public class CalculadoraAppService : ICalculadoraAppService
    {
        public async Task<NumerosDTO> Calcular(CalculadoraRequest request)
        {
            var response = new NumerosDTO();
            var numeroDeEntrada = request.NumeroDeEntrada;
            if (ValidarEntradaDeDados(numeroDeEntrada))
            {
                await Task.Run(() =>
                {
                    ObterDivisoresEPrimos(numeroDeEntrada, response);                    
                });
            }
            return response;
        }
        private bool ValidarEntradaDeDados(int numero)
        {            
            if (numero <= 0)
                throw new ArgumentException("Informe um número maior que zero.");
            return true;
        }
        private void ObterDivisoresEPrimos(int numero, NumerosDTO response)
        {                        
            for (var i = 1; i <= numero; i++)
            {                
                if (numero % i == 0)
                {
                    response.NumerosDivisores.Add(i);

                    if (NumeroPrimo(i))
                    {
                        response.NumerosPrimos.Add(i);
                    }
                }
            }            
        }
        
        private bool NumeroPrimo(int n)
        {
            bool numeroPrimo = n != 1;

            for (int i = 2; i <= (int)Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    numeroPrimo = false;
                    break;
                }
            }
            return numeroPrimo;
        }
    }
}
