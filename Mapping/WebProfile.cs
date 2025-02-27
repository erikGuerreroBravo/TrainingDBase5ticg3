
using AutoMapper;
using TrainingDBase5ticg3.Models;
using TrainingDBase5ticg3.ViewModels;

namespace TrainingDBase5ticg3.Mapping
{
    public class WebProfile:Profile
    {
        public WebProfile()
        {
            CreateMap<profesiones, TrainingDBase5ticg3.ViewModels.ProfesionesVM>().ReverseMap(); 
            CreateMap<TrainingDBase5ticg3.ViewModels.PersonasVM,TrainingDBase5ticg3.Models.personas>()
                .ForMember(dest=> dest.direcciones, origen=> origen.MapFrom(c=> c.DireccionVM))
                .ForMember(dest => dest.telefonos, origen => origen.MapFrom(c => c.TelefonoVM))
                .ForMember(dest => dest.profesionesPersonas, origen => origen.MapFrom(c => c.ProfesionesPersonaVM)).ReverseMap();

            CreateMap<TrainingDBase5ticg3.ViewModels.TelefonoVM,telefonos>().ReverseMap();
            CreateMap<TrainingDBase5ticg3.ViewModels.DireccionVM,direcciones>().ReverseMap();
            CreateMap<TrainingDBase5ticg3.ViewModels.ProfesionesPersonaVM, profesionesPersonas>().ReverseMap();
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