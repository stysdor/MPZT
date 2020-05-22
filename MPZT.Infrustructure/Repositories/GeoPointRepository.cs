using Dapper;
using MPZT.Core.Domain;
using MPZT.Core.Repositories;
using MPZT.Infrustructure.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Repositories
{
    public class GeoPointRepository : IGeoPointRepository
    {

        public List<GeoPoint> GetAllInRange(GeoPoint point, int range)
        {
            List<GeoPoint> points = new List<GeoPoint>();

            //Generates range 1 km in geographic degrees
            double rangeNS = Geographic.countRangeNS(range);
            double rangeEW = Geographic.countRangeEW(range, point.Latitude);

            //Generates range in geographic degrees for range in km
            string eastRange = (point.Longitude + rangeEW).ToString().Replace(",", ".");
            string westRange = (point.Longitude - rangeEW).ToString().Replace(",", ".");
            string northRange = (point.Latitude + rangeNS).ToString().Replace(",", ".");
            string southRange = (point.Latitude - rangeNS).ToString().Replace(",", ".");

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = "SELECT * FROM Geopoints AS G "
                    + $"WHERE G.Latitude BETWEEN {southRange}  AND {northRange} AND G.Longitude BETWEEN {westRange} and {eastRange};";
                db.Open();
                points = db.Query<GeoPoint>(sql)
                                     .Distinct()
                                     .ToList();
            }
            return points;
        }

        public List<GeoPoint> GetByArea(int areaId)
        {
            List<GeoPoint> points = new List<GeoPoint>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT G.* FROM GeoPoints AS G INNER JOIN AreaMPZTGeopoints AS AG ON G.Id = AG.GeoPointId WHERE AG.AreaMPZTId = {areaId}";
                db.Open();
                points = db.Query<GeoPoint>(sql)
                                     .Distinct()
                                     .ToList();
            }
            return points;
        }

        public GeoPoint Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<GeoPoint> GetAll()
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdate(GeoPoint item)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
