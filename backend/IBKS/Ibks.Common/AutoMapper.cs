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
               .ForMember(dest => dest.Lvl, opt => opt.MapFrom(src => src.PriorityId))
               .ForMember(dest => dest.Module, opt => opt.MapFrom(src => src.ApplicationName))
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TicketTypeId))
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.StatusId))
               .ReverseMap(); 

            CreateMap<TicketEntity, TicketListItemModel>()
               .ForMember(dest => dest.Lvl, opt => opt.MapFrom(src => src.Priority.Title)) 
               .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Id)) 
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title)) 
               .ForMember(dest => dest.Module, opt => opt.MapFrom(src => src.ApplicationName)) 
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TicketType.Title)) 
               .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Status.Title));

            CreateMap<TicketReplyEntity, TicketReplyModel>().ReverseMap();

            CreateMap<TicketReplyEntity, ReplyModel>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.Tid));

            CreateMap<TicketReplyEntity, ReplyModel>().ReverseMap();
            CreateMap<CreateReplyModel, TicketReplyEntity>()
                .ForMember(dest => dest.Tid, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.Reply, opt => opt.MapFrom(src => src.Reply))
                .ForMember(dest => dest.ReplyDate, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateTicketModel, TicketEntity>()
                 .ForMember(dest => dest.ApplicationName, opt => opt.MapFrom(src => src.Module))
                 .ForMember(dest => dest.PriorityId, opt => opt.MapFrom(src => src.Lvl))
                 .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.State))
                 .ForMember(dest => dest.TicketTypeId, opt => opt.MapFrom(src => src.Type))
                 .ForMember(dest => dest.Date, opt => opt.MapFrom(_ => DateTime.UtcNow))
                 .ForMember(dest => dest.InstalledEnvironmentId, opt => opt.MapFrom(_ => 1))
                 .ForMember(dest => dest.LastModified, opt => opt.MapFrom(_ => DateTime.UtcNow))
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(_ => 1)) 
                 .ForMember(dest => dest.ApplicationId, opt => opt.MapFrom(_ => 1));

        }
    }
}
 