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
            var result = _userAccountRepository
                .FindBy(u => u.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<UserAccount> GetAllWithDeleted()
        {
            var result = _userAccountRepository
                .FindAll()
                .AsEnumerable();

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
                    .First();

                if (actualUserAccount.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualUserAccount.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void DeleteByEmployeeId(int employeeId)
        {
            try
            {
                var actualUserAccount = _userAccountRepository
                    .FindBy(d => d.EmployeeId == employeeId)
                    .First();

                if (actualUserAccount.IsDeleted)
                {
                    throw new ArgumentException("This object is already deleted.");
                }

                actualUserAccount.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void UndeleteById(int id)
        {
            try
            {
                var actualUserAccount = _userAccountRepository
                    .FindBy(d => d.Id == id)
                    .First();

                if (!actualUserAccount.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualUserAccount.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void UndeleteByEmployeeId(int employeeId)
        {
            try
            {
                var actualUserAccount = _userAccountRepository
                    .FindBy(d => d.EmployeeId == employeeId)
                    .First();

                if (!actualUserAccount.IsDeleted)
                {
                    throw new ArgumentException("This object is already undeleted.");
                }

                actualUserAccount.IsDeleted = false;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
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