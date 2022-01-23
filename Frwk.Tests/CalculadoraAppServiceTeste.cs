using Frwk.AppService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frwk.Tests
{
    [TestClass]
    public class CalculadoraAppServiceTeste
    {

        [TestInitialize]
        public void Initialize()
        {
           
        }

        [TestMethod]
        public async Task Teste_Calcular_Valor_De_Entrada_Igual_A_45()
        {
            var calculadoraAppService = new CalculadoraAppService();

            List<int> numerosDivisores = new() { 1, 3, 5, 9, 15, 45 };
            List<int> numerosPrimos = new() { 3, 5 };

            var response = await calculadoraAppService.Calcular(new AppService.DTO.CalculadoraRequest { NumeroDeEntrada = 45 });

            Assert.AreEqual(response.NumerosDivisores[0], numerosDivisores[0]);
            Assert.AreEqual(response.NumerosDivisores[1], numerosDivisores[1]);
            Assert.AreEqual(response.NumerosDivisores[2], numerosDivisores[2]);
            Assert.AreEqual(response.NumerosDivisores[3], numerosDivisores[3]);
            Assert.AreEqual(response.NumerosDivisores[4], numerosDivisores[4]);
            Assert.AreEqual(response.NumerosDivisores[5], numerosDivisores[5]);

            Assert.AreEqual(response.NumerosPrimos[0] , numerosPrimos[0]);
            Assert.AreEqual(response.NumerosPrimos[1] , numerosPrimos[1]);
        }

        [TestMethod]
        public async Task Teste_Calcular_Valor_De_Entrada_Igual_A_Zero()
        {
            var calculadoraAppService = new CalculadoraAppService();

            try
            {
                var response = await calculadoraAppService.Calcular(new AppService.DTO.CalculadoraRequest { NumeroDeEntrada = 0 });
            }
            catch (ArgumentException ex)
            {                
                Assert.AreEqual("Informe um número maior que zero.", ex.Message);
            }

        }

        [TestMethod]
        public async Task Teste_Calcular_Valor_De_Entrada_Menor_Que_Zero()
        {
            var calculadoraAppService = new CalculadoraAppService();

            try
            {
                var response = await calculadoraAppService.Calcular(new AppService.DTO.CalculadoraRequest { NumeroDeEntrada = -1 });
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Informe um número maior que zero.", ex.Message);
            }
        }

        [TestMethod]
        public async Task Teste_Calcular_Valor_De_Entrada_Igual_A_Um()
        {
            var calculadoraAppService = new CalculadoraAppService();

            var response = await calculadoraAppService.Calcular(new AppService.DTO.CalculadoraRequest { NumeroDeEntrada = 1 });
            
            Assert.AreEqual(response.NumerosDivisores[0], 1);

            Assert.IsTrue(!response.NumerosPrimos.Any());
        }
    }
}