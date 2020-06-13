using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace TP3Tests
{
    [TestClass]
    public class TestsUnitarios
    {
        [TestMethod]
        public void TestArchivosException()
        {
            //arrange
            Texto text = new Texto();
            bool resultado = false;
            string datos;
            //act
            try
            {
                text.Leer("unaDireccionInesxistente.txt", out datos);

            } catch(ArchivosException e)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestArchivosExceptionDos()
        {
            //arrange
            Xml<Alumno> text = new Xml<Alumno>();
            Alumno alum = new Alumno(123, "Lucia", "Mendelson", "30123123",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            bool resultado = false;
            Alumno aux;
            //act
            try
            {
                text.Leer("unaDireccionInesxistente.xml", out aux);

            }
            catch (ArchivosException e)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestAlumnoRepetidoException()
        {
            //arrange
            bool resultado = false;

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            Universidad uni = new Universidad();
            //act
            try
            {
                uni += a1;
                uni += a2;

            }
            catch (AlumnoRepetidoException e)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestNacionalidadInvalidaException()
        {
            //arrange
            bool resultado = false;

            //act
            try
            {
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Extranjero,
                    Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            }
            catch (NacionalidadInvalidaException e)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestDniInvalidoException()
        {
            //arrange
            bool resultado = false;

            //act
            try
            {
                Alumno a1 = new Alumno(1, "Juan", "Lopez", "gsdgsdg", EntidadesAbstractas.Persona.ENacionalidad.Extranjero,
                    Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            }
            catch (DniInvalidoException e)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestSinProfesorException()
        {
            //arrange
            bool resultado = false;
            Profesor aux;
            Universidad uni = new Universidad();

            //act
            try
            {
                aux = uni == ClasesInstanciables.Universidad.EClases.Laboratorio;

            }
            catch (SinProfesorException e)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestSobrecargaOperadorClaseUniversidadIgual()
        {
            //arrange
            bool resultado = false;
            Profesor aux = new Profesor();
            Universidad uni = new Universidad();
            Profesor aux2;
            uni += aux;

            //act
            try
            {
                aux2 = uni != ClasesInstanciables.Universidad.EClases.Laboratorio;
                if(aux == aux2)
                {
                    resultado = true;
                }

            }
            catch(SinProfesorException e)
            {
                resultado = true;
            }


            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestSobrecargaOperadorUniversidadProfesorDiferente()
        {
            //arrange
            bool resultado = false;
            Profesor aux = new Profesor();
            Universidad uni = new Universidad();

            //act
           
            if(uni != aux)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }




        [TestMethod]
        public void TestSobrecargaOperadorUniversidadAlumnoDiferente()
        {
            //arrange
            bool resultado = false;
            Alumno aux = new Alumno();
            Universidad uni = new Universidad();

            //act

            if (uni != aux)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }



        [TestMethod]
        public void TestLeerUniversidad()
        {
            //arrange
            bool resultado = true;
            Universidad uni = new Universidad();

            //act
            try
            {
                ClasesInstanciables.Universidad.Guardar(uni);
                uni = ClasesInstanciables.Universidad.Leer();
            } catch (Exception e)
            {
                resultado = false;
            }


            //assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestSobrecargaOperadorSumaJornadaAlumno()
        {
            //arrange
            bool resultado = true;
            Profesor pro = new Profesor();
            Jornada jor = new Jornada(ClasesInstanciables.Universidad.EClases.Laboratorio, pro);
            Alumno al = new Alumno();

            //act
            try
            {
                jor += al;
            }
            catch (Exception e)
            {
                resultado = false;
            }


            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestLeerJornada()
        {
            //arrange
            bool resultado = true;
            Profesor pro = new Profesor();
            Jornada jor = new Jornada(ClasesInstanciables.Universidad.EClases.Laboratorio, pro);
            string jornadaLeer;

            //act
            try
            {
                ClasesInstanciables.Jornada.Guardar(jor);
                jornadaLeer = ClasesInstanciables.Jornada.Leer();

                if(jornadaLeer == String.Empty)
                {
                    resultado = false;
                }
            }
            catch (Exception e)
            {
                resultado = false;
            }


            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestSobreCargaAlumnoDistintoClase()
        {
            //arrange
            bool resultado = true;
            bool resultado2 = true;
            Alumno al = new Alumno(1, "a", "p", "35123984", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                ClasesInstanciables.Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);

            Alumno al2 = new Alumno(1, "a", "p", "35153984", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                ClasesInstanciables.Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);


            //act
            if(!(al != ClasesInstanciables.Universidad.EClases.Laboratorio))
            {
                resultado = false;
            }

            if(al2 != ClasesInstanciables.Universidad.EClases.Laboratorio)
            {
                resultado2 = false;
            }


            //assert
            Assert.IsTrue(resultado && resultado2);
        }


        [TestMethod]
        public void TestSobreCargaEqualsUniversitario()
        {
            //arrange
            bool resultado = false;
            Alumno al = new Alumno(1, "a", "p", "35123984", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                ClasesInstanciables.Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);

            Alumno al2 = new Alumno(1, "k", "j", "35123984", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                ClasesInstanciables.Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            //act

            if (al.Equals(al2))
            {
                resultado = true;
            }


            //assert
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void TestSobreCargaDiferenteUniversitario()
        {
            //arrange
            bool resultado = false;
            Alumno al = new Alumno(1, "a", "p", "35123984", EntidadesAbstractas.Persona.ENacionalidad.Argentino,
                ClasesInstanciables.Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Deudor);

            Profesor pro = new Profesor(1, "a", "p", "35183984", EntidadesAbstractas.Persona.ENacionalidad.Argentino);


            //act

            if (al != pro)
            {
                resultado = true;
            }


            //assert
            Assert.IsTrue(resultado);
        }


        [TestMethod]
        public void TestNombreIncorrecto()
        {
            //arrange
            bool resultado = false;
            Profesor pro; 

            //act

            pro = new Profesor(1, "[9", "p", "35123984", Persona.ENacionalidad.Argentino);

            if(pro.Nombre == String.Empty)
            {
                resultado = true;
            }

            //assert
            Assert.IsTrue(resultado);
        }



    }
}
