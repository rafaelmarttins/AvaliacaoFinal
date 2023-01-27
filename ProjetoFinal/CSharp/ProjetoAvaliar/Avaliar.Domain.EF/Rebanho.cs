using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Domain.EF
{
    [Table("Rebanho", Schema = "dbo")]
    public partial class Rebanho
    {
        [Key]
        [Column(name: "IdRebanho")]
        public int CodigoRebanho { get; set; }

        [Column(name: "IdTipoRebanho")]
        public int CodigoTipoRebanho { get; set; }

        [Column(name: "AnoRef")]
        public int AnoReferencia { get; set; }

        [Column(name: "IBGE7")]
        public int CodigoIBGE7 { get; set; }

        [Column(name: "NomeMunicipio")]
        [Unicode(false)]
        public string NomeMunicipio { get; set; } = null!;

        [Column(name: "SiglaUF")]
        [Unicode(false)]
        [StringLength(2)]
        public string SiglaUF { get; set; } = null!;

        [Column(name: "Ativo")]
        public bool? Situacao { get; set; }

        [Column(name: "DataInclusao", TypeName = "datetime")]
        public DateTime? DataDeInsercao { get; set; }
    }
}
