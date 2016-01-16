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
    public class PhotoManager : IPhotoService,
        IPhotoSecureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Data.Entities.Photo> _photoRepository;

        public PhotoManager(IUnitOfWork unitOfWork, IRepository<Data.Entities.Photo> photoRepository)
        {
            _unitOfWork = unitOfWork;
            _photoRepository = photoRepository;

            _photoRepository.EnrollUnitOfWork(_unitOfWork);
        } 

        public IEnumerable<Photo> GetAll()
        {
            var result = _photoRepository
                .FindBy(p => p.IsDeleted == false)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public IEnumerable<Photo> GetByNewsId(int newsId)
        {
            var result = _photoRepository
                .FindBy(p => p.NewsId == newsId)
                .AsEnumerable();

            return ConvertToReturn(result);
        }

        public Photo GetById(int id)
        {
            var result = _photoRepository
                .FindBy(p => p.Id == id)
                .AsEnumerable()
                .First();

            return ConvertToReturn(result);
        }

        public void Create(Photo photo)
        {
            try
            {
                var mapPhoto = AutoMapper.Mapper.Map
                    <Data.Entities.Photo>(photo);

                _photoRepository.Add(mapPhoto);

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        public void Update(Photo photo)
        {
            try
            {
                var mapPhoto = AutoMapper.Mapper.Map
                    <Data.Entities.Photo>(photo);

                var actualPhoto = _photoRepository
                    .FindBy(p => p.Id == mapPhoto.Id)
                    .First();

                actualPhoto.NewsId = mapPhoto.NewsId;
                actualPhoto.File = mapPhoto.File;
                actualPhoto.Name = mapPhoto.Name;

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
                var actualPhoto = _photoRepository
                    .FindBy(p => p.Id == id)
                    .First();

                actualPhoto.IsDeleted = true;

                _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                throw new FaultException(exception.Message);
            }
        }

        private IEnumerable<Photo> ConvertToReturn(IEnumerable<Data.Entities.Photo> photos)
        {
            return AutoMapper.Mapper.Map<IEnumerable<Photo>>(photos);
        }

        private Photo ConvertToReturn(Data.Entities.Photo photo)
        {
            return AutoMapper.Mapper.Map<Photo>(photo);
        }

    }
}