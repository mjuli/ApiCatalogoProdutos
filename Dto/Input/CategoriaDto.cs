using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoProdutos.Dto.Input
{
    public class CategoriaDto
    {
        public CategoriaDto(string nome, string imageUrl)
        {
            Nome = nome;
            ImageUrl = imageUrl;
        }

        public string Nome { get; set; }
        public string ImageUrl { get; set; }
    }
}