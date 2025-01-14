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

            CreateMap<TicketReplyEntity, ReplyModel>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.Tid));

            CreateMap<TicketReplyEntity, ReplyModel>().ReverseMap();
            CreateMap<CreateReplyModel, TicketReplyEntity>()
                .ForMember(dest => dest.Tid, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.Reply, opt => opt.MapFrom(src => src.Reply))
                .ForMember(dest => dest.ReplyDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
 