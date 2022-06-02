using IndioLanches.Models;

namespace IndioLanches.Repositories.Interfaces {
    public interface ICategoriaRepository {
        IEnumerable<Categoria> Categorias { get; }
    }
}
