using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MPZT.Infrustructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public LocationRepository()
        {
            //NHibernateBase nHibernate = new NHibernateBase();
            //nHibernate.Initialize();
        }

        public Location Get(int id)
        {
            //try
            //{
            //    using (var session = NHibernateBase.Session) //połaczenie z bazą danych
            //    {

            //        var area = session.Query<Location>()
            //            .Where(x => x.Id == id)
            //            .Single();

            //        return area;
            //    }
            //}
            //catch (Exception e)
            //{

            //    return null;
            //};
            throw new NotImplementedException();
        }

        public List<Location> GetByLocation(Location location)
        {
            List<Location> list = new List<Location>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                list = db.Query<Location>("SELECT * FROM Locations AS L " +
                                     $"WHERE L.Wojewodztwo = '{location.Wojewodztwo}' OR L.City = '{location.City}' OR L.Gmina = '{location.Gmina}' OR L.Powiat= '{location.Powiat}'")
                                     .ToList();
            }
            return list;
        }

        public IList<Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdate(Location item)
        {
          
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
