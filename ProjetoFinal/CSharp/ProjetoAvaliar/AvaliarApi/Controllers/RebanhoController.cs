using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Avaliar.Domain.EF;
using Avaliar.Poco;
using LinqKit;
using Avaliar.Service.Pecuaria;
using Avaliar.Envelope.Motor;
using Avaliar.Envelope.Modelo;


namespace AvaliarApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/pecuaria/[controller]")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {

        public RebanhoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public RebanhoController(AvaliarContext contexto) : base()
        {
            this.servico = new RebanhoServico(contexto);
        }

        /// <summary>
        /// Lista todos os registros de Rebanho por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<RebanhoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<RebanhoPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros da tabela Rebanho por código Tipo Rebanho.
        /// </summary>
        /// <param name="tipcod"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorTipoRebanho/{tipcod:int}")]
        public ActionResult<List<RebanhoPoco>> GetByTipoRebanho(int tipcod)
        {
            try
            {
                List<RebanhoPoco> listaPoco = this.servico.Consultar(cid => (cid.CodigoTipoRebanho == tipcod)).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Rebanho.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<RebanhoPoco> GetById(int chave)
        {
            try
            {
                RebanhoPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado em Rebanho.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<RebanhoPoco> Post([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente em Cidade.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<RebanhoPoco> Put([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente em Rebanho, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<RebanhoPoco> DeleteById(int chave)
        {
            try
            {
                RebanhoPoco poco = this.servico.Excluir(chave);
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
        public ActionResult<EnvelopeGenerico<RebanhoEnvelope>> GetAllEnvelope(int? limite = null, int? salto = null)
        {
            try
            {
                List<RebanhoPoco> listaPoco = this.servico.Listar(limite, salto);
                int totalReg = listaPoco.Count;
                return Envelopamento(totalReg, limite, salto, listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros de modo envelopado para o arquivo JSON filtrados pela sigla UF de Rebanho.
        /// </summary>
        /// <param name="siglaUF"></param>
        /// <param name="limite"></param>
        /// <param name="salto"></param>
        /// <returns></returns>
        [HttpGet("envelope/PorMunicipio/{siglaUF}")]
        public ActionResult<EnvelopeGenerico<RebanhoEnvelope>> GetPorMunicipio(string siglaUF, int? limite = null, int? salto = null)
        {
            try
            {
                List<RebanhoPoco> listaPoco;
                var predicado = PredicateBuilder.New<Rebanho>(true);
                int totalReg = 0;

                if (limite == null)
                {
                    if (salto != null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.SiglaUF == siglaUF);
                        listaPoco = this.servico.Consultar(predicado);
                        totalReg = listaPoco.Count;
                        return Envelopamento(totalReg, limite, salto, listaPoco);
                    }
                }
                else
                {
                    if (salto == null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.SiglaUF == siglaUF);
                        listaPoco = this.servico.Vasculhar(limite, salto, predicado);
                        totalReg = this.servico.ContarTotalRegistros(predicado);
                        return Envelopamento(totalReg, limite, salto, listaPoco);
                    }
                    
                }
             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        /// <summary>
        /// Retorna todos os registros de modo envelopado para o arquivo JSON filtrados pelo código UF de Estado.
        /// </summary>
        /// <param name="tipcod"></param>
        /// <param name="limite"></param>
        /// <param name="salto"></param>
        /// <returns></returns>
        [HttpGet("envelope/PorTipoRebanho/{tipcod:int}")]
        public ActionResult<EnvelopeGenerico<RebanhoEnvelope>> GetPorEstadoEnvelope(int tipcod, int? limite = null, int? salto = null)
        {
            try
            {
                List<RebanhoPoco> listaPoco;
                var predicado = PredicateBuilder.New<Rebanho>(true);
                int totalReg = 0;
                if (limite == null)
                {
                    if (salto != null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.CodigoTipoRebanho == tipcod);
                        listaPoco = this.servico.Consultar(predicado);
                        totalReg = listaPoco.Count;
                        return Envelopamento(totalReg, limite, salto, listaPoco);
                    }
                }
                else
                {
                    if (salto == null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.CodigoTipoRebanho == tipcod);
                        totalReg = this.servico.ContarTotalRegistros(predicado);
                        listaPoco = this.servico.Vasculhar(limite, salto, predicado);
                        return Envelopamento(totalReg, limite, salto, listaPoco);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private ActionResult<EnvelopeGenerico<RebanhoEnvelope>> Envelopamento(int? totalReg, int? limite, int? salto, List<RebanhoPoco> listaPoco)
        {
            string linkPost = "POST /rebanho";

            ListEnvelope<RebanhoEnvelope> list;

            if (limite > totalReg)
            {
                string erro = "Limite não pode ser maior que a quantidade de Registros.";
                list = new ListEnvelope<RebanhoEnvelope>(null, 400, erro, linkPost, "1.0");
                return BadRequest(list.Etapa);
            }
            else
            {
                List<RebanhoEnvelope> listaEnvelope = listaPoco.Select(reb => new RebanhoEnvelope(reb)).ToList();
                listaEnvelope.ForEach(item => item.SetLinks());

                if (listaPoco.Count() == 0)
                {
                    list = new ListEnvelope<RebanhoEnvelope>(listaEnvelope, 404, "Não existem mais registros a serem mostrados!.", linkPost, "1.0");
                    return Ok(list.Etapa);
                }

                if (salto == null)
                {
                    list = new ListEnvelope<RebanhoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                    list.Etapa.Paginacao.TotalReg = totalReg;
                }
                else
                {
                    var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}");
                    string urlServidor = location.AbsoluteUri;
                    list = new ListEnvelope<RebanhoEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0", urlServidor, salto, limite, totalReg);
                }
                return Ok(list.Etapa);
            }
        }

        /// <summary>
        /// Retorna todos os registros por ID de modo envelopado para o arquivo JSON
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("envelope/{chave:int}")]
        public ActionResult<RebanhoEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                RebanhoPoco poco = this.servico.PesquisarPorChave(chave);
                RebanhoEnvelope envelope = new RebanhoEnvelope(poco);
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
