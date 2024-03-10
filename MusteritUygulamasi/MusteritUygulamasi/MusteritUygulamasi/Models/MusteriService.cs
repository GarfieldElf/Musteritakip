using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteritUygulamasi.Models
{
    public  class MusteriService
    {
        private static List<Musteri>? ObjMusteriList;

        public MusteriService()
        {
            ObjMusteriList = new List<Musteri>()
            {
              new Musteri{ MusteriId=1, MusteriAdi="Hüsnü", MusteriSoyadi="Çoban", MusteriTel="05326526412" , MusteriEposta="husnucbn@gmail.com" }

            };

         }

        public List<Musteri>? GetAll()
        {
            return ObjMusteriList;
        }

        public bool Add(Musteri objNewMusteri)
        {
            if (objNewMusteri.MusteriAdi == "" || objNewMusteri.MusteriSoyadi == "")
                throw new ArgumentException("Ad ve Soyad Boş Bırakılamaz");

            ObjMusteriList?.Add(objNewMusteri);
            return true;
        }

        public bool Update(Musteri objMusteritoUpdate)
        {
            bool isUpdated = false;

            for(int index = 0; index < ObjMusteriList?.Count; index++)
            {
                if (ObjMusteriList[index].MusteriId == objMusteritoUpdate.MusteriId)
                {
                    ObjMusteriList[index].MusteriAdi = objMusteritoUpdate.MusteriAdi;
                    ObjMusteriList[index].MusteriSoyadi = objMusteritoUpdate.MusteriSoyadi;
                    ObjMusteriList[index].MusteriTel = objMusteritoUpdate.MusteriTel;
                    ObjMusteriList[index].MusteriEposta = objMusteritoUpdate.MusteriEposta;
                    isUpdated = true;
                    break;

                }
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            for(int index = 0; index < ObjMusteriList?.Count; index++)
            {
                if (ObjMusteriList[index].MusteriId == id)
                {
                    ObjMusteriList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }

            return isDeleted;
        }

        public Musteri? Search(int id) //simdilik idye göre search 
        {
            return ObjMusteriList?.FirstOrDefault(e => e.MusteriId == id);

        }
    }
}
