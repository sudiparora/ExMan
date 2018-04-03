using AutoMapper;
using ExMan.DTO;
using ExMan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExMan.Shared.Core.AutoMapper
{
    public class DTOToEntityMapper : Profile
    {

        public DTOToEntityMapper()
        {
            CreateMap<ComponentTypeDTO, ComponentType>().ReverseMap();
            
        }

    }
}
