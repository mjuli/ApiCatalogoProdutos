using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogoProdutos.Model
{
    [Table("Categorias")]
    public class Categoria
    {
        public Categoria(string nome, string imageUrl)
        {
            Produtos = new Collection<Produto>();
            Nome = nome;
            ImageUrl = imageUrl;
        }

        [Key]
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }
        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}