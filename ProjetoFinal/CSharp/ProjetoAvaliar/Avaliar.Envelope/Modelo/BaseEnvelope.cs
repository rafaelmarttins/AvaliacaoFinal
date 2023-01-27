namespace Avaliar.Envelope.Modelo
{
    using Newtonsoft.Json;

    public abstract class BaseEnvelope
    {
        [JsonProperty(propertyName: "_links")]
        public DataLinks Links { get; set; }

        public abstract void SetLinks();

        public BaseEnvelope()
        {
            Links = new DataLinks();

        }
    }
}
