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
    public class TipoRebanhoServico : ServicoGenerico<TipoRebanho, TipoRebanhoPoco>
    {
        public TipoRebanhoServico(AvaliarContext contexto) : base(contexto)
        { }

        public override List<TipoRebanhoPoco> Consultar(Expression<Func<TipoRebanho, bool>>? predicate = null)
        {
            IQueryable<TipoRebanho> query;
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

        public override List<TipoRebanhoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoRebanho> query;
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

        public override List<TipoRebanhoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoRebanho, bool>>? predicate = null)
        {
            IQueryable<TipoRebanho> query;
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

        public override List<TipoRebanhoPoco> ConverterPara(IQueryable<TipoRebanho> query)
        {
            return query.Select(tip =>
                new TipoRebanhoPoco()
                {
                    CodigoTipoRebanho = tip.CodigoTipoRebanho,
                    Descricao = tip.Descricao,
                    Situacao = tip.Situacao,
                    DataDeInsercao = tip.DataDeInsercao
                }).ToList();
        }

        public override int ContarTotalRegistros(Expression<Func<TipoRebanho, bool>>? predicate)
        {
            IQueryable<TipoRebanho> query;
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
