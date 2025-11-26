using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using System.Diagnostics.Metrics;

namespace lib_aplicaciones.Implementaciones
{
    public class CarritosAplicacion : ICarritosAplicacion
    {
        private IConexion? IConexion = null;

        public CarritosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Carritos? Borrar(Carritos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Carritos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Carritos? Guardar(Carritos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Carritos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Carritos> Listar()
        {
            return this.IConexion!.Carritos!.Take(20).ToList();
        }

        public List<Carritos> PorCliente(Carritos? entidad)
        {
            return this.IConexion!.Carritos!
                .Where(x => x.Cliente == entidad!.Cliente)
                .Take(20)
                .ToList();
        }

        public Carritos? Modificar(Carritos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Carritos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}

