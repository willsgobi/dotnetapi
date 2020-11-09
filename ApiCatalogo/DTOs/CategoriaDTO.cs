﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.DTOs {
    public class CategoriaDTO {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<ProdutoDTO> Produtos  { get; set; }
    }
}
