using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaService.Api.Book.Models;

namespace TiendaService.Api.Book.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, BookDto>();
        }
    }
}
