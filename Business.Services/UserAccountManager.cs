using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Business.Contracts;
using Business.Entities;
using Data.Core.Repository;
using Data.Core.UnitOfWork;

namespace Business.Services
{
    public class UserAccountManager : IUserAccountSecureService
    {
        private readonly IUnitOfWork _unitOfWork ;
        private readonly IRepository<Data.Entities.UserAccount> _userAccountRepository;

        public UserAccountManager(IUnitOfWork unitOfWork, 
            IRepository<Data.Entities.UserAccount> userAccountRepository)
        {
            _unitOfWork = unitOfWork;
            _userAccountRepository = userAccountRepository;

            _userAccountRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<UserAccount> GetAll()
        {
            var result = _userAccountRepository.FindAll().AsEnumerable();

            return ConvertToReturn(result);
        }

        public UserAccount GetById(int id)
        {
            var result = _userAccountRepository.FindBy(u => u.Id == id)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public UserAccount GetByEmployeeId(int employeeId)
        {
            var result = _userAccountRepository.FindBy(u => u.EmployeeId == employeeId)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public void Create(UserAccount userAccount)
        {
            try
            {
                var mapUserAccount = AutoMapper.Mapper.Map
                    <Data.Entities.UserAccount>(userAccount);

                _userAccountRepository.Add(mapUserAccount);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                var actualUserAccount = _userAccountRepository
                    .FindBy(d => d.Id == id)
                    .AsEnumerable();

                actualUserAccount.First().IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void DeleteByEmployeeId(int employeeId)
        {
            throw new System.NotImplementedException();
        }

        private IEnumerable<UserAccount> ConvertToReturn(IEnumerable<Data.Entities.UserAccount> userAccounts)
        {
            return AutoMapper.Mapper.Map<IEnumerable<UserAccount>>(userAccounts);
        }

        private UserAccount ConvertToReturn(Data.Entities.UserAccount userAccount)
        {
            return AutoMapper.Mapper.Map<UserAccount>(userAccount);
        }

    }
}