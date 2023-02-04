using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Areas.Admin.Servicos
{
    public class RelatorioLancheService
    {
        private readonly AppDbContext _appDbContext;
        public RelatorioLancheService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Produto>> GetProdutosReport()
        {
            var produtos = await _appDbContext.Produtos.ToListAsync();

            if(produtos is null) return default(IEnumerable<Produto>);

            return produtos;
        }
        public async Task<IEnumerable<Categoria>> GetCategoriasReport()
        {
            var categorias = await _appDbContext.Categorias.ToListAsync();

            if (categorias is null) return default(IEnumerable<Categoria>);

            return categorias;
        }
    }
}
