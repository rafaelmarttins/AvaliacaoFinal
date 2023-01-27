using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Envelope.Motor
{
    using Newtonsoft.Json;

    public class StatusRetorno
    {
        [JsonProperty(propertyName: "codigo")]
        public int? Codigo { get; set; }

        [JsonProperty(propertyName: "mensagem")]
        public string Mensagem { get; set; }
    }
}
