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
    public class NewsManager : INewsService,
        INewsSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.News> _newsRepository;

        public NewsManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.News> newsRepository)
        {
            _unitOfWork = unitOfWork;
            _newsRepository = newsRepository;

            _newsRepository.EnrollUnitOfWork(_unitOfWork);
        }

        public IEnumerable<News> GetAll()
        {
            var result = _newsRepository
                .FindBy(n => n.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public News GetById(int id)
        {
            var result = _newsRepository
                .FindBy(n => n.Id == id)
                .AsEnumerable()
                .First();

            return ConvertToReturn(result);
        }

        public IEnumerable<News> GetByEmployeeId(int employeeId)
        {
            var result = _newsRepository
                .FindBy(n => n.EmployeeId == employeeId)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public void Create(News news)
        {
            try
            {
                var mapNews = AutoMapper.Mapper.Map
                    <Data.Entities.News>(news);

                _newsRepository.Add(mapNews);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(News news)
        {
            try
            {
                var mapNews = AutoMapper.Mapper.Map
                    <Data.Entities.News>(news);

                var actualNews = _newsRepository
                    .FindBy(n => n.Id == mapNews.Id)
                    .First();

                actualNews.EmployeeId = mapNews.EmployeeId;
                actualNews.Content = mapNews.Content;
                actualNews.Title = mapNews.Title;
                actualNews.CreateDate = DateTime.Now;

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
                var actualNews = _newsRepository
                    .FindBy(n => n.Id == id)
                    .AsEnumerable()
                    .First();

                actualNews.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<News> ConvertToReturn(IEnumerable<Data.Entities.News> newses)
        {
            return AutoMapper.Mapper.Map<IEnumerable<News>>(newses);
        }

        private News ConvertToReturn(Data.Entities.News news)
        {
            return AutoMapper.Mapper.Map<News>(news);
        }
    }
}