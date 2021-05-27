using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Periodos_Atras.ClassLibrary;

namespace Periodos_Atras.Tests
{
    [TestClass]
    public class DatasTest
    {
        PeriodosAtras p = new PeriodosAtras();

        [TestMethod]
        public void DeveRetornar1d()
        {
            Assert.AreEqual("um dia atrás", p.periodoPorExtenso(new DateTime(2021, 05, 26)));
        }

        [TestMethod]
        public void DeveRetornar1s()
        {
            Assert.AreEqual("uma semana atrás", p.periodoPorExtenso(new DateTime(2021, 05, 20)));
        }

        [TestMethod]
        public void DeveRetornar1m()
        {
            Assert.AreEqual("um mês atrás", p.periodoPorExtenso(new DateTime(2021, 04, 27)));
        }

        [TestMethod]
        public void DeveRetornar2m1d()
        {
            Assert.AreEqual("dois meses um dia atrás", p.periodoPorExtenso(new DateTime(2021, 03, 27)));
        }

        [TestMethod]
        public void DeveRetornar1a()
        {
            Assert.AreEqual("um ano atrás", p.periodoPorExtenso(new DateTime(2020, 05, 27)));
        }

        [TestMethod]
        public void DeveRetornar1a6m()
        {
            Assert.AreEqual("um ano seis meses atrás", p.periodoPorExtenso(new DateTime(2019, 11, 29)));
        }

        [TestMethod]
        public void DeveRetornar10a()
        {
            Assert.AreEqual("dez anos atrás", p.periodoPorExtenso(new DateTime(2011, 05, 30)));
        }

        [TestMethod]
        public void DeveRetornarDataFutura()
        {
            Assert.AreEqual("Data futura!", p.periodoPorExtenso(new DateTime(2022, 05, 27)));
        }
    }
}
