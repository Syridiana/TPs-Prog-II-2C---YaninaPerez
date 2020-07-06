using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YaninaPerez_2doC_TP4;

namespace Tests
{
    [TestClass]
    public class TestsUnitarios
    {
        [TestMethod]
        public void TestListaPaquetesInstanciada()
        {
            // arrange
            Correo correo = new Correo();
            bool resultado = false;

            // act
            if(!(correo.Paquetes is null))
            {
                resultado = true;
            }

            // assert
            Assert.IsTrue(resultado);

        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TestCargarPaquetesMismoTrackingId()
        {
            // arrange
            Paquete p1 = new Paquete("Calle falsa 123", "111-111-1111");
            Paquete p2 = new Paquete("Avenida Siempre Viva 2020", "111-111-1111");
            Correo correo = new Correo();

            // act
            correo += p1;
            correo += p2;

            // assert

        }
    }
}
