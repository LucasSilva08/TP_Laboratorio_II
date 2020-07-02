using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void TestListaDePaquetes()
        {
            Correo c = new Correo();
            Assert.AreNotEqual(c.Paquetes, null);
        }


        [TestMethod]
        public void PaquetesIguales()
        {
            try
            {
                Correo c = new Correo();
                Paquete p1 = new Paquete("p1", "111-222-3333");
                Paquete p2 = new Paquete("p2", "111-222-3333");
                c += p1;
                c += p2;
            }

            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
