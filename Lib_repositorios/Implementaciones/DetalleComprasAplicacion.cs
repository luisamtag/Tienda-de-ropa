using lib_dominio.Entidades;
using lib_repositorios.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Implementaciones
{
    public class DetalleComprasAplicacion : IDetalleComprasAplicacion
    {
        private IConexion? IConexion = null;

        public DetalleComprasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public DetalleCompras? Borrar(DetalleCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.DetalleCompras!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public DetalleCompras? Guardar(DetalleCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.DetalleCompras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetalleCompras> Listar()
        {
            return this.IConexion!.DetalleCompras!.Take(20).ToList();
        }
        public List<DetalleCompras> PorCompraProveedor(DetalleCompras? entidad)
        {
            return this.IConexion!.DetalleCompras!
                .Where(x => x.CompraProveedor == entidad!.CompraProveedor)
                .Take(20)
                .ToList();
        }
        public DetalleCompras? Modificar(DetalleCompras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");

            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<DetalleCompras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
