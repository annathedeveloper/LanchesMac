using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    public class PedidoDetalhe
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        
        public Pedido Pedido { get; set; }
        
    }    
}
