using Cronos.Mapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Mappers;
using AutoMapper;
using AutoMapper.Configuration;

namespace Cronos.Mapper
{
    public class ObjectMap : IObjectMap
    {
        private AutoMapper.IMapper _Mapper { get; set; }

        public ObjectMap()
        {
            AutoMapper.MapperConfiguration configuration = new AutoMapper.MapperConfiguration(new MapperConfigurationExpression());

            this._Mapper = configuration.CreateMapper();
        }
    }
}
