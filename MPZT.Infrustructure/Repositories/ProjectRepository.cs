using Dapper;
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

namespace MPZT.Infrustructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        public Project GetByArea(int areaId)
        {
           Project project = new Project();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Projects WHERE AreaMPZTId = {areaId}";
                db.Open();
                project = db.Query<Project>(sql).SingleOrDefault();
            }
            return project;
        }

        public Project Get(int id)
        {
            Project project = new Project();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Projects WHERE Id = {id}";
                db.Open();
                project = db.Query<Project>(sql).SingleOrDefault();
            }
            return project;
        }

        public IList<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdate(Project item)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                db.Open();
                if (item.Id > 0)
                    return Update(item, db);
                else
                    return Insert(item, db);
            }
        }

        private int Insert(Project item, IDbConnection db)
        {
            string sql = @"INSERT INTO Project values "
                + $" ('{item.Description}',{item.Number},{item.AreaMPZT.Id});"
                + @" SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql).Single();

            return id;
        }

        private int Update(Project item, IDbConnection db)
        {

            string sql = $"UPDATE Project SET Description = {item.Description}, Number = {item.Number}" +
                $"WHERE Id = {item.Id};";

            var affectedRows = db.Execute(sql);
            return affectedRows;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
