using Frwk.AppService;
using Frwk.AppService.DTO;

namespace Fwrk.ConsoleApp
{
    public class Calculadora : ICalculadora
    {
        private readonly ICalculadoraAppService _calculadoraAppService;
        public Calculadora(ICalculadoraAppService calculadoraAppService)
        {
            _calculadoraAppService = calculadoraAppService;
        }

        public async Task Inicializar()
        {
            bool continuar = true;
            while (continuar)
            {
                try
                {
                    await Calcular();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao realizar o cálculo.\nErro: {ex.Message}");
                }
                continuar = VerificarContinuacao();
                Console.Clear();
            }
        }

        public void Imprimir(NumerosDTO numeros)
        {
            Console.WriteLine($"Números Divisores: {string.Join(',', numeros.NumerosDivisores)}");

            if (numeros.NumerosPrimos.Any())
                Console.WriteLine($"Números Primos: {string.Join(',', numeros.NumerosPrimos)}");
        }

        public bool VerificarContinuacao()
        {
            Console.WriteLine("Pressione \"S\" para Sair ou qualquer tecla para continuar: ");
            var tecla = Console.ReadKey().Key.ToString();
            return tecla != "S";
        }

        public async Task Calcular()
        {
            Console.Write("Informe o número a ser decomposto: ");
            var entrada = Console.ReadLine();
            if (int.TryParse(entrada?.ToString(), out int numero))
            {
                var responseCalculadora = await _calculadoraAppService.Calcular(new CalculadoraRequest { NumeroDeEntrada = numero });
                if (responseCalculadora.NumerosDivisores.Any())
                {
                    Imprimir(responseCalculadora);
                }
            }
            else
            {
                Console.WriteLine("Valor informado inválido. Informe um número inteiro.");
            }
        }
    }
}