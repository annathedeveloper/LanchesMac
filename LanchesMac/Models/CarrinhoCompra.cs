using LanchesMac.Context;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _appDbContext;

        public CarrinhoCompra(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string Id { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                Id = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens
                        .SingleOrDefault(s => s.Produto.Id == produto.Id && s.CarrinhoCompraId == Id);

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = Id,
                    Produto = produto,
                    Quantidade = 1                    
                };
                _appDbContext.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens.SingleOrDefault(s => s.Produto.Id == produto.Id && s.CarrinhoCompraId == Id);
            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _appDbContext.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _appDbContext.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ??
                (CarrinhoCompraItens = _appDbContext.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == Id)
                    .Include(s => s.Produto)
                    .ToList());
        }
        public void LimparCarrinho()
        {
            var carrinhoItens = _appDbContext.CarrinhoCompraItens.Where(carrinho => carrinho.CarrinhoCompraId == Id);

            _appDbContext.CarrinhoCompraItens.RemoveRange(carrinhoItens);
            _appDbContext.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var carrinho = _appDbContext.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == Id);
            var total = _appDbContext.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == Id)
                .Select(c => c.Produto.Preco * c.Quantidade).Sum();
            return total;
        }
    }
}
