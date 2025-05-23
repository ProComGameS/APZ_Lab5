﻿using System.Collections.Generic;
using FitnessClub.DAL;
using FitnessClub.DAL.Models;
using FitnessClub.BLL.DTOs;
using AutoMapper;
using FitnessClub.BLL.Interfaces;

namespace FitnessClub.BLL.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MemberDTO> GetAllMembers()
        {
            var members = _unitOfWork.GetRepository<Member>().GetAll();
            return _mapper.Map<IEnumerable<MemberDTO>>(members);
        }

        public MemberDTO GetMemberById(int id)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(id);
            return _mapper.Map<MemberDTO>(member);
        }

        public bool CreateMember(MemberDTO memberDTO)
        {
            var member = _mapper.Map<Member>(memberDTO);
            _unitOfWork.GetRepository<Member>().Insert(member);
            _unitOfWork.Complete();
            return true;
        }

        public bool UpdateMember(MemberDTO memberDTO)
        {
            var member = _mapper.Map<Member>(memberDTO);
            _unitOfWork.GetRepository<Member>().Update(member);
            _unitOfWork.Complete();
            return true;
        }

        public bool DeleteMember(int memberId)
        {
            var member = _unitOfWork.GetRepository<Member>().GetById(memberId);
            if (member != null)
            {
                _unitOfWork.GetRepository<Member>().Delete(member);
                _unitOfWork.Complete();
                return true;
            }
            return false;
        }
    }
}