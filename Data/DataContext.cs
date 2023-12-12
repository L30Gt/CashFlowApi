using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CashFlowApi.Models;
using CashFlowApi.Models.Enuns;

namespace CashFlowApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Lancamento> TB_LANCAMENTOS { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lancamento>().HasData
            (
                new Lancamento() { Id = 1, TipoLancamento = TipoLancamentoEnum.Receita, Descricao = "Salario de Novembro", Valor = 5000.00m, DataLancamento = new DateTime(2023, 11, 25)},
                new Lancamento() { Id = 2, TipoLancamento = TipoLancamentoEnum.Despesa, Descricao = "Aluguel de Novembro", Valor = 1200.00m, DataLancamento = new DateTime(2023, 11, 10)}
            );
        }
    }
}