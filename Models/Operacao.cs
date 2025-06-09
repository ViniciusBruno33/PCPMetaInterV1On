using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCPMetalurgicaInter.Models
{
    public class Operacao
    {
        public required int Id { get; set; }
        public required string Descricao { get; set; }
        public virtual TipoDeOperacao? TipoDeOperacao { get; set; }
        public required int TipoDeOperacaoId { get; set; }
        public virtual List<Apontamento>? Apontamentos{ get; }
        public virtual List<PecaOperacao>? PecaOperacaoes { get; }
    }
}