﻿using System;
using System.Collections.Generic;

namespace BlazorCrud.API.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
