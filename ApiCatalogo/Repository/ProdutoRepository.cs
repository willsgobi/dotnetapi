using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository {
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository {

        public ProdutoRepository(AppDbContext context) : base(context) {

        }
        public async Task<IEnumerable<Produto>> GetProdutosPorPreco() {
            return await Get().OrderBy(c => c.Preco).ToListAsync();
        }
    }
}
