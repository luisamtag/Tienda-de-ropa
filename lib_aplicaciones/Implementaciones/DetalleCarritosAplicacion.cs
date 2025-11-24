using lib_dominio.Entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Implementaciones
{
    public class DetalleCarritosAplicacion : IDetalleCarritosAplicacion
    {
        private IConexion? IConexion = null;

        public DetalleCarritosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public DetalleCarritos? Borrar(DetalleCarritos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.DetalleCarritos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetalleCarritos? Guardar(DetalleCarritos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.DetalleCarritos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetalleCarritos> Listar()
        {
            return this.IConexion!.DetalleCarritos!.Take(20).ToList();
        }

        public DetalleCarritos? Modificar(DetalleCarritos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<DetalleCarritos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
