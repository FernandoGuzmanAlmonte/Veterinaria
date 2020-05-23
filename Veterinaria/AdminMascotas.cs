using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Veterinaria
{
    class AdminMascotas
    {
        DAOMascota daoMascota = new DAOMascota();

        public AdminMascotas() { }
        ~AdminMascotas() { }

        public bool existeMascota(String id)
        {
            if (daoMascota.existeMascota(id)) return true;
            else return false;
        }

        public List<Mascota> listarMascotas()
        {
            return daoMascota.consultarMascotas();
        }

        public Mascota consultarMascota(String id)
        {
            return daoMascota.consultarMascota(id);
        }

        public bool agregarMascota(String nombre, String especie, String raza, int edad,
            double peso, double estatura, String nombreDuenio)
        {
            Mascota mascota = new Mascota("0", nombre, especie, raza, edad, peso, estatura,
                nombreDuenio);

            if (daoMascota.agregar(mascota)) return true;
            else return false;
        }

        public bool modificarMascota(String id, String nombre, String especie, String raza, int edad,
            double peso, double estatura, String nombreDuenio)
        {
            if (daoMascota.actualizar(new Mascota(id, nombre, especie, raza, edad, peso, estatura,
            nombreDuenio))) return true;
            else return false;
        }

        public bool eliminarMascota(String id)
        {
            if (daoMascota.eliminar(id)) return true;
            else return false;
        }
    }
}
