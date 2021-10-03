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
    public class SaloonRepository : ISaloonRepository
     
    {
        private readonly MovieContext moviecontext;

        public SaloonRepository(MovieContext _moviecontext)
        {
            moviecontext = _moviecontext;
        }
        public bool Any(Expression<Func<Saloon, bool>> exp)
        {
            return moviecontext.Saloons.Any(exp);
        }

        public string DeleteSaloon(int SaloonId)
        {
            try
            {
                moviecontext.Saloons.Remove(Find(SaloonId));
                moviecontext.SaveChanges();
                return "Salon silindi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Saloon Find(int SaloonId)
        {
            return moviecontext.Saloons.Find(SaloonId);
        }

        public List<Saloon> GetSaloons()
        {
            return moviecontext.Saloons.ToList();
        }

        public string PostSaloon(Saloon saloon)
        {
            try
            {
                moviecontext.Saloons.Add(saloon);
                moviecontext.SaveChanges();
                return "Salon eklendi!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string UpdateSaloon(Saloon Saloon)
        {
            try
            {
                Saloon updated = Find(Saloon.Id);
                moviecontext.Entry(updated).CurrentValues.SetValues(Saloon);
                moviecontext.SaveChanges();
                return "Salon güncellendi!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Saloon> Where(Expression<Func<Saloon, bool>> exp)
        {
            return moviecontext.Saloons.Where(exp).ToList();
        }
    }
}
