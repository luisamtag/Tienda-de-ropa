﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class CategoriaProductos
    {
        [Key]public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Descripcion { get; set; }
    }
}
