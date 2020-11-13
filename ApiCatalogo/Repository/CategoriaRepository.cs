using ApiCatalogo.Context;
using ApiCatalogo.Models;
using ApiCatalogo.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository {
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository {
        public CategoriaRepository(AppDbContext context) : base(context) {
        }

        public PagedList<Categoria> GetCategorias(CategoriaParameters categoriaParameters) {
            return PagedList<Categoria>.ToPagedList(Get().OrderBy(IReadOnlyCollection => IReadOnlyCollection.Nome),
                categoriaParameters.PageNumber, categoriaParameters.PageSize);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasProdutos() {
            return await Get().Include(x => x.Produtos).ToListAsync();
            ;
        }
    }
}
