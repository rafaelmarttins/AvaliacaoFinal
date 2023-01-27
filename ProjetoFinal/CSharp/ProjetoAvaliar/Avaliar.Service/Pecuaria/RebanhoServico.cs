using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Avaliar.Domain.EF;
using Avaliar.Poco;
using Avaliar.Service.Base;

namespace Avaliar.Service.Pecuaria
{
    public class RebanhoServico : ServicoGenerico<Rebanho, RebanhoPoco>
    {
        public RebanhoServico(AvaliarContext contexto) : base(contexto)
        { }

        public override List<RebanhoPoco> Consultar(Expression<Func<Rebanho, bool>>? predicate = null)
        {
            IQueryable<Rebanho> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return this.ConverterPara(query);
        }

        public override List<RebanhoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Rebanho> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return this.ConverterPara(query);
        }

        public override List<RebanhoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Rebanho, bool>>? predicate = null)
        {
            IQueryable<Rebanho> query;
            if (skip == null)
            {
                if (predicate == null)
                {
                    query = this.genrepo.Browseable(null);
                }
                else
                {
                    query = this.genrepo.Browseable(predicate);
                }
            }
            else
            {
                if (predicate == null)
                {
                    query = this.genrepo.GetAll(take, skip);
                }
                else
                {
                    query = this.genrepo.Searchable(take, skip, predicate);
                }
            }
            return this.ConverterPara(query);
        }

        public override List<RebanhoPoco> ConverterPara(IQueryable<Rebanho> query)
        {
            return query.Select(reb =>
                new RebanhoPoco()
                {
                    CodigoRebanho = reb.CodigoRebanho,
                    CodigoTipoRebanho = reb.CodigoTipoRebanho,
                    AnoReferencia = reb.AnoReferencia,
                    CodigoIBGE7 = reb.CodigoIBGE7,
                    NomeMunicipio = reb.NomeMunicipio,
                    SiglaUF = reb.SiglaUF,
                    Situacao = reb.Situacao,
                    DataDeInsercao = reb.DataDeInsercao,

                }).ToList();
        }

        public override int ContarTotalRegistros(Expression<Func<Rebanho, bool>>? predicate)
        {
            IQueryable<Rebanho> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return query.Count();
        }
    }
}
