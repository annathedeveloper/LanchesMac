using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutoController(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public IActionResult List(string categoria)
        {
            ViewData["Titulo"] = "Produtos";
            ViewData["Data"] = DateTime.Now;
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;
            if(string.IsNullOrEmpty(categoria) ) 
            {
                produtos = _produtosRepository.Produtos.OrderBy(l => l.Id); 
            }
            else
            {
                produtos = _produtosRepository.Produtos
                    .Where(l => l.Categoria.Nome.Equals(categoria))
                    .OrderBy(c => c.Nome);               
            }
            categoriaAtual = categoria;
            var produtosListViewModel = new ProdutoListViewModel();
            produtosListViewModel.Produtos = produtos;
            produtosListViewModel.CategoriaAtual = categoriaAtual;
            return View(produtosListViewModel);
        }
        public IActionResult Details(int produtoId)
        {
            var produto = _produtosRepository.Produtos.FirstOrDefault(l => l.Id == produtoId);
            return View(produto);
        }
        public ViewResult Search(string searchString)
        {
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if(string.IsNullOrEmpty(searchString) ) 
            {
                produtos = _produtosRepository.Produtos.OrderBy(p => p.Id);
                categoriaAtual = "Todos os Lanches";
            }
            else
            {
                produtos = _produtosRepository.Produtos.
                    Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (produtos.Any())
                    categoriaAtual = "Lanches";
                else
                    categoriaAtual = "Nenhum lanche foi encontrado";
            }
            return View("~/Views/Produto/List.cshtml", new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual,
            });
        }
    }
}
