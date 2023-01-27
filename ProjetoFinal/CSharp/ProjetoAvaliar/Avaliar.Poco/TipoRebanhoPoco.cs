using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Poco
{
    public class TipoRebanhoPoco
    {
        public int CodigoTipoRebanho { get; set; }
        public string Descricao { get; set; } = null!;
        public bool? Situacao { get; set; }
        public DateTime? DataDeInsercao { get; set; }

        public TipoRebanhoPoco()
        { }
    }
}
