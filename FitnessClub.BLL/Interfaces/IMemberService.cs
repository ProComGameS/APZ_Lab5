using FitnessClub.BLL.DTOs;

namespace FitnessClub.BLL.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberDTO> GetAllMembers();
        MemberDTO GetMemberById(int id);
        bool CreateMember(MemberDTO memberDTO);
        bool UpdateMember(MemberDTO memberDTO);
        bool DeleteMember(int memberId);
    }
}