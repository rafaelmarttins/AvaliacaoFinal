using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Mapping.Base
{
    public class GenericoMap<TDominio, TPoco>
        where TDominio : class
        where TPoco : class
    {
        public IMapper Mapping { get; }

        public GenericoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TDominio, TPoco>();
                cfg.CreateMap<TPoco, TDominio>();
            });
            this.Mapping = configuration.CreateMapper();
        }
    }
}