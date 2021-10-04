using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
   public interface IWeekRepository
    {
        List<Week> GetWeeks();

        string PostWeek(Week week);

        Week Find(int WeekId);

        string UpdateWeek(Week week);

        string DeleteWeek(int WeekId);

        //Kritere Göre Arama
        List<Week> Where(Expression<Func<Week, bool>> exp);

        //Var mı Yok mu?
        bool Any(Expression<Func<Week, bool>> exp);

    }
}
