namespace Avaliar.Envelope.Motor
{
    public class EnvelopeGenerico<T> where T : class
    {
        public List<T> Dados { get; set; }

        public StatusRetorno Status { get; set; }

        public PaginacaoRetorno Paginacao { get; set; }

        public string LinkCreate { get; set; }

        public string Versao { get; set; }

        public EnvelopeGenerico()
        {
            this.Dados = new List<T>();
            this.Status = new StatusRetorno();
            this.Paginacao = new PaginacaoRetorno();
        }
    }
}
