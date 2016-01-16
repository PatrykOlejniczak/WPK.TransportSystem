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
    public class EmployeeManager : IEmployeeSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Employee> _employeeRepository;

        public EmployeeManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.Employee> employeeRepository)
        {
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;

            _employeeRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<Employee> GetAll()
        {
            var result = _employeeRepository
                .FindAll()
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public Employee GetById(int id)
        {
            var result = _employeeRepository
                .FindBy(e => e.Id == id)
                .AsEnumerable()
                .First();

            return ConvertToReturn(result);
        }

        public void Create(Employee employee)
        {
            try
            {
                var mapEmployee = AutoMapper.Mapper.Map
                    <Data.Entities.Employee>(employee);

                _employeeRepository.Add(mapEmployee);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(Employee employee)
        {
            try
            {
                var mapEmployee = AutoMapper.Mapper.Map
                    <Data.Entities.Employee>(employee);

                var actualEmployee = _employeeRepository
                    .FindBy(e => e.Id == mapEmployee.Id)
                    .First();

                actualEmployee.AreaCode = mapEmployee.AreaCode;
                actualEmployee.City = mapEmployee.City;
                actualEmployee.Country = mapEmployee.Country;
                actualEmployee.FirstName = mapEmployee.FirstName;
                actualEmployee.LastName = mapEmployee.LastName;
                actualEmployee.EndDate = mapEmployee.EndDate;
                actualEmployee.PostalCode = mapEmployee.PostalCode;
                actualEmployee.Province = mapEmployee.Province;
                actualEmployee.SecondName = mapEmployee.SecondName;
                actualEmployee.StartDate = mapEmployee.StartDate;
                actualEmployee.Street = mapEmployee.Street;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<Employee> ConvertToReturn(IEnumerable<Data.Entities.Employee> employees)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Employee>>(employees);
        }

        private Employee ConvertToReturn(Data.Entities.Employee employee)
        {
            return AutoMapper.Mapper.Map<Employee>(employee);
        }
    }
}