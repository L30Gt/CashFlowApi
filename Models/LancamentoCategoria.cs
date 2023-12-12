using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowApi.Models
{
    public class LancamentoCategoria
    {
        public int LancamentoId { get; set; }
        public Lancamento Lancamento { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}