using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CashFlowApi.Models;
using CashFlowApi.Models.Enuns;
using CashFlowApi.Utils;

namespace CashFlowApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Lancamento> TB_LANCAMENTOS { get; set; }
        public DbSet<Usuario> TB_USUARIOS { get; set; }
        public DbSet<Categoria> TB_CATEGORIAS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lancamento>().HasData
            (
                new Lancamento() { Id = 1, TipoLancamento = TipoLancamentoEnum.Receita, Descricao = "Salario de Novembro", Valor = 5000.00m, DataLancamento = new DateTime(2023, 11, 25)},
                new Lancamento() { Id = 2, TipoLancamento = TipoLancamentoEnum.Despesa, Descricao = "Aluguel de Novembro", Valor = 1200.00m, DataLancamento = new DateTime(2023, 11, 10)}
            );

            modelBuilder.Entity<Categoria>().HasData
            (
                new Categoria() { Id = 1, Nome = "Salario"},
                new Categoria() { Id = 2, Nome = "Aluguel"}
            );
            
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte []salt);
            user.Id = 1;
            user.Username = "Admin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            modelBuilder.Entity<Usuario>().HasData(user);
        }
    }
}