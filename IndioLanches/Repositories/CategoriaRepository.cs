﻿using IndioLanches.Context;
using IndioLanches.Models;
using IndioLanches.Repositories.Interfaces;

namespace IndioLanches.Repositories {
    public class CategoriaRepository : ICategoriaRepository {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context) {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
