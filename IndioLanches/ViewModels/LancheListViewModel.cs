using IndioLanches.Models;

namespace IndioLanches.ViewModels {
    public class LancheListViewModel {
        public IList<Lanche> Lanches { get; set; }
        public string? CategoriAtual { get; set; }
    }
}
