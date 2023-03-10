using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Areas.Admin.Servicos
{
    public class RelatorioVendasServico
    {
        private readonly AppDbContext _context;

        public RelatorioVendasServico(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedidos select obj;

            if (minDate.HasValue) resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);

            if (maxDate.HasValue) resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);

            return await resultado.Include(l => l.PedidoItens)
                .ThenInclude(x => x.Produto)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
        }
    }
}
