using AutoMapper;
using Cronos.Domain.Entidades;
using Cronos.Domain.Interfaces.Map;
using Cronos.Domain.ObjectValues;
using Cronos.Domain.Request;
using System;

namespace Cronos.Domain.Mapper
{
    public class Mapeamento : IMapeamento 
    {
        private IMapper _Mapper { get; set; }

        public Mapeamento()
        {
            AutoMapper.MapperConfiguration configuration = new AutoMapper.MapperConfiguration( cfg => {

                cfg.CreateMap<UserRequest, Usuario>()
                    .ForPath(e => e.DataInclusao, p => p.MapFrom(prop => DateTime.Now))
                    .ForPath(e => e.Password, p => p.MapFrom(prop => prop.Senha.ConvertToMD5()))
                    .ForPath(e => e.Situacao, p => p.MapFrom(prop => true));

                cfg.CreateMap<UserRequest, Salario>()
                    .ForPath(e => e.SoudoBruto , p => p.MapFrom(prop => Convert.ToDouble(prop.SoudoBruto)) )
                    .ForPath(e => e.SoudoLiquido, p => p.MapFrom(prop => Convert.ToDouble(prop.SoudoLiquido)))
                    .ForPath(e => e.Situacao, p => p.MapFrom(prop => true ));

               cfg.CreateMap<LivroRequest, Livro>()
                    .ForPath(e => e.NumPaginas, p => p.MapFrom(prop => Convert.ToDouble( prop.NumPaginas )))
                    .ForPath(e => e.Valor, p => p.MapFrom(prop => Convert.ToDouble( prop.Valor )))
                    .ForPath(e => e.Situacao, p => p.MapFrom(prop => true))
                    .ForPath(e => e.DataInclusao, p => p.MapFrom(prop => DateTime.Now))
                    .ForPath(e => e.Situacao, p => p.MapFrom(prop => true ));
            });

            this._Mapper = configuration.CreateMapper();
        }

        public Usuario MapUsuario(UserRequest request)
        {
            Usuario resp = _Mapper.Map<Usuario>(request);
            resp.Salario = _Mapper.Map<Salario>(request);
            return resp;
        }

        public Salario MapSalario(UserRequest request)
        {
            return _Mapper.Map<Salario>(request);
        }

        public Livro MapLivro(LivroRequest request)
        {
            return _Mapper.Map<Livro>(request);
        }
    }
}
