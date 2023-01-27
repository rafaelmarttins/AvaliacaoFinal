using Avaliar.Domain.EF;
using Avaliar.Envelope.Modelo;
using Avaliar.Envelope.Motor;
using Avaliar.Poco;
using Avaliar.Service.Pecuaria;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliarApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/pecuaria/[controller]")]
    [ApiController]
    public class TipoRebanhoController : ControllerBase
    {

        public TipoRebanhoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public TipoRebanhoController(AvaliarContext contexto) : base()
        {
            this.servico = new TipoRebanhoServico(contexto);
        }

        /// <summary>
        /// Lista todos os registros de Tipo Rebanho por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<TipoRebanhoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoRebanhoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Tipo Rebanho.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<TipoRebanhoPoco> GetById(int chave)
        {
            try
            {
                TipoRebanhoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Tipo Rebanho.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<TipoRebanhoPoco> Post([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Tipo Rebanho.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<TipoRebanhoPoco> Put([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente em Tipo Rebanho, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<TipoRebanhoPoco> DeleteById(int chave)
        {
            try
            {
                TipoRebanhoPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }






        /// <summary>
        /// Retorna todos os registros de modo envelopado para o arquivo JSON
        /// </summary>
        /// <param name="limite"></param>
        /// <param name="salto"></param>
        /// <returns></returns>
        [HttpGet("envelope/")]
        public ActionResult<EnvelopeGenerico<TipoRebanhoEnvelope>> GetAllEnvelope(int? limite = null, int? salto = null)
        {
            try
            {
                List<TipoRebanhoPoco> listaPoco = this.servico.Listar(limite, salto);
                string linkPost = "POST /tiporebanho";
                ListEnvelope<TipoRebanhoEnvelope> list;

                if (limite > listaPoco.Count())
                {
                    string erro = "Limite não pode ser maior que a quantidade de Registros.";
                    list = new ListEnvelope<TipoRebanhoEnvelope>(null, 400, erro, linkPost, "1.0");
                    return BadRequest(list.Etapa);
                }
                else
                {
                    List<TipoRebanhoEnvelope> listaEnvelope = listaPoco.Select(tip => new TipoRebanhoEnvelope(tip)).ToList();
                    listaEnvelope.ForEach(item => item.SetLinks());

                    if (salto == null)
                    {
                        list = new ListEnvelope<TipoRebanhoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                    }
                    else
                    {
                        var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}");
                        string urlServidor = location.AbsoluteUri;
                        list = new ListEnvelope<TipoRebanhoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0", urlServidor, salto, limite);
                    }
                    return Ok(list.Etapa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros por ID de modo envelopado para o arquivo JSON
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("envelope/{chave:int}")]
        public ActionResult<TipoRebanhoEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                TipoRebanhoPoco poco = this.servico.PesquisarPorChave(chave);
                TipoRebanhoEnvelope envelope = new TipoRebanhoEnvelope(poco);
                envelope.SetLinks();
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
