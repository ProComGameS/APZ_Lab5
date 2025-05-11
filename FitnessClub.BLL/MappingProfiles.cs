using AutoMapper;
using FitnessClub.DAL.Models;
using FitnessClub.BLL.DTOs;

namespace FitnessClub.BLL
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Club, ClubDTO>().ReverseMap();
            CreateMap<ClassSession, ClassSessionDTO>().ReverseMap();
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<MembershipCard, MembershipCardDTO>().ReverseMap();
        }
    }
}