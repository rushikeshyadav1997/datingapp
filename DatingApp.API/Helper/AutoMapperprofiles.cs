using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.models;

namespace DatingApp.API.Helper
{
    public class AutoMapperprofiles :Profile
    {
        public AutoMapperprofiles()
        {
            CreateMap<user,UserforListDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URL))
            .ForMember(dest => dest.Age, opt =>
            opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<user,UserforDetailsDto>()
            .ForMember(dest => dest.PhotoUrl, opt =>
            opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URL))
            .ForMember(dest => dest.Age, opt =>
            opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo,PhotoforDetailsDto>();
         CreateMap<userForpdateDto,user>();
         CreateMap<Photo ,PhotoForReturnDto>();
         CreateMap<PhotoForCreationDto,Photo>();
         CreateMap<UserRegisterforDto,user>();
         CreateMap<MessageForCreationDto,Message>().ReverseMap();
         CreateMap<Message,MessageToReturnDto>()
         .ForMember(m => m.SenderPhotoUrl, opt => opt
                    .MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).URL))
                .ForMember(m => m.RecipientPhotoUrl, opt => opt
                    .MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).URL))
                    .ForMember(m => m.RecipientKonwnAs, opt => opt
                    .MapFrom(u => u.Recipient.Knownas.FirstOrDefault()));
                    




        }
    }
}