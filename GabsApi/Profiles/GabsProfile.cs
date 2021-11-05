using AutoMapper;
using GabsApi.Model;

namespace GabsApi.Profiles
{
    public class GabsProfile : Profile
    {
        public GabsProfile()
        {
            CreateMap<Gabs, GabsDto>();
        }
    }
}