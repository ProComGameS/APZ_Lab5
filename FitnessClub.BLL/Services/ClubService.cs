using System.Collections.Generic;
using System.Linq;
using FitnessClub.DAL;
using FitnessClub.BLL.DTOs;
using FitnessClub.DAL.Models;
using AutoMapper;
using FitnessClub.BLL.Interfaces;

namespace FitnessClub.BLL.Services
{
    public class ClubService : IClubService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClubService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ClubDTO> GetAllClubs()
        {
            var clubs = _unitOfWork.GetRepository<Club>().GetAll();
            return _mapper.Map<IEnumerable<ClubDTO>>(clubs);
        }

        public ClubDTO GetClubById(int id)
        {
            var club = _unitOfWork.GetRepository<Club>().GetById(id);
            return _mapper.Map<ClubDTO>(club);
        }

        public void CreateClub(ClubDTO clubDTO)
        {
            var club = _mapper.Map<Club>(clubDTO);
            _unitOfWork.GetRepository<Club>().Insert(club);
            _unitOfWork.Complete();
        }

        public bool RegisterToSession(int sessionId, int membershipCardId)
        {
            var session = _unitOfWork.GetRepository<ClassSession>().GetById(sessionId);
            var card = _unitOfWork.GetRepository<MembershipCard>().GetById(membershipCardId);
            if (session == null || card == null)
                return false;

            if (session.Visits.Count >= session.Capacity)
                return false;

            Visit newVisit = new Visit
            {
                VisitDate = DateTime.Now,
                ClassSessionId = sessionId,
                MembershipCardId = membershipCardId
            };

            _unitOfWork.GetRepository<Visit>().Insert(newVisit);
            _unitOfWork.Complete();
            return true;
        }

        
        public bool BuyNetworkSubscription(int memberId)
        {
            var existingMembership = _unitOfWork.GetRepository<MembershipCard>()
                .GetAll()
                .FirstOrDefault(m => m.MemberId == memberId);

            if (existingMembership != null)
                return false;

            var newMembership = new MembershipCard
            {
                MemberId = memberId,
                CardType = CardType.NetworkSubscription
            };

            _unitOfWork.GetRepository<MembershipCard>().Insert(newMembership);
            _unitOfWork.Complete();
            return true;
        }

        
        
        public bool RegisterForSession(int sessionId, int memberId)
        {
            var session = _unitOfWork.GetRepository<ClassSession>().GetById(sessionId);
            var member = _unitOfWork.GetRepository<Member>().GetById(memberId);

            if (session == null || member == null)
                return false;

            if (session.Visits.Count >= session.Capacity)
                return false;

            Visit newVisit = new Visit
            {
                VisitDate = DateTime.Now,
                ClassSessionId = sessionId,
                MembershipCardId = member.MembershipCard.Id
            };

            _unitOfWork.GetRepository<Visit>().Insert(newVisit);
            _unitOfWork.Complete();
            return true;
        }

        
        
        public bool BuySubscription(int clubId, int memberId, CardType cardType)
        {
            var existingMembership = _unitOfWork.GetRepository<MembershipCard>()
                .GetAll()
                .FirstOrDefault(m => m.MemberId == memberId);

            if (existingMembership != null)
            {
                return false;
            }

            var newMembership = new MembershipCard
            {
                MemberId = memberId,
                CardType = cardType
            };

            _unitOfWork.GetRepository<MembershipCard>().Insert(newMembership);
            _unitOfWork.Complete();

            return true;
        }
    }
}
