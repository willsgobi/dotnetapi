using ApiCatalogo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCatalogo.Repository {
    public interface IProdutoRepository : IRepository<Produto> {

        Task<IEnumerable<Produto>> GetProdutosPorPreco();

    }
}
