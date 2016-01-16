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
    public class DiscountManager : IDiscountService, IDiscountSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Discount> _discountRepository;

        public DiscountManager(IUnitOfWork unitOfWork,
            IRepository<Data.Entities.Discount> discountRepository)
        {
            _discountRepository = discountRepository;
            _unitOfWork = unitOfWork;

            _discountRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<Discount> GetAll()
        {
            var result = _discountRepository.FindBy(d => !d.IsDeleted).AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Discount> GetWherePercentMoreThan(double percent)
        {
            var result = _discountRepository
                .FindBy(d => d.Percent > percent && !d.IsDeleted)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Discount> GetWherePercentLessThan(double percent)
        {
            var result = _discountRepository
                .FindBy(d => d.Percent < percent && !d.IsDeleted)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public Discount GetById(int id)
        {
            var result = _discountRepository
                .FindBy(d => d.Id == id)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public Discount GetByName(string name)
        {
            var result = _discountRepository
                .FindBy(d => d.Name == name)
                .AsEnumerable().First();

            return ConvertToReturn(result);
        }

        public void Create(Discount discount)
        {
            try
            {
                var mapDisocunt = AutoMapper.Mapper.Map
                    <Data.Entities.Discount>(discount);

                _discountRepository.Add(mapDisocunt);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(Discount discount)
        {
            try
            {
                var mapDisocunt = AutoMapper.Mapper.Map
                    <Data.Entities.Discount>(discount);

                var actualDiscount = _discountRepository
                    .FindBy(d => d.Id == mapDisocunt.Id)
                    .First();

                actualDiscount.Name = mapDisocunt.Name;
                actualDiscount.Percent = mapDisocunt.Percent;
                actualDiscount.Description = mapDisocunt.Description;
                actualDiscount.IsDeleted = mapDisocunt.IsDeleted;

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
                var actualDiscount = _discountRepository
                    .FindBy(d => d.Id == id)
                    .First();

                actualDiscount.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<Discount> ConvertToReturn(IEnumerable<Data.Entities.Discount> disocunts)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Discount>>(disocunts);
        } 

        private Discount ConvertToReturn(Data.Entities.Discount discount)
        {
            return AutoMapper.Mapper.Map<Discount>(discount);
        }
    }
}