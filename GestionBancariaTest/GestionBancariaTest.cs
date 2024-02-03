using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace GestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTest
    {
        [TestMethod]
        public void ValidarReintegro()
        {
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");

        }

        [TestMethod]
        public void ValidarIngreso()
        {
            double saldoInicial = 1000;
            double cantidad = 300;
            double saldoEsperado = 1300;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarIngreso(cantidad);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");

        }

        [TestMethod]
        public void ValidarReintegroLimite()
        {
            double saldoInicial = 500;
            double reintegro = 0;
            double saldoFinal = saldoInicial - reintegro;

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
        public void ValidarReintegroNegativo()
        {
            double saldoInicial = 1000;
            double reintegro = -250;
            double saldoFinal = saldoInicial - reintegro;

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
        public void ValidarReintegroMayorSaldo()
        {
            double saldoInicial = 500;
            double reintegro = 750;
            double saldoFinal = saldoInicial - reintegro;

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
        public void ValidarIngresoNegativo()
        {
            double saldoInicial = 1200;
            double cantidad = -500;
            double saldoFinal = saldoInicial + cantidad;

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
        public void ValidarIngresoLimite()
        {
            double saldoInicial = 1200;
            double cantidad = 0;
            double saldoFinal = saldoInicial + cantidad;

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
