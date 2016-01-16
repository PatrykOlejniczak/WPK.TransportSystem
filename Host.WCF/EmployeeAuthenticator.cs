using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using Core.Common.Secure;
using Data.Core.Repository;
using Data.Core.UnitOfWork;
using Data.Entities;

namespace Host.WCF
{
    public class EmployeeAuthenticator : UserNamePasswordValidator
    {
        private readonly IRepository<UserAccount> _userAccountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeAuthenticator()
        {
            _userAccountRepository = new Repository<UserAccount>();
            _unitOfWork = new DataContext();

            _userAccountRepository.EnrollUnitOfWork(_unitOfWork);
        }
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new FaultException("Username and passwrod required.");
            }

            var customer = _userAccountRepository
                  .FindBy(c => c.Login == userName && PasswordHash.ValidatePassword(password, c.HashPassword));

            if (!customer.Any())
            {
                throw new FaultException("Wrong username or password.");
            }
        }
    }
}