using AutoMapper;
using AutoMapper.Configuration;
using LGK.Geckos.Models;
using LGK.Geckos.ViewModels;
using System.Reflection;

namespace LGK.Geckos.MappingConfiguration
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<GeckoViewModel, Gecko>();
            CreateProjection<Gecko, GeckoViewModel>();
        }
    }
}
