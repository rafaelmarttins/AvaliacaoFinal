using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Poco
{
    public class RebanhoPoco
    {
        public int CodigoRebanho { get; set; }
        public int CodigoTipoRebanho { get; set; }
        public int AnoReferencia { get; set; }
        public int CodigoIBGE7 { get; set; }
        public string NomeMunicipio { get; set; } = null!;
        public string SiglaUF { get; set; } = null!;
        public bool? Situacao { get; set; }
        public DateTime? DataDeInsercao { get; set; }

        public RebanhoPoco()
        { }
    }
}
