using Avaliar.Poco;

namespace Avaliar.Envelope.Modelo
{
    public class RebanhoEnvelope : BaseEnvelope
    {
        public int CodigoRebanho { get; set; }
        public int CodigoTipoRebanho { get; set; }
        public int AnoReferencia { get; set; }
        public int CodigoIBGE7 { get; set; }
        public string NomeMunicipio { get; set; } = null!;
        public string SiglaUF { get; set; } = null!;
        public bool? Situacao { get; set; }
        public DateTime? DataDeInsercao { get; set; }

        public RebanhoEnvelope(RebanhoPoco poco)
        {
            CodigoRebanho = poco.CodigoRebanho;
            CodigoTipoRebanho = poco.CodigoTipoRebanho;
            AnoReferencia = poco.AnoReferencia;
            CodigoIBGE7 = poco.CodigoIBGE7;
            NomeMunicipio = poco.NomeMunicipio;
            SiglaUF = poco.SiglaUF;
            Situacao = poco.Situacao;
            DataDeInsercao = poco.DataDeInsercao;
        }

        public override void SetLinks()
        {
            Links.List = "GET /rebanho";
            Links.Self = "GET /rebanho/" + CodigoRebanho.ToString();
            Links.Exclude = "DELETE /rebanho/" + CodigoRebanho.ToString();
            Links.Update = "PUT /rebanho";
        }
    }
}
