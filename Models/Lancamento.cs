using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using CashFlowApi.Models.Enuns;

namespace CashFlowApi.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
        public string Descricao { get; set; } = string.Empty;


        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public DateTime DataLancamento { get; set; }
    }

}