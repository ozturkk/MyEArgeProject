using Business.Abstract;
using Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Validation;
using System.Linq;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class OgrenciManager : IOgrenciService
    {
        IOgrenciDal _ogrenciDal;

        public OgrenciManager(IOgrenciDal ogrenciDal)
        {
            _ogrenciDal = ogrenciDal;
        }
        
        public IResult Add(Ogrenci ogrenci)
        {
            IResult result = BusinessRules.Run(CheckIfDersAdiExists(ogrenci.DersAdi),
                  CheckIfDonemExists(ogrenci.Donem),
                  CheckIfSinavTuruExists(ogrenci.SinavTuru));
            if (result != null)
            {
                return result;
            }

            _ogrenciDal.Add(ogrenci);
            return new SuccessResult(Messages.OgrenciAdded);
        }

        public IDataResult<List<Ogrenci>> GetAll()
        {
            return new SuccessDataResult<List<Ogrenci>>(_ogrenciDal.GetAll());
        }

        public IDataResult<Ogrenci> GetById(int ogrenciId)
        {
            return new SuccessDataResult<Ogrenci>(_ogrenciDal.Get(c => c.Id == ogrenciId));
        }
        private IResult CheckIfDersAdiExists(string dersAdi)
        {
            var result = _ogrenciDal.GetAll(p => p.DersAdi == dersAdi).Any();
            if (result)
            {
                return new ErrorResult(Messages.DersAdiAlreadyExixts);
            }
            return new SuccessResult();
        }
        private IResult CheckIfDonemExists(string donem)
        {
            var result = _ogrenciDal.GetAll(p => p.Donem == donem).Any();
            if (result)
            {
                return new ErrorResult(Messages.DonemAlreadyExixts);
            }
            return new SuccessResult();
        }
        private IResult CheckIfSinavTuruExists(string sinavTuru)
        {
            var result = _ogrenciDal.GetAll(p => p.SinavTuru == sinavTuru).Any();
            if (result)
            {
                return new ErrorResult(Messages.SinavTuruAlreadyExixts);
            }
            return new SuccessResult();
        }
    }
}
