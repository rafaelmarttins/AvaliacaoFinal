using Avaliar.Poco;
using System.Drawing;

namespace Avaliar.Envelope.Modelo
{
    public class TipoRebanhoEnvelope : BaseEnvelope
    {
        public int CodigoTipoRebanho { get; set; }
        public string Descricao { get; set; } = null!;
        public bool? Situacao { get; set; }
        public DateTime? DataDeInsercao { get; set; }

        public TipoRebanhoEnvelope(TipoRebanhoPoco poco)
        {
            CodigoTipoRebanho = poco.CodigoTipoRebanho;
            Descricao = poco.Descricao;
            Situacao = poco.Situacao;
            DataDeInsercao = poco.DataDeInsercao;
        }

        public override void SetLinks()
        {
            Links.List = "GET /tiporebanho";
            Links.Self = "GET /tiporebanho/" + CodigoTipoRebanho.ToString();
            Links.Exclude = "DELETE /tiporebanho/" + CodigoTipoRebanho.ToString();
            Links.Update = "PUT /tiporebanho";
        }
    }
}
