using System;
using System.Collections.Generic;
using System.Text;

namespace Veterinaria
{
    class Mascota
    {
        private String id;
        private String nombre;
        private String especie;
        private String raza;
        private int edad;
        private double peso;
        private double estatura;
        private String nombreDuenio;
        //private Sintoma sintoma = new Sintoma();
        //Object foto = new Object();

        public Mascota() { }

        public Mascota(String id, String nombre, String especie, String raza, int edad, double peso,
            double estatura, String nombreDuenio/*, Sintoma sintoma Object foto*/)
        {
            this.id = id;
            this.nombre = nombre;
            this.especie = especie;
            this.raza = raza;
            this.edad = edad;
            this.peso = peso;
            this.estatura = estatura;
            this.nombreDuenio = nombreDuenio;
            //this.sintoma = sintoma;
            //this.foto = foto;
        }

        ~Mascota() { }

        public void fijaId(String id)
        {
            this.id = id;
        }
        public void fijaNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public void fijaEspecie(String especie)
        {
            this.especie = especie;
        }

        public void fijaRaza(String raza)
        {
            this.raza = raza;
        }

        public void fijaEdad(int edad)
        {
            this.edad = edad;
        }

        public void fijaPeso(double peso)
        {
            this.peso = peso;
        }

        public void fijaEstatura(double estatura)
        {
            this.estatura = estatura;
        }

        public void fijaNombreDuenio(String nombreDuenio)
        {
            this.nombreDuenio = nombreDuenio;
        }

        /*public void fijaSintoma(String sintoma)
        {
            this.fijaSintoma = sintoma
        }*/

        //public void fijaFoto(Object foto)
        //{
        //    this.foto = foto;
        //}

        public String dameId() => id;

        public String dameNombre() => nombre;

        public String dameEspecie() => especie;

        public String dameRaza() => raza;

        public int dameEdad() => edad;

        public double damePeso() => peso;

        public double dameEstatura() => estatura;

        public String dameNombreDuenio() => nombreDuenio;

        //public Sintoma dameSintoma() => sintoma;

        //public Object dameFoto() => foto;

    }
}
