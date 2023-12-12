using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlowApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
        public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

        [NotMapped]
        public string PasswordString { get; set; } = string.Empty;
        public DateTime? DataAcesso { get; set; }

        public List<Lancamento>? Lancamentos { get; set; }
    }
}

