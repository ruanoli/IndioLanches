using IndioLanches.Repositories.Interfaces;
using IndioLanches.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IndioLanches.Controllers {
    public class LancheController : Controller {
        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }
        public IActionResult List() {
            var lancheListViewModel = new LancheListViewModel();

            lancheListViewModel.Lanches = _lancheRepository.Lanches.ToList();
            lancheListViewModel.CategoriAtual = "Categoria Atual"; //valor temporário.

            return View(lancheListViewModel);
            //var lanches = _lancheRepository.Lanches.ToList();
            //return View(lanches);           
        }

        public IActionResult Details(int id) { 
            var lanche = _lancheRepository.Lanches.FirstOrDefault(x => x.LancheId == id);
            
            return View(lanche);
        }
    }
}
