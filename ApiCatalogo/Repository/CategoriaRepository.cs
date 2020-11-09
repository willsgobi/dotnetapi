using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository {
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository {
        public CategoriaRepository(AppDbContext context) : base(context) {
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos() {
            return await Get().Include(x => x.Produtos).ToListAsync();
            ;
        }
    }
}
