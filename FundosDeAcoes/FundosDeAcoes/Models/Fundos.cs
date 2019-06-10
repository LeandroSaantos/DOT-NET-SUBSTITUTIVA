using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundosDeAcoes.Models
{
    public class Fundos
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int Qtd { get; set; }
        public Decimal Preco { get; set; }
    }
}
