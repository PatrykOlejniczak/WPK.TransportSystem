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
    public class BoostAccountManager : IBoostAccountCreatorService, IBoostAccountSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.BoostAccount> _boostAccountRepository;

        public BoostAccountManager(IUnitOfWork unitOfWork, 
            IRepository<Data.Entities.BoostAccount> boostAccountRepository)
        {
            _boostAccountRepository = boostAccountRepository;
            _unitOfWork = unitOfWork;

           _boostAccountRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public string GetNewCodeFor(double amount)
        {
            Data.Entities.BoostAccount newBoostAccount;

            try
            {
                newBoostAccount = new Data.Entities.BoostAccount()
                {
                    Amount = amount,
                    GeneratedDateTime = DateTime.Now,
                    Code = Guid.NewGuid().ToString()
                };

                _boostAccountRepository.Add(newBoostAccount);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
                       
            return newBoostAccount.Code;
        }

        public IEnumerable<BoostAccount> GetAll()
        {
            var result = _boostAccountRepository.FindAll().AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetLastest(int number)
        {
            var result =
                _boostAccountRepository.FindAll()
                    .OrderByDescending(b => b.GeneratedDateTime)
                    .Take(number)
                    .AsEnumerable();

            return ConvertToReturn(result);

        }

        public IEnumerable<BoostAccount> GetActivatedAfterDate(DateTime dateTime)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.DateOfBoost > dateTime).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetActivatedToDate(DateTime dateTime)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.DateOfBoost < dateTime).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetWithUsedCode()
        {
            var result = _boostAccountRepository
                .FindBy(b => b.CustomerId != null).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetWithNotUsedCode()
        {
            var result = _boostAccountRepository
                .FindBy(b => b.CustomerId == null).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetGeneratedAfterDate(DateTime dateTime)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.GeneratedDateTime > dateTime).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetGeneratedToDate(DateTime dateTime)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.GeneratedDateTime < dateTime).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetWhereAmountMoreThan(double amount)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.Amount > amount).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<BoostAccount> GetWhereAmountLessThan(double amount)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.Amount < amount).AsEnumerable();

            return ConvertToReturn(result);
        }    

        public BoostAccount GetByCustomer(int cutomerId)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.CustomerId == cutomerId).AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public BoostAccount GetById(int id)
        {
            var result = _boostAccountRepository
                .FindBy(b => b.Id == id).AsEnumerable().First();

            return ConvertToReturn(result);
        }

        private BoostAccount ConvertToReturn(Data.Entities.BoostAccount boostAccount)
        {
            return AutoMapper.Mapper.Map<BoostAccount>(boostAccount);
        }

        private IEnumerable<BoostAccount> ConvertToReturn(IEnumerable<Data.Entities.BoostAccount> boostAccounts)
        {
            return AutoMapper.Mapper.Map<IEnumerable<BoostAccount>>(boostAccounts);
        }
    }
}