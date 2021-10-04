using DataAccess.Context;
using DataAccess.Entity;
using Service.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class WeekRepository : IWeekRepository
    {
        private readonly MovieContext moviecontext;

        public WeekRepository(MovieContext _moviecontext)
        {
            moviecontext = _moviecontext;
        }
        public bool Any(Expression<Func<Week, bool>> exp)
        {
            return moviecontext.Weeks.Any(exp);
        }

        public string DeleteWeek(int WeekId)
        {

            try
            {
                moviecontext.Weeks.Remove(Find(WeekId));
                moviecontext.SaveChanges();
                return "Hafta silindi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
        }

        public Week Find(int WeekId)
        {
            return moviecontext.Weeks.Find(WeekId);
        }

        public List<Week> GetWeeks()
        {
            return moviecontext.Weeks.ToList();
        }

        public string PostWeek(Week week)
        {

            try
            {
                moviecontext.Weeks.Add(week);
                moviecontext.SaveChanges();
                return "Hafta eklendi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
        }

        public string UpdateWeek(Week week)
        {
            try
            {
                Week updated = Find(week.Id);
                moviecontext.Entry(updated).CurrentValues.SetValues(week);
                moviecontext.SaveChanges();
                return "Hafta güncellendi!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Week> Where(Expression<Func<Week, bool>> exp)
        {
            return moviecontext.Weeks.Where(exp).ToList();
        }
    }
}
