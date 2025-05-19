using FitnessClub.BLL.DTOs;
using FitnessClub.DAL.Models;

namespace FitnessClub.BLL.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDTO> GetAllClubs();
        ClubDTO GetClubById(int id);
        void CreateClub(ClubDTO clubDTO);
        bool RegisterForSession(int sessionId, int memberId);
        bool BuySubscription(int clubId, int memberId, CardType cardType);
        bool BuyNetworkSubscription(int memberId);
    }
}