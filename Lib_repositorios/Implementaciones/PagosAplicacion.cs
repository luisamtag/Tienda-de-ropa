using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_repositorios.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion? IConexion = null;

        public PagosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Pagos? Borrar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Pagos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Pagos? Guardar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Pagos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Listar()
        {
            return this.IConexion!.Pagos!.Take(20).ToList();
        }
        public List<Pagos> PorVenta(Pagos? entidad)
        {
            return this.IConexion!.Pagos!
                .Where(x => x.Venta == entidad!.Venta)
                .Take(20)
                .ToList();
        }
        public Pagos? Modificar(Pagos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
