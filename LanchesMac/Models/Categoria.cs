using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "Tamanho máximo de {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }
        [StringLength(200, ErrorMessage = "Tamanho máximo de {1} caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
