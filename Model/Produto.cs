using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogoProdutos.Model
{
    [Table("Produtos")]
    public class Produto
    {
        public Produto(string nome, string descricao, decimal preco, string imageUrl, int categoriaId)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            ImageUrl = imageUrl;
            CategoriaId = categoriaId;
            DataCadastro = DateTime.Now;
        }

        [Key]
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CategoriaId { get; set; }
    }
}