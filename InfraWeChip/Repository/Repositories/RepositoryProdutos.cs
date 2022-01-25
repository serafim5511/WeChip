using Domain.Interfaces;
using EntitiesWeChip;
using InfraWeChip.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfraWeChip.Repository.Generics.RepositoryGenerics;

namespace Infra.Repository.Repositories
{
    public class RepositoryProdutos : RepositoryGenerics<Produtos>, IProdutos
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryProdutos()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }        
    }
}
