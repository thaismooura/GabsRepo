using AutoMapper;
using GabsApi.Model;

namespace GabsApi.Profiles
{
    public class OtherGabsProfile : Profile
    {
        public OtherGabsProfile()
        {
            CreateMap<OtherGabs, OtherGabsDto>();
            CreateMap<OtherGabsDto, OtherGabs>();
        }
    }
}