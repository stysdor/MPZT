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

        public Location Get(int id)
        {
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
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                if (item.Id > 0)
                    return Update(item, db);
                else
                    return InsertOrGetId(item, db);
            }
        }

        private int InsertOrGetId(Location item, IDbConnection db)
        {
            string sql = @"SELECT * FROM Locations "
                + $"WHERE Country = '{item.Country}' AND Wojewodztwo = '{item.Wojewodztwo}' AND Powiat =  '{item.Powiat}' AND Gmina = '{item.Gmina}' AND City = '{item.City}' AND "
                +$" Dzielnica = '{item.Dzielnica}' AND Street = '{item.Street}' AND NrLand = '{item.NrLand}';"
                + @"SELECT CAST(SCOPE_IDENTITY() as int)";
            var location = db.Query<Location>(sql).FirstOrDefault();
            if (item.Equals(location))
                return location.Id;
            else
                return Insert(item, db);
        }

        private int Insert(Location item, IDbConnection db)
        {

            string sql = @"INSERT INTO Locations "
                + $"Values ('{item.Country}', '{item.Wojewodztwo}', '{item.Powiat}', '{item.Gmina}', '{item.City}', '{item.Dzielnica}','{item.Street}','{item.NrLand}');"
                + @"SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = db.Query<int>(sql).SingleOrDefault();
            return id;
        }

        private int Update(Location item, IDbConnection db)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
