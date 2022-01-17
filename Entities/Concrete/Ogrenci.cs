using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
      public class Ogrenci:IEntity
    {
        public int Id { get; set; }
        public string OgrenciNo { get; set; }
        public string DersAdi { get; set; }
        public string Donem { get; set; }
        public DateTime Yil { get; set; }
        public string SinavTuru { get; set; }
        public int Puan { get; set; }
    }
}
