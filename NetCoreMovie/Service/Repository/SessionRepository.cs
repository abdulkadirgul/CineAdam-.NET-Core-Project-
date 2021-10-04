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
    public class SessionRepository : ISessionRepository
    {
        private readonly MovieContext moviecontext;

        public SessionRepository(MovieContext _moviecontext)
        {
            moviecontext = _moviecontext;
        }
        public bool Any(Expression<Func<Session, bool>> exp)
        {
            return moviecontext.Sessions.Any(exp);
        }

        public string DeleteSession(int SessionId)
        {
            try
            {
                moviecontext.Sessions.Remove(Find(SessionId));
                moviecontext.SaveChanges();
                return "Session silindi! ";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public Session Find(int SessionId)
        {
            return moviecontext.Sessions.Find(SessionId);
        }

        public List<Session> GetSessions()
        {
            return moviecontext.Sessions.ToList();
        }

        public string PostSession(Session Session)
        {

            try
            {
                moviecontext.Sessions.Add(Session);
                moviecontext.SaveChanges();
                return "Session kaydedildi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
           
        }

        public string UpdateSession(Session session)
        {
            try
            {
                Session updated = Find(session.Id);
                moviecontext.Entry(updated).CurrentValues.SetValues(session);
                moviecontext.SaveChanges();
                return "Session güncellendi";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }

        public List<Session> Where(Expression<Func<Session, bool>> exp)
        {
            return moviecontext.Sessions.Where(exp).ToList();
        }
    }
}
