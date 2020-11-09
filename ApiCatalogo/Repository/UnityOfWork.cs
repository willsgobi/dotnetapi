﻿using ApiCatalogo.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository {
    public class UnityOfWork : IUnityOfWork {
        private ProdutoRepository _produtoRepository;
        private CategoriaRepository _categoriaRepository;
        public AppDbContext _context;

        public UnityOfWork(AppDbContext context) {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository {
            get {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository {
            get {
                return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
            }
        }
        
        public async Task Commit() {
            await _context.SaveChangesAsync();
        }
        public void Dispose() {
            _context.Dispose();
        }
    }
}
