using System.Collections.Generic;
using System.Linq;
using Business.Contracts;
using Business.Entities;
using Data.Core.Repository;
using Data.Core.UnitOfWork;

namespace Business.Services
{
    public class CustomerManager : ICustomerSecureService
    {
        private readonly IUnitOfWork _unittOfWork;
        private readonly IRepository<Data.Entities.Customer> _customerRepository; 

        public CustomerManager(IUnitOfWork unitOfWork,
            IRepository<Data.Entities.Customer> customerRepository)
        {
            _customerRepository = customerRepository;
            _unittOfWork = unitOfWork;

            _customerRepository.EnrollUnitOfWork(_unittOfWork);
        }

        public IEnumerable<Customer> GetAll()
        {
            var result = _customerRepository.FindBy(c => !c.IsDeleted).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Customer> GetWhereAccountBallanceMoreThan(double ballance)
        {
            var result = _customerRepository
                .FindBy(c => c.AccountBallance > ballance && !c.IsDeleted).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Customer> GetWhereAccountBallanceLessThan(double ballance)
        {
            var result = _customerRepository
                .FindBy(c => c.AccountBallance < ballance && !c.IsDeleted).AsEnumerable();

            return ConvertToReturn(result);
        }

        public Customer GetById(int id)
        {
            var result = _customerRepository
                .FindBy(c => c.Id == id)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public Customer GetByEmail(string email)
        {
            var result = _customerRepository
                .FindBy(c => c.Email == email)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        private IEnumerable<Customer> ConvertToReturn(IEnumerable<Data.Entities.Customer> customers)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Customer>>(customers);
        }

        private Customer ConvertToReturn(Data.Entities.Customer customer)
        {
            return AutoMapper.Mapper.Map<Customer>(customer);
        }
    }
}