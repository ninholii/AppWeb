using System;
using Dyrt.Business.Interfaces;
using Dyrt.Business.Models;
using System.Threading.Tasks;
using Dyrt.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Dyrt.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DyrtContext context) : base(context)
        {
        }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
