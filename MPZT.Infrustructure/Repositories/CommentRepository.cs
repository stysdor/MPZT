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
    public class CommentRepository : ICommentRepository
    {
        public IList<Comment> GetComments(int projectId)
        {
            IList<Comment> list = new List<Comment>();

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            {
                var sql = $"SELECT * FROM Comments AS C INNER JOIN Users AS U ON C.UserId = U.Id INNER JOIN Projects AS P ON C.ProjectId = P.Id WHERE C.ProjectId = {projectId}";
                db.Open();
                list = db.Query<Comment, User, Project, Comment>(sql,
                    (comment, user, project) =>
                    {
                        comment.User = user;
                        comment.Project = project;
                        return comment;
                    }
                    ).ToList();
            }
            return list;
        }

        public int InsertOrUpdate(Comment item)
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

        private int Insert(Comment item, IDbConnection db)
        {
            string sql = @"INSERT INTO Comments values "
                + $" ('{item.Content}',{item.User.Id},{item.Project.Id});"
                + @" SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql).Single();

            return id;
        }

        private int Update(Comment item, IDbConnection db)
        {
            string sql = $"UPDATE Comments SET Content = {item.Content}" +
                $"WHERE Id = {item.Id};";

            var affectedRows = db.Execute(sql);
            return affectedRows;
        }

        public Comment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
