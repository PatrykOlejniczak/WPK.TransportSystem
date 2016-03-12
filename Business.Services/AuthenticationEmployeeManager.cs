using System.Linq;
using Business.Contracts;
using Core.Common.Secure;
using Data.Core.Repository;
using Data.Core.UnitOfWork;

namespace Business.Services
{
    public class AuthenticationEmployeeManager
        : IEmployeeAuthentication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.UserAccount> _accountRepository;

        public AuthenticationEmployeeManager(IRepository<Data.Entities.UserAccount> employeeRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = employeeRepository;
            _unitOfWork = unitOfWork;

            employeeRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public bool IsAccountExists(string email)
        {
            var result = _accountRepository.FindBy(a => a.Login == email);

            return result.Any();
        }

        public bool IsEmployeeHaveAccount(int employeeId)
        {
            var result = _accountRepository
                .FindBy(a => a.EmployeeId == employeeId);

            return result.Any();
        }

        public bool IsCorrectCredentialsCorrect(string email, string password)
        {
            var result = _accountRepository
                .FindBy(a => a.Login == email && PasswordHash.ValidatePassword(password, a.HashPassword));

            return result.Any();
        }
    }
}