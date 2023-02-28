using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using contacts_lib.models.DTO;
using contacts_lib.models.entities;
namespace contacts_lib.mapper
{
    public class RepositoryMapper
    {
        public Mapper mapper {get; private set;};
        private MapperConfiguration _mapperConfig = new MapperConfiguration(cfg => {
            cfg.CreateMap<User, UserDTO>().ReverseMap();
        });
        public RepositoryMapper()
        {
            mapper = new Mapper(_mapperConfig);
        }
    }
}