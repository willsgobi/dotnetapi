using ApiCatalogo.Models;
using ApiCatalogo.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository {
    public interface ICategoriaRepository : IRepository<Categoria> {

        PagedList<Categoria> GetCategorias(CategoriaParameters categoriaParameters);
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();

    }
}
