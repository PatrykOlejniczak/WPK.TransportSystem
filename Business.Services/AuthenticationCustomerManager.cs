using System;
using System.Linq;
using System.ServiceModel;
using Business.Contracts;
using Core.Common.Secure;
using Data.Core.Repository;
using Data.Core.UnitOfWork;

namespace Business.Services
{
    public class AuthenticationCustomerManager : ICustomerAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Customer> _customerRepository; 

        public AuthenticationCustomerManager(IUnitOfWork unitOfWork,
            IRepository<Data.Entities.Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;

            _customerRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public bool IsCustomerExists(string email)
        {
            var result = _customerRepository.FindBy(c => c.Email == email);

            return result.Any();
        }

        public bool IsCorrectCredentialsCorrect(string email, string password)
        {
            var result = _customerRepository
                .FindBy(c => c.Email == email && PasswordHash.ValidatePassword(password, c.HashPassword));

            return result.Any();
        }

        public bool Register(string email, string password)
        {
            bool returnValue = false;

            if (!IsCustomerExists(email))
            {
                try
                {
                    Data.Entities.Customer newCustomer = new Data.Entities.Customer()
                    {
                        Email = email,
                        HashPassword = PasswordHash.CreateHash(password)
                    };

                    _customerRepository.Add(newCustomer);

                    _unitOfWork.Commit();
                }
                catch (Exception exception)
                {
                    throw new FaultException(exception.Message);
                }

                returnValue = true;
            }

            return returnValue;
        }

        public void SendPasswordReminder(string email)
        {
            //TODO
        }
    }
}