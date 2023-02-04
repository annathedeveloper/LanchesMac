using LanchesMac.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly ICategoriaRepository _repository;
        public CategoriaMenu(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            var categorias = _repository.Categorias.OrderBy(p => p.Nome);
            return View(categorias);
        }
    }
}
