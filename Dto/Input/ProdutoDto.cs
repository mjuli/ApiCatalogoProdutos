using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoProdutos.Model;

namespace ApiCatalogoProdutos.Dto.Input
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public string ImageUrl { get; set; }
        public float? Estoque { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int CategoriaId { get; set; }
    }
}