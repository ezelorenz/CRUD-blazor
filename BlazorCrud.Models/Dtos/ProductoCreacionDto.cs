﻿using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Models.Dtos
{
    public class ProductoCreacionDto
    {
        public string? Marca { get; set; }

        public string? Descripcion { get; set; }

        [Required]
        public string NombreCategoria { get; set; }

        public decimal? Precio { get; set; }
    }
}
