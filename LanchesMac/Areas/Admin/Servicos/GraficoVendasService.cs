using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Areas.Admin.Servicos
{
    public class GraficoVendasService
    {
        private readonly AppDbContext _context;

        public GraficoVendasService(AppDbContext context)
        {
            _context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var lanches = (from pd in _context.PedidoDetalhes
                           join l in _context.Produtos on pd.ProdutoId equals l.Id
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.ProdutoId, l.Nome }
                           into g
                           select new LancheGrafico
                           {
                               ProdutoNome = g.Key.Nome,
                               ProdutoQuantidade = g.Sum(q => q.Quantidade),
                               ProdutosValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           }).ToList();

            return lanches;
        }
    }
}
