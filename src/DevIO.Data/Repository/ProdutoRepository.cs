using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    //alem de herdar e usar as funçoes da classe genérica, podendo implementar outras funções específicos para essa classe
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        //recebe base dados abstract do repositoy genérico para manipular base de dados
        public ProdutoRepository(MeuDbContext context) : base(context) { }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            //fazendo inner join com o fornecedor por id
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            //fazendo inner join com o fornecedor por nome e order by nome
            return await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            //buscar somente o id do fornecedor informado
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}