using Entities.Concrete;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOgrenciService
    {
        IDataResult<List<Ogrenci>> GetAll();
        IDataResult<Ogrenci> GetById(int ogrenciId);

        public IResult Add(Ogrenci ogrenci);
    }
}
