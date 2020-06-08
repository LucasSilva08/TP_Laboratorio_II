using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;
using Archivos;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void ValidarNacionalidadInvalidaExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(3, "Cambon", "Agus", "23456578", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
                Assert.Fail("Deberia dar error de nacionalidad");

            }
            catch (NacionalidadInvalidaException e)
            {
                Assert.IsTrue(true);
            }

        }
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalido()
        {
            Alumno alumno = new Alumno(1, "Pablo", "Ortiz", "65ade221", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
        }
        [TestMethod]
        public void TestIsNotNull()
        {
            
            Universidad u1 = new Universidad();
            Alumno a1 = new Alumno(3, "Lopez", "Pablo", "91121111", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion);
            Profesor p1 = new Profesor(5, "Gonzalez", "Goma", "16353423", Persona.ENacionalidad.Argentino);

            Assert.IsNotNull(u1.Alumnos);
            Assert.IsNotNull(u1.Instructores);
            Assert.IsNotNull(u1.Jornadas);
            Assert.IsNotNull(a1);
            Assert.IsNotNull(p1);
        }
        [TestMethod]
        public void TestIsNumber()
        {
            Alumno alumno = new Alumno(9, "Carlos", "Pelegrini", "95060858", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }

    }
}
