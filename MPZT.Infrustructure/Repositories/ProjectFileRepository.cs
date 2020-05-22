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
    public class ProjectFileRepository : IProjectFileRepository
    {
        public IList<ProjectFile> GetProjectFiles(int projectId)
        {
            IList<ProjectFile> list = new List<ProjectFile>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM ProjectFiles WHERE ProjectId = {projectId}";
                db.Open();
                list = db.Query<ProjectFile>(sql).ToList();
            }
            return list;
        }
    }
}
