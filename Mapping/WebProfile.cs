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
            CreateMap<profesiones, ProfesionesVM>().ReverseMap(); 
            CreateMap<PersonasVM,personas>().ReverseMap();

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