using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaService.Api.Author.Models.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Author, Models.Application.AuthorDto>();
        }
    }
}
