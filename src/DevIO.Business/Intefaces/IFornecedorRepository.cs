using System;
using System.Threading.Tasks;
using DevIO.Business.Models;

namespace DevIO.Business.Intefaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        //alem das funcões genéricas instaciada IRepository, incluido mais dois abaixos mais específicos

        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}