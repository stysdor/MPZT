using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MPZT.Infrustructure.Helpers;

namespace MPZT.Infrustructure.Repositories
{
    public class AreaRepository: IAreaRepository
    {
        public AreaRepository()
        {
            //NHibernateBase nHibernate = new NHibernateBase();
            //nHibernate.Initialize();
        }
        public AreaMPZT Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<AreaMPZT> GetAll()
        {
            IList<AreaMPZT> list = new List<AreaMPZT>();
            List<int> listLocation = new List<int>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = "SELECT * FROM AreaMPZT AS A INNER JOIN Locations AS L ON A.LocationId = L.Id INNER JOIN Offices AS O ON A.OfficeId = O.Id INNER JOIN Phases AS P ON A.PhaseId = P.Id;";
                db.Open();
                list = db.Query<AreaMPZT, Location, Office, Phase, AreaMPZT>(sql,
                    (area, location, office, phase) =>
                    {
                        area.Location = location;
                        area.Office = office;
                        area.Phase = phase;
                        return area;
                    })
                  .ToList();
            }

            return list;
        }

        public int InsertOrUpdate(AreaMPZT item)
        {
            throw new NotImplementedException();
        }
        //private int Insert(AreaMPZT item, IDbConnection db)
        //{
        //    int officeId = item.Office.Id;
        //    int phaseId = item.Phase.Id;
        //    string sql = @"INSERT INTO AreaMPZT (Name, ConsultationTime, ExpirationDate, PhaseId, OfficeId)"
        //        + $"Values (@Name, @ConsultationTime, @ExpirationDate, {phaseId}, {officeId}, @Country, @YearOfProduction);"
        //        + @"SELECT CAST(SCOPE_IDENTITY() as int)";
        //    var id = db.Query<int>(sql, new
        //    {
        //        item.MovieTitle,
        //        item.MovieDescription,
        //        item.CategoryId,
        //        item.Country,
        //        item.YearOfProduction
        //    }).Single();

        //    return id;
        //}

        //private int Update(AreaMPZT item, IDbConnection db)
        //{
        //    throw new NotImplementedException();
        //}

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets list of AreaMPZT instance which contains specific locations.
        /// !I doesn't return AreaMPZT.GeoPoints property!
        /// </summary>
        /// <param name="locations">List of locations</param>
        /// <returns>Returns list of AreaMPZT instance which contains Location from <paramref name="locations"/></returns>
        public List<AreaMPZT> GetByLocation(List<Location> locations)
        {
            List<AreaMPZT> list = new List<AreaMPZT>();
            List<int> listLocation = new List<int>();
            foreach (var item in locations)
            {
                listLocation.Add(item.Id);
            }

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = "SELECT * FROM AreaMPZT AS A INNER JOIN Locations AS L ON A.LocationId = L.Id INNER JOIN Offices AS O ON A.OfficeId = O.Id INNER JOIN Phases AS P ON A.PhaseId = P.Id WHERE L.Id IN @List;";
                db.Open();
                list = db.Query<AreaMPZT, Location, Office, Phase, AreaMPZT>(sql, 
                    (area, location, office, phase) =>
                    {
                        area.Location = location;
                        area.Office = office;
                        area.Phase = phase;
                        return area;
                    }
                    ,new { List = listLocation })
                  .ToList();   
            }
           
            return list;
        }

        /// <summary>
        /// Gets list of AreaMPZT instance which contains specific geopoints.
        /// !I doesn't return AreaMPZT.GeoPoints property!
        /// </summary>
        /// <param name="points">List of geopoints</param>
        /// <returns>Returns list of AreaMPZT instance which contains min one geopoint from <paramref name="points"/></returns>
        public List<AreaMPZT> GetByGeoPoint(List<GeoPoint> points)
        {
            List<AreaMPZT> list = new List<AreaMPZT>();
            List<int> pointsId = new List<int>();
            foreach (var point in points)
            {
                pointsId.Add(point.Id);
            }

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = "SELECT A.*,L.*,O.*,P.* FROM AreaMPZT AS A INNER JOIN Locations AS L ON A.LocationId = L.Id INNER JOIN Offices AS O ON A.OfficeId = O.Id"
                    +" INNER JOIN Phases AS P ON A.PhaseId = P.Id INNER JOIN AreaMPZTGeopoints AS AG ON A.Id = AG.AreaMPZTId INNER JOIN GeoPoints AS G ON G.Id = AG.GeoPointId "
                    +"WHERE G.Id IN @List;";
                db.Open();
                list = db.Query<AreaMPZT, Location, Office, Phase, AreaMPZT>(sql,
                    (area, location, office, phase) =>
                    {
                        area.Location = location;
                        area.Office = office;
                        area.Phase = phase;
                        return area;
                    }
                    , new { List = pointsId })
                  .ToList();
            }

            return list;
        }
    } 
}
