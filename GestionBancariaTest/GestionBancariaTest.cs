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
            double saldoEsperado = 500;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");

        }

        [TestMethod]
        public void ValidarReintegroNegativo()
        {
            double saldoInicial = 500;
            double reintegro = -50;
            double saldoEsperado = 500;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");

        }

        [TestMethod]
        public void ValidarReintegroMayorSaldo()
        {
            double saldoInicial = 500;
            double reintegro = 750;
            double saldoEsperado = 500;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarReintegro(reintegro);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el reintegro, saldo" + "incorrecto.");

        }

        [TestMethod]
        public void ValidarIngresoNegativo()
        {
            double saldoInicial = 1200;
            double cantidad = -500;
            double saldoEsperado = 1200;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarIngreso(cantidad);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");

        }

        [TestMethod]
        public void ValidarIngresoLimite()
        {
            double saldoInicial = 1200;
            double cantidad = 0;
            double saldoEsperado = 1200;

            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);

            miApp.RealizarIngreso(cantidad);

            Assert.AreEqual(saldoEsperado, miApp.ObtenerSaldo(), 0.001, "Se produjo un error al realizar el ingreso, saldo" + "incorrecto.");

        }
    }
}
