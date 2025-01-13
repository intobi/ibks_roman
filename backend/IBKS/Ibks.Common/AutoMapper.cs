using AutoMapper;
using Ibks.Models.TicketModels;
using Ibks.Data.Entities;
using Ibks.Models.TicketReplyModels;

namespace Ibks.Common
{
    public class TicketAutoMapper : Profile
    {
        public TicketAutoMapper()
        {
            CreateMap<TicketEntity, TicketModel>()
               .ForMember(dest => dest.Lvl, opt => opt.MapFrom(src => src.Priority.Title))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
               .ForMember(dest => dest.Module, opt => opt.MapFrom(src => src.ApplicationName))
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LogType.Title))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Status.Title)); ;

            CreateMap<TicketEntity, TicketListItemModel>()
               .ForMember(dest => dest.Lvl, opt => opt.MapFrom(src => src.Priority.Title)) 
               .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Id)) 
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)) 
               .ForMember(dest => dest.Module, opt => opt.MapFrom(src => src.ApplicationName)) 
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LogType.Title)) 
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Status.Title));

            CreateMap<TicketReplyEntity, TicketReplyModel>().ReverseMap();
        }
    }
}
 