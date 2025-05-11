using FitnessClub.DAL.Models;

namespace FitnessClub.BLL.DTOs
{
    public class MembershipCardDTO
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public CardType CardType { get; set; } 
        public int MemberId { get; set; }
    }
}