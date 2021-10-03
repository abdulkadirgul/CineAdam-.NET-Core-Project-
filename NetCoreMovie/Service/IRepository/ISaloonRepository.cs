using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
   public interface ISaloonRepository
    {
        //Listeleme
        List<Saloon> GetSaloons();

        //Ekleme
        string PostSaloon(Saloon Saloon);

        //Arama
        Saloon Find(int SaloonId);


        //Güncelleme
        string UpdateSaloon(Saloon Saloon);

        //Silme
        string DeleteSaloon(int SaloonId);

        //Kritere Göre Arama
        List<Saloon> Where(Expression<Func<Saloon, bool>> exp);

        //Var mı Yok mu?
        bool Any(Expression<Func<Saloon, bool>> exp);
    }
}
