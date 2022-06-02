using IndioLanches.Context;
using IndioLanches.Models;
using IndioLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IndioLanches.Repositories {
    public class LancheRepository : ILancheRepository {
       
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context) {
            _context = context;
        }

        //retornará todos os lanches incluindo-os à suas respectivas categorias
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(x => x.Categoria); 

        //retornará os lanches preferidos incluindo os lanches preferidos as suas respectivas categorias.
        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
                                .Where(x => x.LanchePreferido) //onde lanche favorito for igual à true.
                                .Include(x => x.Categoria);

        //retorna um lanche pelo seu id.
        public Lanche GetLancheById(int id)
           => _context.Lanches.FirstOrDefault(x => x.LancheId == id);
    }
}
