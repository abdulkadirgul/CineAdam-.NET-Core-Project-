using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.IRepository
{
   public interface ISessionRepository
    {
        List<Session> GetSessions();

        string PostSession(Session Session);

        Session Find(int SessionId);

        string UpdateSession(Session Session);

        string DeleteSession(int SessionId);

      
        List<Session> Where(Expression<Func<Session, bool>> exp);

        
        bool Any(Expression<Func<Session, bool>> exp);
    }
}
