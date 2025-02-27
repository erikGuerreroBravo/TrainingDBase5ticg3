
using AutoMapper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingDBase5ticg3.Models;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Mapping
{
    public class WebProfile:Profile
    {
        public WebProfile()
        {
            CreateMap<profesiones, TrainingDBase5ticg3.ViewModels.ProfesionesVM>().ReverseMap();
            CreateMap<TrainingDBase5ticg3.ViewModels.PersonasVM, personas>()
                .ReverseMap()
                .ForMember(dest => dest.DireccionVM, origen => origen.MapFrom(c => c.direcciones))
                .ForMember(dest => dest.TelefonoVM, origen => origen.MapFrom(c => c.telefonos))
                .ForMember(dest => dest.ProfesionesPersonaVM, origen => origen.MapFrom(c => c.profesionesPersonas));
            CreateMap<TelefonoVM,telefonos>().ReverseMap();
            CreateMap<DireccionVM,direcciones>().ReverseMap();  
        }

        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<WebProfile>();
            });
        }
    }
}