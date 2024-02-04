using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        [DataRow(1000, 250, 750)]
        [DataRow(1000, 1000, 0)]
        [DataRow(1000, 1, 999)]
        [DataRow(1000, 500, 500)]
        public void ValidarReintegroMMA2324(double saldoInicial, double reintegro, double saldoEsperado)
        {
           
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");

        }

        [TestMethod]
        [DataRow(1000, 250, 1250)]
        [DataRow(1000, 1, 1001)]
        [DataRow(0, 500, 500)]
        [DataRow(500, 500, 1000)]
        public void ValidarIngresoMMA2324(double saldoInicial, double cantidad, double saldoEsperado)
        {

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarIngreso(cantidad);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");

        }

        [TestMethod]
        [DataRow(500, 0, 0)]
        public void ValidarReintegroLimiteMMA2324(double saldoInicial, double reintegro, double saldoFinal)
        {
  
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_SALDO_LIMITE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }

        [TestMethod]
        [DataRow(1000, -250, 1250)]
        public void ValidarReintegroNegativoMMA2324(double saldoInicial, double reintegro, double saldoFinal)
        {

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }

        [TestMethod]
        [DataRow(500, 750, -250)]
        public void ValidarReintegroMayorSaldoMMA2324(double saldoInicial, double reintegro, double saldoFinal)
        {

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.RealizarReintegro(reintegro);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }

        [TestMethod]
        [DataRow(1200, -500, 700)]
        public void ValidarIngresoNegativoMMA2324(double saldoInicial, double cantidad, double saldoFinal)
        {

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.RealizarReintegro(cantidad);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }

        [TestMethod]
        [DataRow(1200, 0, 1200)]
        public void ValidarIngresoLimiteMMA2324(double saldoInicial, double cantidad, double saldoFinal)
        {

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            try
            {
                miApp.RealizarReintegro(cantidad);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                StringAssert.Contains(exception.Message, GestionBancariaApp.ERR_SALDO_LIMITE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }
    }
}
